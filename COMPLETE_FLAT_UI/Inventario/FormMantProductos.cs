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
using System.IO;
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
        ProductoPrecioRepository precioRepo = new ProductoPrecioRepository();
        int _idproducto;
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
            Utilidades.LlenaComboEstablecimiento(cmbEstablecimiento);
            if (cmbCategoria.SelectedItem != null)
                Utilidades.LlenaComboCatalogo(cmbSubCategoria, ((Catalogo)cmbCategoria.SelectedItem).id.ToString());
            
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
                //cmbEmpresa.SelectedValue = miProducto.Empresaid;
                //cmbMarca.SelectedValue = miProducto.Marcaid;
                //cmbCategoria.SelectedValue = miProducto.Categoriaid;
                chkIva.Checked = miProducto.Grabaiva;
                Utilidades.LlenaComboEmpresa(cmbEmpresa, miProducto.Empresaid);
                Utilidades.LlenaComboCatalogo(cmbMarca, "MARCA", miProducto.Marcaid);
                Utilidades.LlenaComboCatalogo(cmbCategoria, "CATEGORIA", miProducto.Categoriaid);
                Utilidades.LlenaComboCatalogo(cmbSubCategoria, miProducto.Categoriaid.ToString(), miProducto.Subcategoriaid);

                if (miProducto.image != null && !miProducto.image.Equals("") && File.Exists(Global._path_image_productos + @"\" + miProducto.image))
                    picImagen.Load(Global._path_image_productos + @"\" + miProducto.image);
            }
            cmbEstablecimiento.SelectedValue = null;
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

                if(picImagen.Image != null && (miProducto.image == null || miProducto.image.Equals("")))
                    miProducto.image = Guid.NewGuid().ToString() + ".png"; ;

                if (await productoRepo.Save(miProducto)) {
                    if (picImagen.Image != null)
                    {
                        if (!Directory.Exists(Global._path_image_productos))
                            Directory.CreateDirectory(Global._path_image_productos);
                            
                        picImagen.Image.Save(Global._path_image_productos + @"\" + miProducto.image);
                    }
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
                Utilidades.LlenaComboCatalogo(cmbSubCategoria, ((Catalogo)cmbCategoria.SelectedItem).id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void cmbEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvPrecios.Rows.Clear();
            if ((int)cmbEstablecimiento.SelectedValue == 0)
                return;
            await precioRepo.FillGrid(dgvPrecios, miProducto.Id, (int)cmbEstablecimiento.SelectedValue);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPrecios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void dgvPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && miProducto != null && miProducto.Id > 0)
                {
                    var iRow = dgvPrecios.Rows[e.RowIndex];
                    var miPrecio = new ProductoPrecio();
                    miPrecio.Id = (int)iRow.Cells[0].Tag;
                    miPrecio.Productoid = miProducto.Id;
                    miPrecio.Establecimientoid = (int)cmbEstablecimiento.SelectedValue;
                    miPrecio.Unidadid = (int)iRow.Cells[1].Tag;
                    miPrecio.Precio1 = Convert.ToDecimal(iRow.Cells[1].Value);
                    miPrecio.Precio2 = Convert.ToDecimal(iRow.Cells[2].Value);
                    miPrecio.Precio3 = Convert.ToDecimal(iRow.Cells[3].Value);
                    miPrecio.Precio4 = Convert.ToDecimal(iRow.Cells[4].Value);
                    miPrecio.Precio5 = Convert.ToDecimal(iRow.Cells[5].Value);

                    int res = await precioRepo.SaveSP(miPrecio);
                    if (res > 0)
                    {
                        dgvPrecios.Rows[e.RowIndex].Cells[0].Tag = res;
                        MessageBox.Show("Precio guardado correctamente");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "Todos los archivos (*. *) | *. *";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    string Pathname = file.FileName; // Obtenga la ruta absoluta del archivo
                    this.picImagen.Load(Pathname);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
