using CapaNegocio.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.General
{
    public class TipoPersonaRepository : IRepository<TipoPersona>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoPersona> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TipoPersona>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(TipoPersona model)
        {
            throw new NotImplementedException();
        }
    }
}
