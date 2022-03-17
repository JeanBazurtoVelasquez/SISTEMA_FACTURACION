using CapaNegocio.Models.General;
using CapaNegocio.Utils;
using Dapper;
using Npgsql;
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

        public async Task<List<Empresa>> GetList(string filter = "")
        {
            var empresas = new List<Empresa>();
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    var result = await cnn.QueryAsync<Empresa>("SELECT * FROM empresa");
                    empresas = result.ToList();
                }
                return empresas;
            }
            catch (NpgsqlException e) { return null; }
        }

        public Task<bool> Save(Empresa model)
        {
            throw new NotImplementedException();
        }
    }
}
