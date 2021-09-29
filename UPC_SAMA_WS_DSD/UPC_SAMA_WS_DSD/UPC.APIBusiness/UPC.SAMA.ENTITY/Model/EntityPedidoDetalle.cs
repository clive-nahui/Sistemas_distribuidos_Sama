using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityPedidoDetalle
    {
        public int IDPEDIDO { get; set; }
        public int IDPRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public int CANTIDAD { get; set; }
        public decimal PRECIOUNITARIO { get; set; }
        public decimal SUBTOTAL { get; set; }
    }
}
