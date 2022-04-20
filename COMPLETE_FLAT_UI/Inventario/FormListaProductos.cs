using CapaNegocio.Models.Inventario;
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
    public partial class FormListaProductos : Form
    {
        ProductoRepository productoRepo = new ProductoRepository();
        ProductoPrecioRepository precioRepo = new ProductoPrecioRepository();
        string path = Application.StartupPath + "\\images";
        bool _modoBusqueda = false;
        string _filtro = "";
        public int _idproducto = 0;
        public FormListaProductos()
        {
            InitializeComponent();
        }
        public FormListaProductos(bool modoBusqueda, string filtro)
        {
            _modoBusqueda = modoBusqueda;
            _filtro = filtro;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormListaClientes hijo = new FormListaClientes();
            AddOwnedForm(hijo);
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            this.Controls.Add(hijo);
            this.Tag = hijo;
            hijo.BringToFront();
           
            hijo.Show();  
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMembresia_Load(object sender, EventArgs e)
        {
            btnNuevo.Visible = !_modoBusqueda;
            btnEditar.Visible = !_modoBusqueda;
            btnEliminar.Visible = !_modoBusqueda;
            cmbEstado.SelectedIndex = 0;
            cmbEstado.Enabled = !_modoBusqueda;
            if (_modoBusqueda)
                txtFiltro.Text = _filtro;
            CargarDatos();
            dgvProductos.Focus();
        }

        private async void CargarDatos()
        {
            dgvProductos.DataSource = await productoRepo.GetListProduct(txtFiltro.Text.ToLower().Trim(), cmbEstado.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantProductos frmMantProducto = new FormMantProductos();
            if (frmMantProducto.ShowDialog() == DialogResult.OK)
                CargarDatos();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow.Index < 0)
                    MessageBox.Show("Seleccione un registro para editar");
                else
                {
                    var prod = await productoRepo.Get((int)dgvProductos.CurrentRow.Cells[0].Value);

                    FormMantProductos frmMantProducto = new FormMantProductos(prod);
                    if (frmMantProducto.ShowDialog() == DialogResult.OK)
                        CargarDatos();
                    else
                    {
                        dgvProductos.Rows[dgvProductos.CurrentRow.Index].Selected = true;
                        dgvProductos.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow.Index < 0)
                    MessageBox.Show("Seleccione un registro para editar");
                else 
                {
                    var nameProd = (string)dgvProductos.CurrentRow.Cells[3].Value;
                    var id = (int)dgvProductos.CurrentRow.Cells[0].Value;
                    var estadoAct = (string)dgvProductos.CurrentRow.Cells[10].Value;
                    if (MessageBox.Show("¿Está seguro que desea cambiar el estado?", nameProd, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (await productoRepo.CambiaEstado(id, !estadoAct.Equals("ACTIVO")))
                        {
                            MessageBox.Show("Se cambió el estado de " + nameProd);
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CargarDatos();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarDatos();
        }

        private void cmbEstado_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && dgvProductos.RowCount > 0)
                {
                    btnEliminar.Text = dgvProductos.Rows[e.RowIndex].Cells[10].Value.ToString().Equals("ACTIVO") ? "Eliminar" : "Activar";
                    await precioRepo.FillGridByProducto(dgvPrecios, (int)dgvProductos.Rows[e.RowIndex].Cells[0].Value);
                    try
                    {
                        picImage.Image = null;
                        string image = dgvProductos.Rows[e.RowIndex].Cells[11].Value.ToString();
                        if (!image.Equals("") && File.Exists(Global._path_image_productos + @"\" + image))
                            picImage.Load(Global._path_image_productos + @"\" + image);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if(dgvProductos.CurrentRow.Index >= 0 && e.KeyCode == Keys.Enter)
            {
                if (_modoBusqueda)
                {
                    _idproducto = (int)dgvProductos.CurrentRow.Cells[0].Value;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    btnEditar_Click(btnEditar, null);
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    dgvProductos.Focus();
            }catch(Exception ex) { }
        }
    }
}
