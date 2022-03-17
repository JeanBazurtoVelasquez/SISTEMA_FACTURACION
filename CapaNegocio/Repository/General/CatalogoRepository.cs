using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models.General;
using CapaNegocio.Repository;
using CapaNegocio.Utils;
using Dapper;
using Npgsql;

namespace CapaNegocio.Repository.General
{
    public class CatalogoRepository : IRepository<Catalogo>
    {
        public async Task<Catalogo> Get(int id)
        {
            Catalogo retorno = null;
            try
            {
            }
            catch (Exception ex) { }
            return retorno;
        }
        public async Task<List<Catalogo>> GetList(string codigopadre = "")
        {
            var items = new List<Catalogo>();
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    string query = "SELECT * FROM catalogo";
                    var param = new DynamicParameters();
                    if (!codigopadre.Equals(""))
                    {
                        query += " WHERE codigopadre = @codigopadre";
                        param.Add("@codigopadre", codigopadre);
                    }
                    var result = await cnn.QueryAsync<Catalogo>(query, param);
                    items = result.ToList();
                }
                return items;
            }
            catch (NpgsqlException e) { return null; }
        }
        public async Task<bool> Save(Catalogo catalogo)
        {
            bool retorno = false;
            try
            {

            }
            catch (Exception e) { }
            return retorno;
        }
        public async Task<bool> Delete(int idcatalogo)
        {
            bool retorno = false;
            try
            {

            }
            catch (Exception e) { }
            return retorno;
        }
        public bool Delete(string codigo)
        {
            bool retorno = false;
            try
            {

            }
            catch (Exception e) { }
            return retorno;
        }
    }
}
