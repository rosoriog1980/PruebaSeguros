using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSeguros.Entities;
using PruebaSeguros.Entities.Enum;

namespace PruebaSeguros.Repository
{
    public class PolizaRepository : Interfaces.IfPoliza
    {
        public int CubrimientosProcess(OperacionEnum op, Entities.Cubrimiento cubrimiento)
        {
            int result = 0;
            switch (op)
            {
                case OperacionEnum.Delete:
                    result = DeleteCubrimiento(cubrimiento.Id);
                    break;
                case OperacionEnum.Insert:
                    result =  InsertCubrimiento(cubrimiento);
                    break;
                case OperacionEnum.Update:
                    break;
                default:
                    break;
            }
            return result;
        }

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
                        Id = c.Id,
                        PolizaId = p.PolizaId,
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
                        Id = c.Id,
                        PolizaId = x.PolizaId,
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

        public int UpdatePoliza(Entities.Poliza poliza)
        {
            try
            {
                using (PolizasDBEntities context = new PolizasDBEntities())
                {
                    var p = context.Poliza.FirstOrDefault(x => x.PolizaId == poliza.PolizaId);

                    p.PolizaNombre = poliza.PolizaNombre;
                    p.PolizaDescripcion = poliza.PolizaDescripcion;
                    p.PolizaInicio = poliza.PolizaInicio;
                    p.PolizaPeriodoCobertura = poliza.PolizaPeriodoCobertura;
                    p.PolizaPrecio = poliza.PolizaPrecio;
                    p.PolizaRiesgo = poliza.PolizaRiesgo;

                    context.SaveChanges();

                    return p.PolizaId;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeletePoliza(int id)
        {
            try
            {
                using (PolizasDBEntities context = new PolizasDBEntities())
                {
                    var p = context.Poliza.FirstOrDefault(x => x.PolizaId == id);
                    context.Poliza.Remove(p);
                    context.SaveChanges();
                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region Private Methods

        private int InsertCubrimiento(Entities.Cubrimiento cubrimiento)
        {
            try
            {
                using (PolizasDBEntities context = new PolizasDBEntities())
                {
                    PolizaCoberturas _cobertura = new PolizaCoberturas() {
                        CoberturaId = cubrimiento.CubrimientoId,
                        PolizaId = cubrimiento.PolizaId,
                        Porcentaje = cubrimiento.Porcentaje
                    };

                    context.PolizaCoberturas.Add(_cobertura);
                    context.SaveChanges();
                    return _cobertura.Id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int DeleteCubrimiento(int id)
        {
            try
            {
                using (PolizasDBEntities context = new PolizasDBEntities())
                {
                    var c = context.PolizaCoberturas.FirstOrDefault(x => x.Id == id);
                    context.PolizaCoberturas.Remove(c);
                    context.SaveChanges();

                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}
