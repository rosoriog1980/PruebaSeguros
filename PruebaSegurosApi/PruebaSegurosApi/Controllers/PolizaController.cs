using PruebaSeguros.Entities;
using PruebaSeguros.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaSegurosApi.Controllers
{
    public class PolizaController : ApiController
    {
        private IfPoliza polizaRepository;

        public PolizaController(IfPoliza _polizaRepository)
        {
            this.polizaRepository = _polizaRepository;
        }

        // GET api/poliza
        public IEnumerable<Poliza> Get()
        {
            return polizaRepository.GetPolizas();
        }

        // GET api/poliza/5
        public Poliza Get(int id)
        {
            return polizaRepository.GetPoliza(id);
        }

        // POST api/poliza
        public int Post([FromBody] Poliza value)
        {
            return polizaRepository.InsertPoliza(value);
        }

        // PUT api/poliza/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/poliza/5
        public void Delete(int id)
        {
        }
    }
}
