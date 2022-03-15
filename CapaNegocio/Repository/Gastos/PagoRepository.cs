using CapaNegocio.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Gastos
{
    public class PagoRepository : IRepository<Pago>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pago> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pago>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Pago model)
        {
            throw new NotImplementedException();
        }
    }
}
