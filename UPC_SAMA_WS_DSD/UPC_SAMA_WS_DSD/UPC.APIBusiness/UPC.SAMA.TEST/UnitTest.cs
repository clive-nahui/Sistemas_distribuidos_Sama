using DBEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using UPC.APIBusiness.UnitTest.Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
      

        [TestMethod]
        public void ProductoRESTTest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("https://localhost:44309/api/producto/getproducto?IDPRODUCTO=1");
            req.Method = "GET";
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            ResponseBase productoConsultado = JsonConvert.DeserializeObject<ResponseBase>(productoJson);
            Assert.AreEqual("0000", productoConsultado.errorCode);
        }

        [TestMethod]
        public void UsuarioRESTTest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("https://localhost:44309/api/usuario/getusuario?IDUSUARIO=4");
            req.Method = "GET";
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string usuarioJson = reader.ReadToEnd();
            ResponseBase usuarioConsultado = JsonConvert.DeserializeObject<ResponseBase>(usuarioJson);
            Assert.AreEqual("0000", usuarioConsultado.errorCode);
        }
    }
}
