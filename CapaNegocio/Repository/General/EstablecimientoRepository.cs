using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models;

namespace CapaNegocio.Repository.General
{
    public class EstablecimientoRepository : IRepository<Establecimiento>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Establecimiento> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Establecimiento>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Establecimiento model)
        {
            throw new NotImplementedException();
        }
    }
}
