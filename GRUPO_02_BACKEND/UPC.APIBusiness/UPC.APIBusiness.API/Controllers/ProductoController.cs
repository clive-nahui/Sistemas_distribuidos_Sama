using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("getproductos")]
        public ActionResult getProductos(int IDCATEGORIA)
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
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult insert(EntityProducto project)
        {
            var ret = _productoRepository.Insert(project);

            return Json(ret);
        }
    }
}
