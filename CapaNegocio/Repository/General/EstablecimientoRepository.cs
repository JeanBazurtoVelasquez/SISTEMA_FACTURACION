using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models;
using CapaNegocio.Utils;
using Dapper;
using Npgsql;

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

        public async Task<List<Establecimiento>> GetList(string filter = "")
        {
            var items = new List<Establecimiento>();
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    string query = "SELECT * FROM establecimiento";
                    var result = await cnn.QueryAsync<Establecimiento>(query, null);
                    items = result.ToList();
                }
                return items;
            }
            catch (NpgsqlException e) { return null; }
        }

        public Task<bool> Save(Establecimiento model)
        {
            throw new NotImplementedException();
        }
    }
}
