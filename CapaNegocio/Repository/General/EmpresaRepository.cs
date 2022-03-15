using CapaNegocio.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.General
{
    public class EmpresaRepository : IRepository<Empresa>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empresa>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Empresa model)
        {
            throw new NotImplementedException();
        }
    }
}
