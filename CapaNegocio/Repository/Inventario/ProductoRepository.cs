using CapaNegocio.Models.Inventario;
using CapaNegocio.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio.Repository.Inventario
{
    public class ProductoRepository : IRepository<Producto>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetList(string filter = "")
        {
            var productos = new List<Producto>();
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    using (var cmd = new NpgsqlCommand("select * from producto", sql))
                    {
                        /*cmd.Parameters.AddWithValue(":tipoaccion", filter.Length > 0 ? "FILTER" : "LISTA");*/
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            Producto item;
                            while (await reader.ReadAsync())
                            {
                                item = new Producto();
                                item.Id = reader["id"] != DBNull.Value ? (int)reader["id"] : 0;
                                item.Codigo = reader["codigo"] != DBNull.Value ? (string)reader["codigo"] : "";
                                item.Codigobarra = reader["codigobarra"] != DBNull.Value ? (string)reader["codigobarra"] : "";
                                item.Nombre = reader["nombre"] != DBNull.Value ? (string)reader["nombre"] : "";
                                item.Pvp = reader["pvp"] != DBNull.Value ? (decimal)reader["pvp"] : 0;
                                item.Grabaiva = reader["grabaiva"] != DBNull.Value ? (bool)reader["grabaiva"] : false;
                                item.Categoriaid = reader["categoriaid"] != DBNull.Value ? (int)reader["categoriaid"] : 0;
                                item.Subcategoriaid = reader["subcategoriaid"] != DBNull.Value ? (int)reader["subcategoriaid"] : 0;
                                item.Marcaid = reader["marcaid"] != DBNull.Value ? (int)reader["marcaid"] : 0;
                                item.Empresaid = reader["empresaid"] != DBNull.Value ? (int)reader["empresaid"] : 0;
                                item.Estado = reader["estado"] != DBNull.Value ? (bool)reader["estado"] : false;
                                productos.Add(item);
                            }
                        }
                    }
                }
                return productos;
            }
            catch (NpgsqlException e) { return null; }
        }

        public async Task<bool> Save(Producto model)
        {
            var retorno = 0;
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    cnn.Open();
                    using (var cmd = new NpgsqlCommand("fnguardaproducto", cnn))
                    {
                        cmd.Parameters.AddWithValue("_id", model.Id);
                        cmd.Parameters.AddWithValue("_codigo", model.Codigo);
                        cmd.Parameters.AddWithValue("_codigobarra", model.Codigobarra);
                        cmd.Parameters.AddWithValue("_nombre", model.Nombre);
                        cmd.Parameters.AddWithValue("_pvp", model.Pvp);
                        cmd.Parameters.AddWithValue("_grabaiva", model.Grabaiva);
                        cmd.Parameters.AddWithValue("_categoriaid", model.Categoriaid);
                        cmd.Parameters.AddWithValue("_subcategoriaid", model.Subcategoriaid);
                        cmd.Parameters.AddWithValue("_marcaid", model.Marcaid);
                        cmd.Parameters.AddWithValue("_empresaid", model.Empresaid);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                                retorno = await reader.IsDBNullAsync(0) ? -1 : reader.GetInt32(0);
                        }
                    }

                }
                return retorno > 0;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CambiaEstado(int id, bool newestado)
        {
            var retorno = 0;
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    cnn.Open();
                    using (var cmd = new NpgsqlCommand("fnanulaproducto", cnn))
                    {
                        cmd.Parameters.AddWithValue("_id", id);
                        cmd.Parameters.AddWithValue("_estado", newestado);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                                retorno = await reader.IsDBNullAsync(0) ? -1 : reader.GetInt32(0);
                        }
                    }

                }
                return retorno > 0;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
    }
}
