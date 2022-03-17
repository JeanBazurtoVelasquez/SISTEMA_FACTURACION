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
            InsertarFilas();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var persona = new Persona();
                persona = await personasRepo.Get(id: (int) dataGridView1.CurrentRow.Cells[0].Value);
                FormMantCliente frm = new FormMantCliente(persona);
                frm.ShowDialog();
             
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var persona = new Persona();
            persona.Id = 0;
            FormMantCliente frm = new FormMantCliente(persona);
            frm.ShowDialog();
        }

        private void InsertarFilas()
        {

            Invoke(new MethodInvoker(async delegate {

                dataGridView1.DataSource = await personasRepo.GetList();

            }));
            /*dataGridView1.Rows.Insert(0, "1", "Rafael", "Fernandez", "AV. Melgar", "56465");*/
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormListaProductos frm = Owner as FormListaProductos;
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
