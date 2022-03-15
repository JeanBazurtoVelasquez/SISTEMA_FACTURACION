using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models.General;
using CapaNegocio.Repository;

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
        public async Task<List<Catalogo>> GetList(string filter = "")
        {
            List<Catalogo> retorno = new List<Catalogo>();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
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
