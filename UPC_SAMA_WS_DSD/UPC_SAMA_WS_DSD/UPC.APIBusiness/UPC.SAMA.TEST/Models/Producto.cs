using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.UnitTest.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string urlImagen { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
    }
}
