using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Models.General;
using CapaNegocio.Repository.General;

namespace COMPLETE_FLAT_UI
{
    public partial class FormListaClientes : Form
    {
        PersonaRepository personasRepo = new PersonaRepository();
        public FormListaClientes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            cmbTipoPersona.ValueMember = "id";
            cmbTipoPersona.DisplayMember = "descripcion";
            cmbTipoPersona.DataSource = personasRepo.GetTipoPersona();
            cmbTipoPersona.SelectedIndex = -1;
            InsertarFilas();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (tblClientes.SelectedRows.Count > 0)
            {
                var persona = new Persona();
                persona = await personasRepo.Get(id: (int) tblClientes.CurrentRow.Cells[0].Value);
                FormMantCliente frm = new FormMantCliente(persona);
                frm.ShowDialog();
             
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            /*var persona = new Persona();
            persona.Id = 0;
            FormMantCliente frm = new FormMantCliente(persona);
            frm.ShowDialog();*/
            FormPuntoVenta frm = new FormPuntoVenta();
            frm.ShowDialog();
        }

        private async void InsertarFilas()
        {
            tblClientes.DataSource = await personasRepo.ListarPersonasAsync(cmbTipoPersona.GetItemText(cmbTipoPersona.SelectedItem), txtBuscar.Text);
            for (int i = 0; i < tblClientes.Columns.Count; i++)
            {
                tblClientes.Columns[i].HeaderText = ((tblClientes.Columns[i].HeaderText).ToUpper()).Replace("_"," ");
            }
        }
        
        private void ResizeControls()
        {
            //tblClientes.Width = Width - 200;
            //tblClientes.Height = Height - 150;
            panel1.Width = Width - 200;
            panel1.Height = Height - 150;
        }

        private void FormListaClientes_Resize(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void FormListaClientes_Shown(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            InsertarFilas();
        }

        private void cmbTipoPersona_TextChanged(object sender, EventArgs e)
        {
            InsertarFilas();
        }
    }
}
