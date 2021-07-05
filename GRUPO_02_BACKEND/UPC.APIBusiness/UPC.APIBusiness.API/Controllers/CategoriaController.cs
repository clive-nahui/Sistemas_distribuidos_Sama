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
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICategoriaRepository _categoriaRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriaRepository"></param>
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcategorias")]
        public ActionResult getCategorias()
        {
            var ret = _categoriaRepository.getCategorias();

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcategoria")]
        public ActionResult getCategoria(int IDCATEGORIA)
        {
            var ret = _categoriaRepository.getCategoria(IDCATEGORIA);

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
        public ActionResult insert(EntityCategoria project)
        {
            var ret = _categoriaRepository.Insert(project);

            return Json(ret);
        }
    }
}
