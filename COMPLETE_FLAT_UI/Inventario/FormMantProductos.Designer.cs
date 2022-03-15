
namespace COMPLETE_FLAT_UI
{
    partial class FormMantProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.epMensaje = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfoGeneral = new System.Windows.Forms.TabPage();
            this.tabPrecios = new System.Windows.Forms.TabPage();
            this.cmbSubCategoria = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIva = new System.Windows.Forms.CheckBox();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.btnImagen = new System.Windows.Forms.Button();
            this.cmbEstablecimiento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMensaje)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInfoGeneral.SuspendLayout();
            this.tabPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.BarraTitulo.Controls.Add(this.label6);
            this.BarraTitulo.Controls.Add(this.BtnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1092, 47);
            this.BarraTitulo.TabIndex = 31;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = global::COMPLETE_FLAT_UI.Properties.Resources.Close;
            this.BtnCerrar.Location = new System.Drawing.Point(1041, 0);
            this.BtnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(51, 47);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(461, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Formulario de Producto";
            // 
            // epMensaje
            // 
            this.epMensaje.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfoGeneral);
            this.tabControl1.Controls.Add(this.tabPrecios);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1092, 650);
            this.tabControl1.TabIndex = 32;
            // 
            // tabInfoGeneral
            // 
            this.tabInfoGeneral.BackColor = System.Drawing.Color.Transparent;
            this.tabInfoGeneral.Controls.Add(this.btnImagen);
            this.tabInfoGeneral.Controls.Add(this.picImagen);
            this.tabInfoGeneral.Controls.Add(this.chkIva);
            this.tabInfoGeneral.Controls.Add(this.txtPrecio);
            this.tabInfoGeneral.Controls.Add(this.label1);
            this.tabInfoGeneral.Controls.Add(this.txtCodigo);
            this.tabInfoGeneral.Controls.Add(this.label14);
            this.tabInfoGeneral.Controls.Add(this.cmbSubCategoria);
            this.tabInfoGeneral.Controls.Add(this.label12);
            this.tabInfoGeneral.Controls.Add(this.cmbCategoria);
            this.tabInfoGeneral.Controls.Add(this.label11);
            this.tabInfoGeneral.Controls.Add(this.cmbMarca);
            this.tabInfoGeneral.Controls.Add(this.label10);
            this.tabInfoGeneral.Controls.Add(this.cmbEmpresa);
            this.tabInfoGeneral.Controls.Add(this.label8);
            this.tabInfoGeneral.Controls.Add(this.txtCodBarras);
            this.tabInfoGeneral.Controls.Add(this.label5);
            this.tabInfoGeneral.Controls.Add(this.txtid);
            this.tabInfoGeneral.Controls.Add(this.btnCancelar);
            this.tabInfoGeneral.Controls.Add(this.btnGuardar);
            this.tabInfoGeneral.Controls.Add(this.label2);
            this.tabInfoGeneral.Controls.Add(this.txtNombre);
            this.tabInfoGeneral.Controls.Add(this.label7);
            this.tabInfoGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabInfoGeneral.Name = "tabInfoGeneral";
            this.tabInfoGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfoGeneral.Size = new System.Drawing.Size(1084, 621);
            this.tabInfoGeneral.TabIndex = 0;
            this.tabInfoGeneral.Text = "Información General";
            this.tabInfoGeneral.Click += new System.EventHandler(this.tabInfoGeneral_Click);
            // 
            // tabPrecios
            // 
            this.tabPrecios.BackColor = System.Drawing.SystemColors.Control;
            this.tabPrecios.Controls.Add(this.dataGridView1);
            this.tabPrecios.Controls.Add(this.panel1);
            this.tabPrecios.Location = new System.Drawing.Point(4, 25);
            this.tabPrecios.Name = "tabPrecios";
            this.tabPrecios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrecios.Size = new System.Drawing.Size(1084, 621);
            this.tabPrecios.TabIndex = 1;
            this.tabPrecios.Text = "Precios";
            // 
            // cmbSubCategoria
            // 
            this.cmbSubCategoria.FormattingEnabled = true;
            this.cmbSubCategoria.Items.AddRange(new object[] {
            "No Definido",
            "Masculino",
            "Femenino"});
            this.cmbSubCategoria.Location = new System.Drawing.Point(613, 229);
            this.cmbSubCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSubCategoria.Name = "cmbSubCategoria";
            this.cmbSubCategoria.Size = new System.Drawing.Size(211, 24);
            this.cmbSubCategoria.TabIndex = 83;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(609, 205);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 82;
            this.label12.Text = "Sub-Categoria:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "No Definido",
            "Masculino",
            "Femenino"});
            this.cmbCategoria.Location = new System.Drawing.Point(358, 229);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(211, 24);
            this.cmbCategoria.TabIndex = 81;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(354, 205);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 80;
            this.label11.Text = "Categoria:";
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Items.AddRange(new object[] {
            "No Definido",
            "Masculino",
            "Femenino"});
            this.cmbMarca.Location = new System.Drawing.Point(34, 229);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(265, 24);
            this.cmbMarca.TabIndex = 79;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(34, 205);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 78;
            this.label10.Text = "Marca:";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Items.AddRange(new object[] {
            "No Definido",
            "Masculino",
            "Femenino"});
            this.cmbEmpresa.Location = new System.Drawing.Point(34, 83);
            this.cmbEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(269, 24);
            this.cmbEmpresa.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(34, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Empresa:";
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarras.Location = new System.Drawing.Point(360, 82);
            this.txtCodBarras.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(209, 26);
            this.txtCodBarras.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(34, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 70;
            this.label5.Text = "ID:";
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(143, 13);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(85, 26);
            this.txtid.TabIndex = 69;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(527, 414);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 43);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(358, 414);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 43);
            this.btnGuardar.TabIndex = 67;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(34, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(34, 157);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(792, 26);
            this.txtNombre.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(354, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 71;
            this.label7.Text = "Código de Barras:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(615, 82);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(209, 26);
            this.txtCodigo.TabIndex = 87;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(609, 58);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 86;
            this.label14.Text = "Código";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(34, 307);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(112, 26);
            this.txtPrecio.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(34, 283);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Precio:";
            // 
            // chkIva
            // 
            this.chkIva.AutoSize = true;
            this.chkIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIva.Location = new System.Drawing.Point(188, 309);
            this.chkIva.Name = "chkIva";
            this.chkIva.Size = new System.Drawing.Size(127, 24);
            this.chkIva.TabIndex = 91;
            this.chkIva.Text = "¿Graba IVA?";
            this.chkIva.UseVisualStyleBackColor = true;
            this.chkIva.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // picImagen
            // 
            this.picImagen.Location = new System.Drawing.Point(845, 82);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(214, 171);
            this.picImagen.TabIndex = 92;
            this.picImagen.TabStop = false;
            // 
            // btnImagen
            // 
            this.btnImagen.Location = new System.Drawing.Point(870, 259);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(161, 23);
            this.btnImagen.TabIndex = 93;
            this.btnImagen.Text = "Subir/Cambiar Imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            // 
            // cmbEstablecimiento
            // 
            this.cmbEstablecimiento.FormattingEnabled = true;
            this.cmbEstablecimiento.Items.AddRange(new object[] {
            "Cedula",
            "Ruc",
            "Pasaporte"});
            this.cmbEstablecimiento.Location = new System.Drawing.Point(10, 39);
            this.cmbEstablecimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEstablecimiento.Name = "cmbEstablecimiento";
            this.cmbEstablecimiento.Size = new System.Drawing.Size(200, 24);
            this.cmbEstablecimiento.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Establecimiento:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbEstablecimiento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 82);
            this.panel1.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Unidad,
            this.Precio1,
            this.Precio2,
            this.Precio3,
            this.Precio4,
            this.Precio5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 533);
            this.dataGridView1.TabIndex = 20;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.MinimumWidth = 6;
            this.Unidad.Name = "Unidad";
            this.Unidad.Width = 125;
            // 
            // Precio1
            // 
            this.Precio1.HeaderText = "Precio 1";
            this.Precio1.MinimumWidth = 6;
            this.Precio1.Name = "Precio1";
            this.Precio1.Width = 125;
            // 
            // Precio2
            // 
            this.Precio2.HeaderText = "Precio 2";
            this.Precio2.MinimumWidth = 6;
            this.Precio2.Name = "Precio2";
            this.Precio2.Width = 125;
            // 
            // Precio3
            // 
            this.Precio3.HeaderText = "Precio 3";
            this.Precio3.MinimumWidth = 6;
            this.Precio3.Name = "Precio3";
            this.Precio3.Width = 125;
            // 
            // Precio4
            // 
            this.Precio4.HeaderText = "Precio 4";
            this.Precio4.MinimumWidth = 6;
            this.Precio4.Name = "Precio4";
            this.Precio4.Width = 125;
            // 
            // Precio5
            // 
            this.Precio5.HeaderText = "Precio 5";
            this.Precio5.MinimumWidth = 6;
            this.Precio5.Name = "Precio5";
            this.Precio5.Width = 125;
            // 
            // FormMantProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 697);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMantProductos";
            this.Text = "FormMantProductos";
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMensaje)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInfoGeneral.ResumeLayout(false);
            this.tabInfoGeneral.PerformLayout();
            this.tabPrecios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.ErrorProvider epMensaje;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfoGeneral;
        private System.Windows.Forms.ComboBox cmbSubCategoria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPrecios;
        public System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkIva;
        public System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstablecimiento;
    }
}