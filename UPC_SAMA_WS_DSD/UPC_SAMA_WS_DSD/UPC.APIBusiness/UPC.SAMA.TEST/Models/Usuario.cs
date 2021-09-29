using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.UnitTest.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string DocumentoIdentidad { get; set; }
    }
}
