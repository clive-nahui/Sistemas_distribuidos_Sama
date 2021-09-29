using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProductoRepository _productoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productoRepository"></param>
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproductosxcategoria")]
        public ActionResult getProductosxCategoria(int IDCATEGORIA)
        {
            var ret = _productoRepository.getProductosxCategoria(IDCATEGORIA);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproductos")]
        public ActionResult getProductos()
        {
            var ret = _productoRepository.getProductos();

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproducto")]
        public ActionResult getProducto(int IDPRODUCTO)
        {
            var ret = _productoRepository.getProducto(IDPRODUCTO);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult insert(EntityProducto producto)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            producto.UsuarioModifica = int.Parse(userId);

            var ret = _productoRepository.Insert(producto);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult update(EntityProducto producto)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            producto.UsuarioModifica = int.Parse(userId);

            var ret = _productoRepository.Update(producto);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("delete")]
        public ActionResult delete(EntityProducto producto)
        {
            var ret = _productoRepository.Delete(producto);

            return Json(ret);
        }
    }
}
