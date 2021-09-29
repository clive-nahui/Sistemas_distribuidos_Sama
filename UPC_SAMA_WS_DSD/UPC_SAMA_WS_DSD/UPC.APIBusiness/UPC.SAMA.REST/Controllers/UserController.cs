using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UPC.APIBusiness.DBEntity.Model;
using UPC.E31A.APIBusiness.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/usuario")]
    [ApiController]
    public class UserController : Controller
    {
        private static readonly string _url = "amqps://ikjbjvgs:wB9YHIqQ9k1gGk-nCgDOmuNaP9CwQpgH@snake.rmq2.cloudamqp.com/ikjbjvgs";

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult Register(EntityUser user)
        {
            EscribirCola(user);
            user = LeerCola();

            user.IdPerfil = "2";
            var ret = _UserRepository.Insert(user);

            return Json(ret);
        }

        private void EscribirCola(EntityUser user)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_url)
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            // ensure that the queue exists before we publish to it
            var queueName = "notificaciones";
            bool durable = true;
            bool exclusive = false;
            bool autoDelete = false;

            channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            // read message from input
            var message = JsonConvert.SerializeObject(user);
            // the data put on the queue must be a byte array
            var data = Encoding.UTF8.GetBytes(message);
            // publish to the "default exchange", with the queue name as the routing key
            var exchangeName = "";
            var routingKey = queueName;
            channel.BasicPublish(exchangeName, routingKey, null, data);
        }

        private EntityUser LeerCola()
        {
            EntityUser usuario = new EntityUser();

            var factory = new ConnectionFactory
            {
                Uri = new Uri(_url)
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueName = "notificaciones";
                bool durable = true;
                bool exclusive = false;
                bool autoDelete = false;

                channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

                BasicGetResult consumer = channel.BasicGet(
                    queueName, true);

                if(consumer != null)
                {
                    string resultado = Encoding.UTF8.GetString(
                        consumer.Body.ToArray());
                    usuario = JsonConvert.DeserializeObject<EntityUser>(resultado);
                }
            }
            
            return usuario;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityUser usuario)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            usuario.UsuarioCrea = int.Parse(userId);

            var ret = _UserRepository.Insert(usuario);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.data != null)
            {
                var responseLogin = ret.data as EntityLoginResponse;
                var userId = responseLogin.IdUsuario.ToString();
                var userDoc = responseLogin.DocumentoIdentidad;

                var token = JsonConvert
                                    .DeserializeObject<AccessToken>(
                                        await new Authentication()
                                        .GenerateToken(userDoc, userId)
                                        ).access_token;

                responseLogin.token = token;
                ret.data = responseLogin;
            }

            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult update(EntityUser usuario)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            usuario.UsuarioModifica = int.Parse(userId);

            var ret = _UserRepository.Update(usuario);

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
        public ActionResult delete(EntityUser usuario)
        {
            var ret = _UserRepository.Delete(usuario);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getusuarios")]
        public ActionResult getUsuarios()
        {
            var ret = _UserRepository.getUsuarios();

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getusuario")]
        public ActionResult getUsuario(string IDUSUARIO)
        {
            var ret = _UserRepository.getUsuario(IDUSUARIO);

            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getrandomuser")]
        public async Task<IActionResult> getRandomUser()
        {
            RandomUser randomUser = new RandomUser();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://randomuser.me/api"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    randomUser = JsonConvert.DeserializeObject<RandomUser>(apiResponse);
                }
            }

            var ret = new ResponseBase();
            ret.data = randomUser;
            ret.isSuccess = true;
            ret.errorCode = "0000";
            ret.errorMessage = string.Empty;

            return Json(ret);
        }
    }
}