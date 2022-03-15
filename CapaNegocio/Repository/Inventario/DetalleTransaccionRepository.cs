using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class DetalleTransaccionRepository : IRepository<DetalleTransaccion>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleTransaccion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleTransaccion>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(DetalleTransaccion model)
        {
            throw new NotImplementedException();
        }
    }
}
