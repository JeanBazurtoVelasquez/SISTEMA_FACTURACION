using CapaNegocio.Models.Gastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Gastos
{
    public class DetalleGastoRepository : IRepository<DetalleGasto>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleGasto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleGasto>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(DetalleGasto model)
        {
            throw new NotImplementedException();
        }
    }
}
