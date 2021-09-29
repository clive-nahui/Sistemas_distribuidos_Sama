using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IPedidoRepository _PedidoRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IProductoRepository _ProductoRepository;

        /// </summary>
        /// <param name="PedidoRepository"></param>
        /// <param name="ProductoRepository"></param>
        public PedidoController(IPedidoRepository PedidoRepository, IProductoRepository ProductoRepository)
        {
            this._PedidoRepository = PedidoRepository;
            this._ProductoRepository = ProductoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pedidoDetalle"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("agregarProductos")]
        public ActionResult agregarProductos(EntityPedidoDetalle pedidoDetalle)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            int idUsuario = int.Parse(userId);

            var pedidoObj = _PedidoRepository.obtenerPedidoActivo(idUsuario);

            if (pedidoObj.data == null)
            {
                //crear pedido
                EntityPedido nuevoPedido = new EntityPedido();
                nuevoPedido.IDUSUARIO = idUsuario;
                nuevoPedido.TOTAL_PAGAR = 0;
                nuevoPedido.ESTADO = 0;
                pedidoObj = _PedidoRepository.registrarPedido(nuevoPedido);
            }

            EntityPedido pedido = 
                JsonConvert.DeserializeObject<EntityPedido>(pedidoObj.json);

            //agregar productos al pedido detalle
            pedidoDetalle.IDPEDIDO = pedido.IDPEDIDO;
            var productoObj = _ProductoRepository.getProducto(pedidoDetalle.IDPRODUCTO);
            EntityProducto producto = JsonConvert.DeserializeObject<EntityProducto>(productoObj.json);
            pedidoDetalle.CANTIDAD = 1;
            pedidoDetalle.PRECIOUNITARIO = producto.PRECIO;
            _PedidoRepository.adicionarProductos(pedidoDetalle);

            return Json(pedidoObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pedidoDetalle"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("disminuirProductos")]
        public ActionResult disminuirProductos(EntityPedidoDetalle pedidoDetalle)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            int idUsuario = int.Parse(userId);

            var pedidoObj = _PedidoRepository.obtenerPedidoActivo(idUsuario);

            EntityPedido pedido =
                JsonConvert.DeserializeObject<EntityPedido>(pedidoObj.json);

            pedidoDetalle.IDPEDIDO = pedido.IDPEDIDO;

            _PedidoRepository.disminuirProductos(pedidoDetalle);

            var pedidoAct = _PedidoRepository.obtenerPedidoActivo(idUsuario);

            return Json(pedidoAct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("listarPedidoDetalle")]
        public ActionResult listarPedidoDetalle()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            int idUsuario = int.Parse(userId);

            var pedidoObj = _PedidoRepository.obtenerPedidoActivo(idUsuario);

            if(pedidoObj.data == null)
            {
                var vacio = _PedidoRepository.listarPedidoDetalle(0);

                return Json(vacio);
            }

            EntityPedido pedido =
                JsonConvert.DeserializeObject<EntityPedido>(pedidoObj.json);

            var ret = _PedidoRepository.listarPedidoDetalle(pedido.IDPEDIDO);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("pagarPedido")]
        public ActionResult pagarPedido()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            int idUsuario = int.Parse(userId);

            var pedidoObj = _PedidoRepository.obtenerPedidoActivo(idUsuario);

            EntityPedido pedido =
                JsonConvert.DeserializeObject<EntityPedido>(pedidoObj.json);

            var pedidoPagado = _PedidoRepository.pagarPedido(pedido);

            return Json(pedidoPagado);
        }
    }
}
