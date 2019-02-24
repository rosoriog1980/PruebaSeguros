using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSeguros.Entities
{
    public class Poliza
    {
        public int PolizaId { get; set; }
        public string PolizaNombre { get; set; }
        public string PolizaDescripcion { get; set; }
        public List<Cubrimiento> PolizaCubrimientos { get; set; }
        public DateTime PolizaInicio { get; set; }
        public int PolizaPeriodoCobertura { get; set; }
        public int PolizaPrecio { get; set; }
        public int PolizaRiesgo { get; set; }

        public string PolizaRiesgoNombre { get; set; }
    }
}
