using CapaNegocio.Models.Inventario;
using CapaNegocio.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Newtonsoft.Json.Linq;

namespace CapaNegocio.Repository.Inventario
{
    public class ProductoPrecioRepository : IRepository<ProductoPrecio>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoPrecio> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoPrecio>> GetList(string filter = "")
        {
            throw new NotImplementedException();
        }
        public Task<bool> Save(ProductoPrecio model) {
            throw new Exception();
        }

        public async Task<int> SaveSP(ProductoPrecio model)
        {
            var retorno = 0;
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    cnn.Open();
                    using (var cmd = new NpgsqlCommand("fnguardaproductoprecio", cnn))
                    {
                        cmd.Parameters.AddWithValue("_id", model.Id);
                        cmd.Parameters.AddWithValue("_productoid", model.Productoid);
                        cmd.Parameters.AddWithValue("_establecimientoid", model.Establecimientoid);
                        cmd.Parameters.AddWithValue("_unidadid", model.Unidadid);
                        cmd.Parameters.AddWithValue("_precio1", model.Precio1);
                        cmd.Parameters.AddWithValue("_precio2", model.Precio2);
                        cmd.Parameters.AddWithValue("_precio3", model.Precio3);
                        cmd.Parameters.AddWithValue("_precio4", model.Precio4);
                        cmd.Parameters.AddWithValue("_precio5", model.Precio5);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                                retorno = await reader.IsDBNullAsync(0) ? -1 : reader.GetInt32(0);
                        }
                    }

                }
                return retorno;
            }
            catch (Exception e)
            {
                return 0;
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> FillGrid(DataGridView dgv, int productoid = 0, int establecimientoid = 0)
        {
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    string query = "select coalesce(up.id, 0) as precioid, un.id as unidadid, un.descripcion, coalesce(up.precio1, 0) as precio1, coalesce(up.precio2, 0) precio2, " +
                        "coalesce(up.precio3, 0) as precio3, coalesce(up.precio4, 0) as precio4, coalesce(up.precio5, 0) as precio5 " +
                        "from catalogo un " +
                        "left join productoprecio up on up.unidadid = un.id and up.establecimientoid = @varestablecimiento " +
                        "and up.productoid = @varproducto where un.codigopadre = 'UNIDAD'";
                    /*var param = new DynamicParameters();
                    param.Add("@varproducto", productoid);
                    param.Add("@varestablecimiento", establecimientoid);
                    var result = await sql.QueryAsync<object>(query, param);
                    if (result != null) {
                        var lista = result.ToList();
                        JObject obj = (JObject)lista[0];
                        dgv.Rows.Clear();
                        dgv.Rows.Add();
                        dgv.Rows[dgv.RowCount - 1].Cells[0].Value = obj.GetValue("descripcion").ToString() ?? "";
                    }*/
                    using (var cmd = new NpgsqlCommand(query, sql))
                    {
                        cmd.Parameters.AddWithValue("@varestablecimiento", establecimientoid);
                        cmd.Parameters.AddWithValue("@varproducto", productoid);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            int i = 0;
                            while (await reader.ReadAsync())
                            {
                                dgv.Rows.Add(1);
                                dgv.Rows[i].Cells[0].Tag = reader["precioid"] != DBNull.Value ? (int)reader["precioid"] : 0;
                                dgv.Rows[i].Cells[0].Value = reader["descripcion"] != DBNull.Value ? (string)reader["descripcion"] : "";
                                dgv.Rows[i].Cells[1].Tag = reader["unidadid"] != DBNull.Value ? (int)reader["unidadid"] : 0;
                                dgv.Rows[i].Cells[1].Value = reader["precio1"] != DBNull.Value ? reader["precio1"] : 0;
                                dgv.Rows[i].Cells[2].Value = reader["precio2"] != DBNull.Value ? reader["precio2"] : 0;
                                dgv.Rows[i].Cells[3].Value = reader["precio3"] != DBNull.Value ? reader["precio3"] : 0;
                                dgv.Rows[i].Cells[4].Value = reader["precio4"] != DBNull.Value ? reader["precio4"] : 0;
                                dgv.Rows[i].Cells[5].Value = reader["precio5"] != DBNull.Value ? reader["precio5"] : 0;
                                i++;
                            }
                        }
                    }
                }
                return true;
            }
            catch (NpgsqlException e) { return false; }
        }

        public async Task<bool> FillGridByProducto(DataGridView dgv, int productoid)
        {
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    string query = "select coalesce(up.id, 0) as precioid, un.id as unidadid, un.descripcion, coalesce(up.precio1, 0) as precio1, coalesce(up.precio2, 0) precio2, " +
                        "coalesce(up.precio3, 0) as precio3, coalesce(up.precio4, 0) as precio4, coalesce(up.precio5, 0) as precio5 " +
                        ", coalesce(es.nombre,'') as establecimiento " +
                        "from productoprecio up " +
                        "join catalogo un on up.unidadid = un.id and un.codigopadre = 'UNIDAD'" +
                        "join establecimiento es on es.id = up.establecimientoid " +
                        "WHERE up.productoid = @varproducto";

                    using (var cmd = new NpgsqlCommand(query, sql))
                    {
                        cmd.Parameters.AddWithValue("@varproducto", productoid);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            dgv.Rows.Clear();
                            int i = 0;
                            while (await reader.ReadAsync())
                            {
                                dgv.Rows.Add(1);
                                dgv.Rows[i].Cells[0].Value = reader["establecimiento"] != DBNull.Value ? (string)reader["establecimiento"] : "";
                                dgv.Rows[i].Cells[1].Value = reader["descripcion"] != DBNull.Value ? (string)reader["descripcion"] : "";
                                dgv.Rows[i].Cells[2].Value = reader["precio1"] != DBNull.Value ? reader["precio1"] : 0;
                                dgv.Rows[i].Cells[3].Value = reader["precio2"] != DBNull.Value ? reader["precio2"] : 0;
                                dgv.Rows[i].Cells[4].Value = reader["precio3"] != DBNull.Value ? reader["precio3"] : 0;
                                dgv.Rows[i].Cells[5].Value = reader["precio4"] != DBNull.Value ? reader["precio4"] : 0;
                                dgv.Rows[i].Cells[6].Value = reader["precio5"] != DBNull.Value ? reader["precio5"] : 0;
                                i++;
                            }
                        }
                    }
                }
                return true;
            }
            catch (NpgsqlException e) { return false; }
        }

        public static async Task<List<ProductoPrecio>> ListByEstablecimiento(int productoid, int establecimientoid)
        {
            List<ProductoPrecio> lista = new List<ProductoPrecio>();
            try
            {
                using (var cnn = new NpgsqlConnection(Global._connectionString))
                {
                    string query = "select up.id, up.unidadid, up.establecimientoid, un.descripcion as unidaddescripcion, " +
                        "coalesce(up.precio1, 0) as precio1, coalesce(up.precio2, 0) as precio2, " +
                        "coalesce(up.precio3, 0) as precio3, coalesce(up.precio4, 0) as precio4, coalesce(up.precio5, 0) as precio5 " +
                        "from productoprecio up " +
                        "join catalogo un on up.unidadid = un.id and un.codigopadre = 'UNIDAD' "+
                        "WHERE up.productoid = @varproducto and up.establecimientoid = @varestablecimiento";
                    var param = new DynamicParameters();
                    param.Add("@varproducto", productoid);
                    param.Add("@varestablecimiento", establecimientoid);

                    var result = await cnn.QueryAsync<ProductoPrecio>(query, param);
                    lista = result.ToList();

                }
                return lista;
            }
            catch (NpgsqlException e) { throw new Exception(e.Message); }
        }
    }
}
