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
    
    public partial class PolizaCoberturas
    {
        public int Id { get; set; }
        public int PolizaId { get; set; }
        public int CoberturaId { get; set; }
        public int Porcentaje { get; set; }
    
        public virtual Cubrimiento Cubrimiento { get; set; }
        public virtual Poliza Poliza { get; set; }
    }
}
