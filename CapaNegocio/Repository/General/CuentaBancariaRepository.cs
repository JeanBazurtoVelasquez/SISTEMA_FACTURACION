using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Models.General;

namespace CapaNegocio.Repository.General
{
    public class CuentaBancariaRepository: IRepository<CuentaBancaria>
    {
        public  async Task<CuentaBancaria> Get(int id)
        {
            CuentaBancaria retorno = new CuentaBancaria();
            try
            {
            }
            catch (Exception ex) { }
            return retorno;
        }
        public async Task<List<CuentaBancaria>> GetList(string filter = "")
        {
            List<CuentaBancaria> retorno = new List<CuentaBancaria>();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }
        public async Task<bool> Save(CuentaBancaria model)
        {
            bool retorno = false;
            try
            {

            }
            catch (Exception e) { }
            return retorno;
        }
        public async Task<bool> Delete(int idcuenta)
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
