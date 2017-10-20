namespace HostelSystem
{
    partial class Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CbMailPersonalizado = new System.Windows.Forms.CheckBox();
            this.TxtMailR = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Txtpass = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connombre = new System.Windows.Forms.TextBox();
            this.conrfc = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.regimenfiscal = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lexpedicion = new System.Windows.Forms.TextBox();
            this.IvaInclu = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.TxtPassFact = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.Txtkey = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.Txtcer = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.UrlFacAll = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.UrlLogoFact = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ininoempleados = new System.Windows.Forms.RadioButton();
            this.ininoemision = new System.Windows.Forms.RadioButton();
            this.inifaconceptos = new System.Windows.Forms.RadioButton();
            this.inifaclientes = new System.Windows.Forms.RadioButton();
            this.inifaemisiones = new System.Windows.Forms.RadioButton();
            this.ininomina = new System.Windows.Forms.RadioButton();
            this.inifactura = new System.Windows.Forms.RadioButton();
            this.tabPage5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Location = new System.Drawing.Point(7, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(385, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "ACEPTAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(381, 378);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Notificacion Mail";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.CbMailPersonalizado);
            this.groupBox10.Controls.Add(this.TxtMailR);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.TxtHost);
            this.groupBox10.Controls.Add(this.TxtPort);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Controls.Add(this.Txtpass);
            this.groupBox10.Controls.Add(this.label18);
            this.groupBox10.Controls.Add(this.label19);
            this.groupBox10.Controls.Add(this.TxtMail);
            this.groupBox10.Location = new System.Drawing.Point(3, 15);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(352, 360);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "DATOS DE CORREO";
            // 
            // CbMailPersonalizado
            // 
            this.CbMailPersonalizado.AutoSize = true;
            this.CbMailPersonalizado.Location = new System.Drawing.Point(186, 19);
            this.CbMailPersonalizado.Name = "CbMailPersonalizado";
            this.CbMailPersonalizado.Size = new System.Drawing.Size(160, 17);
            this.CbMailPersonalizado.TabIndex = 11;
            this.CbMailPersonalizado.Text = "Activar correo personalizado";
            this.CbMailPersonalizado.UseVisualStyleBackColor = true;
            this.CbMailPersonalizado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TxtMailR
            // 
            this.TxtMailR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMailR.Location = new System.Drawing.Point(71, 173);
            this.TxtMailR.Name = "TxtMailR";
            this.TxtMailR.Size = new System.Drawing.Size(275, 26);
            this.TxtMailR.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(27, 181);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Mail R";
            // 
            // TxtHost
            // 
            this.TxtHost.Enabled = false;
            this.TxtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHost.Location = new System.Drawing.Point(71, 141);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(275, 26);
            this.TxtHost.TabIndex = 4;
            // 
            // TxtPort
            // 
            this.TxtPort.Enabled = false;
            this.TxtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPort.Location = new System.Drawing.Point(71, 107);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(275, 26);
            this.TxtPort.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Puerto";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(35, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Host";
            // 
            // Txtpass
            // 
            this.Txtpass.Enabled = false;
            this.Txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtpass.Location = new System.Drawing.Point(71, 74);
            this.Txtpass.Name = "Txtpass";
            this.Txtpass.PasswordChar = '*';
            this.Txtpass.Size = new System.Drawing.Size(275, 26);
            this.Txtpass.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Contraseña";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Correo";
            // 
            // TxtMail
            // 
            this.TxtMail.Enabled = false;
            this.TxtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMail.Location = new System.Drawing.Point(71, 42);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(275, 26);
            this.TxtMail.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(381, 378);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Facturacion";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.connombre);
            this.panel1.Controls.Add(this.conrfc);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.regimenfiscal);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.lexpedicion);
            this.panel1.Controls.Add(this.IvaInclu);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.TxtPassFact);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.Txtkey);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.Txtcer);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.UrlFacAll);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.UrlLogoFact);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 372);
            this.panel1.TabIndex = 18;
            // 
            // connombre
            // 
            this.connombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connombre.Location = new System.Drawing.Point(15, 194);
            this.connombre.Name = "connombre";
            this.connombre.Size = new System.Drawing.Size(335, 26);
            this.connombre.TabIndex = 4;
            // 
            // conrfc
            // 
            this.conrfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conrfc.Location = new System.Drawing.Point(15, 139);
            this.conrfc.Name = "conrfc";
            this.conrfc.Size = new System.Drawing.Size(335, 26);
            this.conrfc.TabIndex = 3;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(18, 123);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(24, 13);
            this.label32.TabIndex = 72;
            this.label32.Text = "Rfc";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 178);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(71, 13);
            this.label33.TabIndex = 71;
            this.label33.Text = "Nombre fiscal";
            // 
            // regimenfiscal
            // 
            this.regimenfiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regimenfiscal.Location = new System.Drawing.Point(15, 86);
            this.regimenfiscal.Name = "regimenfiscal";
            this.regimenfiscal.Size = new System.Drawing.Size(335, 26);
            this.regimenfiscal.TabIndex = 2;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(12, 70);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(76, 13);
            this.label34.TabIndex = 70;
            this.label34.Text = "Regimen fiscal";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(12, 14);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(88, 13);
            this.label35.TabIndex = 68;
            this.label35.Text = "Lugar expedicion";
            // 
            // lexpedicion
            // 
            this.lexpedicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexpedicion.Location = new System.Drawing.Point(15, 30);
            this.lexpedicion.Name = "lexpedicion";
            this.lexpedicion.Size = new System.Drawing.Size(335, 26);
            this.lexpedicion.TabIndex = 1;
            // 
            // IvaInclu
            // 
            this.IvaInclu.AutoSize = true;
            this.IvaInclu.Location = new System.Drawing.Point(269, 556);
            this.IvaInclu.Name = "IvaInclu";
            this.IvaInclu.Size = new System.Drawing.Size(80, 17);
            this.IvaInclu.TabIndex = 26;
            this.IvaInclu.Text = "Iva includio";
            this.IvaInclu.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(18, 499);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 13);
            this.label29.TabIndex = 61;
            this.label29.Text = "Contraseña (sat)";
            // 
            // TxtPassFact
            // 
            this.TxtPassFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassFact.Location = new System.Drawing.Point(9, 515);
            this.TxtPassFact.Name = "TxtPassFact";
            this.TxtPassFact.Size = new System.Drawing.Size(345, 26);
            this.TxtPassFact.TabIndex = 24;
            this.TxtPassFact.UseSystemPasswordChar = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(260, 477);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 24);
            this.button7.TabIndex = 23;
            this.button7.Text = "EXAMINAR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 432);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 13);
            this.label28.TabIndex = 57;
            this.label28.Text = "Archivo (.key)";
            // 
            // Txtkey
            // 
            this.Txtkey.Enabled = false;
            this.Txtkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtkey.Location = new System.Drawing.Point(9, 446);
            this.Txtkey.Name = "Txtkey";
            this.Txtkey.Size = new System.Drawing.Size(345, 26);
            this.Txtkey.TabIndex = 58;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(260, 411);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 24);
            this.button6.TabIndex = 22;
            this.button6.Text = "EXAMINAR";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 364);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 13);
            this.label27.TabIndex = 54;
            this.label27.Text = "Archivo (.cer)";
            // 
            // Txtcer
            // 
            this.Txtcer.Enabled = false;
            this.Txtcer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcer.Location = new System.Drawing.Point(9, 380);
            this.Txtcer.Name = "Txtcer";
            this.Txtcer.Size = new System.Drawing.Size(345, 26);
            this.Txtcer.TabIndex = 55;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(260, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 24);
            this.button4.TabIndex = 20;
            this.button4.Text = "EXAMINAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(18, 232);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(161, 13);
            this.label26.TabIndex = 51;
            this.label26.Text = "Donde se guardan las facturas ?";
            // 
            // UrlFacAll
            // 
            this.UrlFacAll.Enabled = false;
            this.UrlFacAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlFacAll.Location = new System.Drawing.Point(9, 248);
            this.UrlFacAll.Name = "UrlFacAll";
            this.UrlFacAll.Size = new System.Drawing.Size(345, 26);
            this.UrlFacAll.TabIndex = 52;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 345);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 24);
            this.button3.TabIndex = 21;
            this.button3.Text = "EXAMINAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(18, 298);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 13);
            this.label25.TabIndex = 48;
            this.label25.Text = "Logo factura";
            // 
            // UrlLogoFact
            // 
            this.UrlLogoFact.Enabled = false;
            this.UrlLogoFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlLogoFact.Location = new System.Drawing.Point(9, 314);
            this.UrlLogoFact.Name = "UrlLogoFact";
            this.UrlLogoFact.Size = new System.Drawing.Size(345, 26);
            this.UrlLogoFact.TabIndex = 49;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(389, 404);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(381, 378);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Inicio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ininoempleados);
            this.groupBox1.Controls.Add(this.ininoemision);
            this.groupBox1.Controls.Add(this.inifaconceptos);
            this.groupBox1.Controls.Add(this.inifaclientes);
            this.groupBox1.Controls.Add(this.inifaemisiones);
            this.groupBox1.Controls.Add(this.ininomina);
            this.groupBox1.Controls.Add(this.inifactura);
            this.groupBox1.Location = new System.Drawing.Point(14, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 360);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCIONE EL MODULO DE INICIO";
            // 
            // ininoempleados
            // 
            this.ininoempleados.AutoSize = true;
            this.ininoempleados.Location = new System.Drawing.Point(18, 170);
            this.ininoempleados.Name = "ininoempleados";
            this.ininoempleados.Size = new System.Drawing.Size(125, 17);
            this.ininoempleados.TabIndex = 6;
            this.ininoempleados.TabStop = true;
            this.ininoempleados.Text = "Nomina > Empleados";
            this.ininoempleados.UseVisualStyleBackColor = true;
            // 
            // ininoemision
            // 
            this.ininoemision.AutoSize = true;
            this.ininoemision.Location = new System.Drawing.Point(18, 147);
            this.ininoemision.Name = "ininoemision";
            this.ininoemision.Size = new System.Drawing.Size(109, 17);
            this.ininoemision.TabIndex = 5;
            this.ininoemision.TabStop = true;
            this.ininoemision.Text = "Nomina > Emision";
            this.ininoemision.UseVisualStyleBackColor = true;
            // 
            // inifaconceptos
            // 
            this.inifaconceptos.AutoSize = true;
            this.inifaconceptos.Location = new System.Drawing.Point(18, 124);
            this.inifaconceptos.Name = "inifaconceptos";
            this.inifaconceptos.Size = new System.Drawing.Size(129, 17);
            this.inifaconceptos.TabIndex = 4;
            this.inifaconceptos.TabStop = true;
            this.inifaconceptos.Text = "Facturas > Conceptos";
            this.inifaconceptos.UseVisualStyleBackColor = true;
            // 
            // inifaclientes
            // 
            this.inifaclientes.AutoSize = true;
            this.inifaclientes.Location = new System.Drawing.Point(18, 101);
            this.inifaclientes.Name = "inifaclientes";
            this.inifaclientes.Size = new System.Drawing.Size(115, 17);
            this.inifaclientes.TabIndex = 3;
            this.inifaclientes.TabStop = true;
            this.inifaclientes.Text = "Facturas > Clientes";
            this.inifaclientes.UseVisualStyleBackColor = true;
            // 
            // inifaemisiones
            // 
            this.inifaemisiones.AutoSize = true;
            this.inifaemisiones.Location = new System.Drawing.Point(17, 78);
            this.inifaemisiones.Name = "inifaemisiones";
            this.inifaemisiones.Size = new System.Drawing.Size(125, 17);
            this.inifaemisiones.TabIndex = 2;
            this.inifaemisiones.TabStop = true;
            this.inifaemisiones.Text = "Facturas > Emisiones";
            this.inifaemisiones.UseVisualStyleBackColor = true;
            // 
            // ininomina
            // 
            this.ininomina.AutoSize = true;
            this.ininomina.Location = new System.Drawing.Point(18, 55);
            this.ininomina.Name = "ininomina";
            this.ininomina.Size = new System.Drawing.Size(94, 17);
            this.ininomina.TabIndex = 1;
            this.ininomina.TabStop = true;
            this.ininomina.Text = "Nueva nomina";
            this.ininomina.UseVisualStyleBackColor = true;
            // 
            // inifactura
            // 
            this.inifactura.AutoSize = true;
            this.inifactura.Location = new System.Drawing.Point(18, 32);
            this.inifactura.Name = "inifactura";
            this.inifactura.Size = new System.Drawing.Size(93, 17);
            this.inifactura.TabIndex = 0;
            this.inifactura.TabStop = true;
            this.inifactura.Text = "Nueva factura";
            this.inifactura.UseVisualStyleBackColor = true;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 467);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.tabPage5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox CbMailPersonalizado;
        private System.Windows.Forms.TextBox TxtMailR;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Txtpass;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox connombre;
        private System.Windows.Forms.TextBox conrfc;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox regimenfiscal;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox lexpedicion;
        private System.Windows.Forms.CheckBox IvaInclu;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox TxtPassFact;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Txtkey;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox Txtcer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox UrlFacAll;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox UrlLogoFact;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ininoempleados;
        private System.Windows.Forms.RadioButton ininoemision;
        private System.Windows.Forms.RadioButton inifaconceptos;
        private System.Windows.Forms.RadioButton inifaclientes;
        private System.Windows.Forms.RadioButton inifaemisiones;
        private System.Windows.Forms.RadioButton ininomina;
        private System.Windows.Forms.RadioButton inifactura;
    }
}