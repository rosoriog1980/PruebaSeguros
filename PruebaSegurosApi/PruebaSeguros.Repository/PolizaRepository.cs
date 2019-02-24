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
            using (PolizasDBEntities context = new PolizasDBEntities())
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
            using (PolizasDBEntities context = new PolizasDBEntities())
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

        public int InsertPoliza(Entities.Poliza poliza)
        {
            try
            {

                using (PolizasDBEntities context = new PolizasDBEntities())
                {
                    Poliza _poliza = new Poliza();
                    _poliza.PolizaId = context.Poliza.Max(x => x.PolizaId) + 1;
                    _poliza.PolizaNombre = poliza.PolizaNombre;
                    _poliza.PolizaDescripcion = poliza.PolizaDescripcion;
                    _poliza.PolizaInicio = poliza.PolizaInicio;
                    _poliza.PolizaPeriodoCobertura = poliza.PolizaPeriodoCobertura;
                    _poliza.PolizaPrecio = poliza.PolizaPrecio;
                    _poliza.PolizaRiesgo = poliza.PolizaRiesgo;

                    context.Poliza.Add(_poliza);

                    foreach (var item in poliza.PolizaCubrimientos)
                    {
                        context.PolizaCoberturas.Add(new PolizaCoberturas
                        {
                            PolizaId = _poliza.PolizaId,
                            CoberturaId = item.CubrimientoId,
                            Porcentaje = item.Porcentaje
                        });
                    }

                    context.SaveChanges();
                    return _poliza.PolizaId;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        
    }
}
