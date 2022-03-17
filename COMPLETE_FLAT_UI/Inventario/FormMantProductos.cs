using CapaNegocio.Models.General;
using CapaNegocio.Models.Inventario;
using CapaNegocio.Repository.General;
using CapaNegocio.Repository.Inventario;
using CapaNegocio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FormMantProductos : Form
    {
        Producto miProducto = new Producto();
        EmpresaRepository empresaRepo = new EmpresaRepository();
        ProductoRepository productoRepo = new ProductoRepository();
        public FormMantProductos()
        {
            InitializeComponent();
        }
        public FormMantProductos(Producto producto)
        {
            InitializeComponent();
            miProducto = producto;
        }
        private void FormMantProductos_Load(object sender, EventArgs e)
        {
            Utilidades.LlenaComboEmpresa(cmbEmpresa);
            Utilidades.LlenaComboCatalogo(cmbMarca, "MARCA");
            Utilidades.LlenaComboCatalogo(cmbCategoria, "CATEGORIA");
            if(cmbCategoria.SelectedItem != null)
                Utilidades.LlenaComboCatalogo(cmbSubCategoria, ((Catalogo)cmbCategoria.SelectedItem).codigo);
            MostrarDatos();
        }

        private void tabInfoGeneral_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MostrarDatos() {
            if (miProducto != null && miProducto.Id > 0) {
                txtid.Text = miProducto.Id.ToString();
                txtCodBarra.Text = miProducto.Codigobarra;
                txtCodigo.Text = miProducto.Codigo;
                txtNombre.Text = miProducto.Nombre;
                txtPrecio.Text = miProducto.Pvp?.ToString("#.##");
                cmbEmpresa.SelectedValue = miProducto.Empresaid;
                cmbMarca.SelectedValue = miProducto.Marcaid;
                cmbCategoria.SelectedValue = miProducto.Categoriaid;
                chkIva.Checked = miProducto.Grabaiva;
                if(cmbCategoria.SelectedItem != null)
                    Utilidades.LlenaComboCatalogo(cmbSubCategoria, ((Catalogo)cmbCategoria.SelectedItem).codigo, miProducto.Subcategoriaid);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (miProducto == null)
                    miProducto = new Producto();

                miProducto.Nombre = txtNombre.Text;
                miProducto.Codigobarra = txtCodBarra.Text;
                miProducto.Codigo = txtCodigo.Text;
                miProducto.Pvp = Decimal.Parse(txtPrecio.Text);
                miProducto.Empresaid = (int)cmbEmpresa.SelectedValue;
                miProducto.Marcaid = ((Catalogo)cmbMarca.SelectedItem).id;
                miProducto.Categoriaid = ((Catalogo)cmbCategoria.SelectedItem).id;
                miProducto.Subcategoriaid = ((Catalogo)cmbSubCategoria.SelectedItem).id;
                miProducto.Grabaiva = chkIva.Checked;

                if (await productoRepo.Save(miProducto)) {
                    MessageBox.Show("La tarea falló exitosamente :v");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Utilidades.LlenaComboCatalogo(cmbSubCategoria, ((Catalogo)cmbCategoria.SelectedItem).codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
