using CapaNegocio.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Repository.General;
using CapaNegocio.Models.General;
using COMPLETE_FLAT_UI.Inventario;

namespace COMPLETE_FLAT_UI
{
    public partial class FormMenuPrincipal : Form
    {
        PersonaRepository personasRepo = new PersonaRepository();
        List<Persona> personasModel = new List<Persona>();
        //Constructor
        public FormMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            LeerConfig();
        }
        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
       
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO------------------------------------------------------
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //METODOS PARA ANIMACION DE MENU SLIDING--
        private void btnMenu_Click(object sender, EventArgs e)
        {
            //-------CON EFECTO SLIDING
            if (panelMenu.Width == 230)
            {
                this.tmContraerMenu.Start();
                ShowHidePerfil(false);
            }
            else if (panelMenu.Width == 50)
            {
                this.tmExpandirMenu.Start();
                ShowHidePerfil();
            }

            //-------SIN EFECTO 
            //if (panelMenu.Width == 55)
            //{
            //    panelMenu.Width = 230;
            //}
            //else

            //    panelMenu.Width = 55;
        }

        private void ShowHidePerfil(bool show = true)
        {
            pbImageUser.Visible = show;
            lblNombreUser.Visible = show;
            lblPerfilUser.Visible = show;
            lbFecha.Visible = show;
            lblHora.Visible = show;
        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 15;
            
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 50)
                this.tmContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 15;
        }

        //METODO PARA ABRIR FORM DENTRO DE PANEL-----------------------------------------------------
        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;            
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }
        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al INICIAR ----------------------------------------------------------
        private void MostrarFormLogo()
        {
            AbrirFormEnPanel(new FormLogo());
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
        }
        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al CERRAR OTROS FORM ----------------------------------------------------------
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }
        //METODOS PARA ABRIR OTROS FORMULARIOS Y MOSTRAR FORM DE LOGO Al CERRAR ----------------------------------------------------------
        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            FormListaClientes fm = new FormListaClientes();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            FormListaProductos frm = new FormListaProductos();
            frm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(frm);
        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        //METODO PARA HORA Y FECHA ACTUAL ----------------------------------------------------------
        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormRegCompra fm = new FormRegCompra();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            FormRegCompra frm = new FormRegCompra();
            frm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(frm);
        }

        private void btnPuntoVenta_Click(object sender, EventArgs e)
        {

            FormPuntoVenta frm = new FormPuntoVenta();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Form1());
        }

        public void LeerConfig()
        {
            string linea = "";
            var file = new StreamReader(Application.StartupPath + @"\config.txt");
            if (file != null)
            {
                linea = file.ReadToEnd();
                var objConfig = JsonConvert.DeserializeObject<JObject>(linea);
                if (objConfig != null)
                {
                    var objCnn = objConfig.GetValue("connection_db").ToObject<JObject>();
                    Global._connectionString = "Server=" + objCnn.GetValue("Server")
                                                + ";Port=" + objCnn.GetValue("Port")
                                                + ";User Id=" + objCnn.GetValue("User")
                                                + ";Password=" + objCnn.GetValue("Password")
                                                + ";Database=" + objCnn.GetValue("Database") + ";";
                    Global.URLDatosCI = objConfig.GetValue("URLDatosCI").ToString();
                }
                file.Close();
            }

            Global._path_image_productos = Application.StartupPath + @"\images\producto";
        }
    }
}
