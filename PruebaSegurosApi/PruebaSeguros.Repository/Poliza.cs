//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaSeguros.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poliza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poliza()
        {
            this.PolizaCoberturas = new HashSet<PolizaCoberturas>();
        }
    
        public int PolizaId { get; set; }
        public string PolizaNombre { get; set; }
        public string PolizaDescripcion { get; set; }
        public System.DateTime PolizaInicio { get; set; }
        public int PolizaPeriodoCobertura { get; set; }
        public int PolizaPrecio { get; set; }
        public int PolizaRiesgo { get; set; }
    
        public virtual Riesgo Riesgo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolizaCoberturas> PolizaCoberturas { get; set; }
    }
}
