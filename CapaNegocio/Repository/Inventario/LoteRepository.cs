using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Inventario
{
    public class LoteRepository : IRepository<Lote>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Lote> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lote>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Lote model)
        {
            throw new NotImplementedException();
        }
    }
}
