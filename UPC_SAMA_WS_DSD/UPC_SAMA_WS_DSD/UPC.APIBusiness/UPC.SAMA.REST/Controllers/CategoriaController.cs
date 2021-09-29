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
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult insert(EntityCategoria categoria)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            categoria.UsuarioCrea = int.Parse(userId);

            var ret = _categoriaRepository.Insert(categoria);

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
        public ActionResult update(EntityCategoria categoria)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            categoria.UsuarioModifica = int.Parse(userId);

            var ret = _categoriaRepository.Update(categoria);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("delete")]
        public ActionResult delete(EntityCategoria categoria)
        {
            var ret = _categoriaRepository.Delete(categoria);

            return Json(ret);
        }
    }
}
