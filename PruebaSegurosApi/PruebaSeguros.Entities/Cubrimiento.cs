using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSeguros.Entities
{
    public class Cubrimiento
    {
        public int CubrimientoId { get; set; }
        public string CubrimientoDescripcion { get; set; }
        public int Porcentaje { get; set; }
    }
}
