using CapaNegocio.Models.General;
using CapaNegocio.Repository.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FormMantCliente : Form
    {
        PersonaRepository personasRepo = new PersonaRepository();
        CatalogoRepository catalogoRepo = new CatalogoRepository();
        Persona personaEdit = new Persona();
        public FormMantCliente(Persona persona)
        {
            InitializeComponent();
            personaEdit = persona;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMantCliente_Load(object sender, EventArgs e)
        {
            txtid.Text = personaEdit.Id.ToString();

            cmbTipoPersona.ValueMember = "id";
            cmbTipoPersona.DisplayMember = "descripcion";
            cmbTipoPersona.DataSource = personasRepo.GetTipoPersona();
            cmbTipoPersona.SelectedIndex = 0;
            llenaCombos();
            if (personaEdit.Id > 0)
            {
                txtNip.Text       = personaEdit.Nip;
                txtnombre.Text    = personaEdit.Nombres;
                txtapellido.Text  = personaEdit.Apellidos;
                txtdireccion.Text = personaEdit.Direccion ?? "";
                txttelefono.Text  = personaEdit.Telefono ?? "";
                txtCorreo.Text    = personaEdit.Correo ?? "";
                txtFechaNacimiento.Value =  DateTime.ParseExact(personaEdit.Fechanacimiento.Split(' ')[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cmbTipoPersona.SelectedValue = personaEdit.Tipopersonaid;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            personaEdit.Nip = txtNip.Text;
            personaEdit.Ruc = "";
            personaEdit.Nombres = txtnombre.Text;
            personaEdit.Apellidos = txtapellido.Text  ;
            personaEdit.Direccion = txtdireccion.Text ;
            personaEdit.Parroquiaid = 0;
            personaEdit.Telefono = txttelefono.Text;
            personaEdit.Correo = txtCorreo.Text;
            personaEdit.Fechanacimiento = txtFechaNacimiento.Value.ToShortDateString();
            personaEdit.Tipopersonaid = (int) cmbTipoPersona.SelectedValue;
            personaEdit.Tiponip = (short) Convert.ToInt32(cmbTipoNip.SelectedValue);
            personaEdit.Sexo = Convert.ToInt32(cmbSexo.SelectedValue);
            guardarPersona();
        }

        private async void llenaCombos() {
            cmbTipoNip.ValueMember = "codigo";
            cmbTipoNip.DisplayMember = "descripcion";
            cmbTipoNip.DataSource = await catalogoRepo.GetList("TIPONIP");
            cmbTipoNip.SelectedIndex = 0;

            cmbSexo.ValueMember = "codigo";
            cmbSexo.DisplayMember = "descripcion";
            cmbSexo.DataSource = await catalogoRepo.GetList("SEXO");
            cmbSexo.SelectedIndex = 0;
            if (personaEdit.Id > 0) { 
                cmbTipoNip.SelectedValue = personaEdit.Tiponip.ToString();
                cmbSexo.SelectedValue = personaEdit.Sexo.ToString();
            }
        }

        private async void guardarPersona() {
            if (await personasRepo.Save(personaEdit))
            {
                if (MessageBox.Show("Información registrada correctamente", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK) {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No se ha podido registrar la información");
            }
        }
    }
}
