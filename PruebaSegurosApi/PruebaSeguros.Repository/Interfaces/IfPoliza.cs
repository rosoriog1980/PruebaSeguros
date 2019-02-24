using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSeguros.Entities;


namespace PruebaSeguros.Repository.Interfaces
{
    public interface IfPoliza
    {
        List<Entities.Poliza> GetPolizas();
        Entities.Poliza GetPoliza(int id);
        int InsertPoliza(Entities.Poliza poliza);
    }
}
