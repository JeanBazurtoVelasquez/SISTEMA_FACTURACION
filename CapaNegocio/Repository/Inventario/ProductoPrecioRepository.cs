using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class ProductoPrecioRepository : IRepository<ProductoPrecio>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoPrecio> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoPrecio>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(ProductoPrecio model)
        {
            throw new NotImplementedException();
        }
    }
}
