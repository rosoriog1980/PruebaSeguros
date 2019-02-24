using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSeguros.Entities;

namespace PruebaSeguros.Repository
{
    public class PolizaRepository : Interfaces.IfPoliza
    {
        public Entities.Poliza GetPoliza(int id)
        {
            using (PolizasDBEntities1 context = new PolizasDBEntities1())
            {
                var p =  context.Poliza.FirstOrDefault(x => x.PolizaId == id);

                return new Entities.Poliza {
                    PolizaId = p.PolizaId,
                    PolizaNombre = p.PolizaNombre,
                    PolizaDescripcion = p.PolizaDescripcion,
                    PolizaInicio = p.PolizaInicio,
                    PolizaPeriodoCobertura = p.PolizaPeriodoCobertura,
                    PolizaPrecio = p.PolizaPrecio,
                    PolizaRiesgo = p.PolizaRiesgo,
                    PolizaRiesgoNombre = p.Riesgo.RiesgoDescripcion,
                    PolizaCubrimientos = p.PolizaCoberturas.Select(c => new Entities.Cubrimiento
                    {
                        CubrimientoId = c.CoberturaId,
                        CubrimientoDescripcion = c.Cubrimiento.CubrimientoDescripcion,
                        Porcentaje = c.Porcentaje
                    }).ToList()
                };
            }
        }

        public List<Entities.Poliza> GetPolizas()
        {
            using (PolizasDBEntities1 context = new PolizasDBEntities1())
            {
                return context.Poliza.Select(x => new Entities.Poliza {
                    PolizaId = x.PolizaId,
                    PolizaNombre = x.PolizaNombre,
                    PolizaDescripcion = x.PolizaDescripcion,
                    PolizaInicio = x.PolizaInicio,
                    PolizaPeriodoCobertura = x.PolizaPeriodoCobertura,
                    PolizaPrecio = x.PolizaPrecio,
                    PolizaRiesgo = x.PolizaRiesgo,
                    PolizaRiesgoNombre = x.Riesgo.RiesgoDescripcion,
                    PolizaCubrimientos = x.PolizaCoberturas.Select(c => new Entities.Cubrimiento
                    {
                        CubrimientoId = c.CoberturaId,
                        CubrimientoDescripcion = c.Cubrimiento.CubrimientoDescripcion,
                        Porcentaje = c.Porcentaje
                    }).ToList()
                }).ToList();
            }
        }
    }
}
