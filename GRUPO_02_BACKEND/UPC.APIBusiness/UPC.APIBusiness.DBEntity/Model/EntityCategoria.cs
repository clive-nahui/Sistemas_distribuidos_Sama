using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCategoria : EntityBase
    {
        public int IDCATEGORIA { get; set; }
        public string NOMBRE { get; set; }
        public string URLIMAGEN { get; set; }
    }
}
