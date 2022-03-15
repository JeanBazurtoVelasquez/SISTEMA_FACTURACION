using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class ProductoRepository : IRepository<Producto>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Producto model)
        {
            throw new NotImplementedException();
        }
    }
}
