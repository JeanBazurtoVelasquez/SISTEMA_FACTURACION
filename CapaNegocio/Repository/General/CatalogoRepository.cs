using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models.General;
using CapaNegocio.Repository;
using CapaNegocio.Utils;
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
            List<Catalogo> catalogos = new List<Catalogo>();
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    using (var cmd = new NpgsqlCommand("select * from catalogo where codigopadre = @codigopadre order by descripcion", sql))
                    {
                        cmd.Parameters.AddWithValue("@codigopadre", codigopadre);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var catalogo = new Catalogo();
                                catalogo.Id = reader["id"] != System.DBNull.Value ? (int)reader["id"] : 0;
                                catalogo.Codigo = reader["codigo"] != System.DBNull.Value ? (string)reader["codigo"] : "";
                                catalogo.Descripcion = reader["descripcion"] != System.DBNull.Value ? (string)reader["descripcion"] : "";
                                catalogo.Codigopadre = reader["codigopadre"] != System.DBNull.Value ? (string)reader["codigopadre"] : "";
                                catalogos.Add(catalogo);
                            }
                        }
                    }
                }
                return catalogos;
            }
            catch (NpgsqlException e) { System.Windows.Forms.MessageBox.Show(e.Message); return null; }
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
