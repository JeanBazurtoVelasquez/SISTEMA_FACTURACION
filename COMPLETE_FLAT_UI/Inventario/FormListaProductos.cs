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
        public FormListaProductos()
        {
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
            cmbEstado.SelectedIndex = 0;
            CargarDatos();
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
                catch (Exception ex) {
                    //Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

    }
}
