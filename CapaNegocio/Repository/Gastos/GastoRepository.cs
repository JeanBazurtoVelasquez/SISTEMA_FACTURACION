using CapaNegocio.Models.Gastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Gastos
{
    public class GastoRepository : IRepository<Gasto>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Gasto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gasto>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Gasto model)
        {
            throw new NotImplementedException();
        }
    }
}
