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
                    using (var cmd = new NpgsqlCommand($"select idpersona, nombres, apellidos, direccion from persona where id = :valor", sql))
                    {
                        cmd.Parameters.AddWithValue(":valor", id);
                        cmd.CommandType = System.Data.CommandType.Text;
                        sql.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows && await reader.ReadAsync())
                            {
                                persona.Nombres = reader["nombres"] != System.DBNull.Value ? (string)reader["nombres"] : "";
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
                    using (var cmd = new NpgsqlCommand("select id, nombres, apellidos, direccion from persona", sql))
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

        public Task<bool> Save(Persona model)
        {
            throw new NotImplementedException();
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

        public void LlenarCmbTipoPersona(ComboBox cmb)
        {
            List<TipoPersona> tiposPersona = GetTipoPersona();
            cmb.ValueMember = "id";
            cmb.DisplayMember = "descripcion";
            cmb.DataSource = tiposPersona;
            cmb.SelectedIndex = -1;
        }
    }
}
