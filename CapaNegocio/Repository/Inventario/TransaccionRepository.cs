using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class TransaccionRepository : IRepository<Transaccion>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaccion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaccion>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Transaccion model)
        {
            throw new NotImplementedException();
        }
    }
}
