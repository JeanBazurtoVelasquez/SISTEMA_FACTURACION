using CapaNegocio.Repository.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio.Utils
{
    public class Utilidades
    {
        public async static void LlenaComboEmpresa(ComboBox combo, object value = null) {
            try
            {
                var _repo = new EmpresaRepository();
                var datos = await _repo.GetList();
                combo.DataSource = datos;
                combo.DisplayMember = "nombre";
                combo.ValueMember = "id";
                if (value != null)
                    combo.SelectedValue = value;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public async static void LlenaComboCatalogo(ComboBox combo, string codigopadre, object value = null)
        {
            try
            {
                var _repo = new CatalogoRepository();
                var datos = await _repo.GetList(codigopadre);
                combo.DataSource = datos;
                combo.DisplayMember = "descripcion";
                combo.ValueMember = "id";
                if (value != null)
                    combo.SelectedValue = value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
