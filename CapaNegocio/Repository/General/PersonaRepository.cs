using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Models.General;
using CapaNegocio.Utils;
using Npgsql;

namespace CapaNegocio.Repository.General
{
    public class PersonaRepository : IRepository<Persona>
    {
        public Task<bool> Delete(int id)
        {
            //Esto es un comentario desde Rama: dev_Andres, prueba
            throw new NotImplementedException();
        }

        public async Task<Persona> Get(int id)
        {
            var persona = new Persona();
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    //Prueba nomas
                    using (var cmd = new NpgsqlCommand($"select * from persona where id = :valor", sql))
                    {
                        cmd.Parameters.AddWithValue(":valor", id);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                            {
                                persona.Id = reader["id"] != System.DBNull.Value ? (int)reader["id"] : 0;
                                persona.Tipopersonaid = reader["tipopersonaid"] != System.DBNull.Value ? (int)reader["tipopersonaid"] : 0;
                                persona.Tiponip = (short)(reader["tiponip"] != System.DBNull.Value ? (short)reader["tiponip"] : 0);
                                persona.Nip = reader["nip"] != System.DBNull.Value ? (string)reader["nip"] : "";
                                persona.Ruc = reader["ruc"] != System.DBNull.Value ? (string)reader["ruc"] : "";
                                persona.Nombres = reader["nombres"] != System.DBNull.Value ? (string)reader["nombres"] : "";
                                persona.Apellidos = reader["apellidos"] != System.DBNull.Value ? (string)reader["apellidos"] : "";
                                persona.Parroquiaid = reader["parroquiaid"] != System.DBNull.Value ? (int)reader["parroquiaid"] : 0;
                                persona.Direccion = reader["direccion"] != System.DBNull.Value ? (string)reader["direccion"] : "";
                                persona.Fechanacimiento = reader["fechanacimiento"] != System.DBNull.Value ? reader["fechanacimiento"].ToString() : "";
                                persona.Sexo = reader["sexo"] != System.DBNull.Value ? (int)reader["sexo"] : 0;
                                persona.Telefono = reader["telefono"] != System.DBNull.Value ? (string)reader["telefono"] : "";
                                persona.Correo = reader["correo"] != System.DBNull.Value ? (string)reader["correo"] : "";
                            }
                        }
                    }
                }
                return persona;
            }
            catch (NpgsqlException e) { MessageBox.Show(e.Message); return null; }
        }

        public async Task<List<Persona>> GetList(string filter = "")
        {
            var personas = new List<Persona>();
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    using (var cmd = new NpgsqlCommand("select id, nombres, apellidos, direccion from persona order by nombres", sql))
                    {
                        /*cmd.Parameters.AddWithValue(":tipoaccion", filter.Length > 0 ? "FILTER" : "LISTA");*/
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var persona = new Persona();
                                persona.Id = reader["id"] != System.DBNull.Value ? (int) reader["id"] : 0;
                                persona.Nombres = reader["nombres"] != System.DBNull.Value ? (string) reader["nombres"] : "";
                                persona.Apellidos = reader["apellidos"] != System.DBNull.Value ? (string) reader["apellidos"] : "";
                                persona.Direccion = reader["direccion"] != System.DBNull.Value ? (string)reader["direccion"] : "No tiene direccion";
                                personas.Add(persona);
                            }
                        }
                    }
                }
                return personas;
            }
            catch (NpgsqlException e) { return null; }
        }

        public async Task<bool> Save(Persona persona)
        {
            using (var cnn = new NpgsqlConnection(Global._connectionString))
            {
                cnn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("fnGuardaPersona", cnn))
                    {
                        cmd.Parameters.AddWithValue("_id", persona.Id);
                        cmd.Parameters.AddWithValue("_tipopersona", persona.Tipopersonaid);
                        cmd.Parameters.AddWithValue("_tiponip", persona.Tiponip);
                        cmd.Parameters.AddWithValue("_nip", persona.Nip);
                        cmd.Parameters.AddWithValue("_ruc", persona.Ruc);
                        cmd.Parameters.AddWithValue("_nombres", persona.Nombres);
                        cmd.Parameters.AddWithValue("_apellidos", persona.Apellidos);
                        cmd.Parameters.AddWithValue("_direccion", persona.Direccion);
                        cmd.Parameters.AddWithValue("_parroquia", persona.Parroquiaid);
                        cmd.Parameters.AddWithValue("_sexo", persona.Sexo);
                        cmd.Parameters.AddWithValue("_fechanacimiento", persona.Fechanacimiento);
                        cmd.Parameters.AddWithValue("_telefono", persona.Telefono);
                        cmd.Parameters.AddWithValue("_correo", persona.Correo);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                            {
                                return reader.IsDBNull(0) ? false : reader.GetInt32(0) > 0;
                            }
                        }
                    }
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public List<TipoPersona> GetTipoPersona()
        {
            var tiposPersona = new List<TipoPersona>();

            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    using (var cmd = new NpgsqlCommand("select * from tipopersona", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipoPersona = new TipoPersona();
                                tipoPersona.Id = reader["id"] != System.DBNull.Value ? (int)reader["id"] : 0;
                                tipoPersona.Descripcion = reader["descripcion"] != System.DBNull.Value ? (string)reader["descripcion"] : "";
                                tiposPersona.Add(tipoPersona);
                            }
                            return tiposPersona;
                        }
                    }
                }
            }
            catch (NpgsqlException e) { MessageBox.Show(e.Message); return null; }
        }

        public Persona GetByID(int id)
        {
            var persona = new Persona();
            try
            {
                using (var sql = new NpgsqlConnection(Global._connectionString))
                {
                    using (var cmd = new NpgsqlCommand($"select nombres, apellidos, direccion from persona where id = :valor", sql))
                    {
                        cmd.Parameters.AddWithValue(":valor", id);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read()) { 
                                persona.Nombres = reader["nombres"] != System.DBNull.Value ? (string)reader["nombres"] : "";
                            }
                        }
                    }
                }
                return persona;
            }
            catch (NpgsqlException e) { MessageBox.Show(e.Message); return null; }
        }

        public List<TipoPersona> LlenarCmbTipoPersona()
        {
            return GetTipoPersona();
            /*List<TipoPersona> tiposPersona = GetTipoPersona();
            cmb.ValueMember = "id";
            cmb.DisplayMember = "descripcion";
            cmb.DataSource = tiposPersona;
            cmb.SelectedIndex = -1;*/
        }
    }
}
