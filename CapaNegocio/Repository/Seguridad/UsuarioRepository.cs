using CapaNegocio.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository.Seguridad
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Usuario model)
        {
            throw new NotImplementedException();
        }
    }
}
