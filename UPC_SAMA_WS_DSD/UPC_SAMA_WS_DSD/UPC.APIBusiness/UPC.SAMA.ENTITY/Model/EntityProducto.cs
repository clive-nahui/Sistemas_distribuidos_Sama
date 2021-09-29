using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProducto : EntityBase
    {
        public int IDPRODUCTO { get; set; }
        public int IDCATEGORIA { get; set; }
        public string NOMBRECATEGORIA { get; set; }
        public string URLIMAGENCATEGORIA { get; set; }
        public string NOMBRE { get; set; }
        public string URLIMAGEN { get; set; }
        public decimal PRECIO { get; set; }
        public string DESCRIPCION { get; set; }

    }
}
