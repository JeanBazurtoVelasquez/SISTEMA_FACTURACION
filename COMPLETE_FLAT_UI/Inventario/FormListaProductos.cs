using CapaNegocio.Models.Inventario;
using CapaNegocio.Repository.Inventario;
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
    public partial class FormListaProductos : Form
    {
        ProductoRepository productoRepo = new ProductoRepository();
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
            CargarDatos();
        }

        private async void CargarDatos()
        {
            dgvProductos.DataSource = await productoRepo.GetList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantProductos frmMantProducto = new FormMantProductos();
            frmMantProducto.WindowState = FormWindowState.Maximized;
            if (frmMantProducto.ShowDialog() == DialogResult.OK)
                CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow.Index < 0)
                    MessageBox.Show("Seleccione un registro para editar");
                else
                {
                    var ls = (List<Producto>)dgvProductos.DataSource;
                    if (ls != null)
                    {
                        var prod = ls[dgvProductos.CurrentRow.Index];
                        FormMantProductos frmMantProducto = new FormMantProductos(prod);
                        frmMantProducto.WindowState = FormWindowState.Maximized;
                        if (frmMantProducto.ShowDialog() == DialogResult.OK)
                            CargarDatos();
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
                    var ls = (List<Producto>)dgvProductos.DataSource;
                    var prod = ls[dgvProductos.CurrentRow.Index];
                    if (MessageBox.Show("¿Está seguro que desea cambiar el estado?", prod.Nombre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (await productoRepo.CambiaEstado(prod.Id, !prod.Estado))
                        {
                            MessageBox.Show("Se cambió el estado de " + prod.Nombre);
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
    }
}
