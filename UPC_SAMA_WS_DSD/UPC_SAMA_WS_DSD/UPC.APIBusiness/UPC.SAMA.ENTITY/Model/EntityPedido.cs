using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityPedido
    {
        public int IDPEDIDO { get; set; }
        public int IDUSUARIO { get; set; }
        public decimal TOTAL_PAGAR { get; set; }
        public int ESTADO { get; set; }
    }
}
