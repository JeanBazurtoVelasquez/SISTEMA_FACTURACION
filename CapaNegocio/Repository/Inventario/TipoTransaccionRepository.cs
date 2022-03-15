using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class TipoTransaccionRepository : IRepository<TipoTransaccion>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoTransaccion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TipoTransaccion>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(TipoTransaccion model)
        {
            throw new NotImplementedException();
        }
    }
}
