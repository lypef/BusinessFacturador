namespace HostelSystem
{
    partial class NewFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFactura));
            this.BtnFacturar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtvVentas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtvClientes = new System.Windows.Forms.DataGridView();
            this.TxtHuesped = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TxtConceptos = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtvProductFact = new System.Windows.Forms.DataGridView();
            this.MenuVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarAFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProductFact = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.MetodPago = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TipoComprobante = new System.Windows.Forms.ComboBox();
            this.Image2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvVentas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvClientes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvProductFact)).BeginInit();
            this.MenuVentas.SuspendLayout();
            this.MenuProductFact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnFacturar
            // 
            this.BtnFacturar.Image = global::HostelSystem.Properties.Resources.Activate;
            this.BtnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFacturar.Location = new System.Drawing.Point(507, 423);
            this.BtnFacturar.Name = "BtnFacturar";
            this.BtnFacturar.Size = new System.Drawing.Size(314, 50);
            this.BtnFacturar.TabIndex = 0;
            this.BtnFacturar.Text = "FACTURAR";
            this.BtnFacturar.UseVisualStyleBackColor = true;
            this.BtnFacturar.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtvVentas);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 357);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONCEPTOS";
            // 
            // DtvVentas
            // 
            this.DtvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtvVentas.Location = new System.Drawing.Point(3, 16);
            this.DtvVentas.Name = "DtvVentas";
            this.DtvVentas.Size = new System.Drawing.Size(423, 338);
            this.DtvVentas.TabIndex = 0;
            this.DtvVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtvVentas_CellDoubleClick);
            this.DtvVentas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DtvVentas_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtvClientes);
            this.groupBox2.Location = new System.Drawing.Point(448, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 192);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CLIENTES";
            // 
            // DtvClientes
            // 
            this.DtvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtvClientes.Location = new System.Drawing.Point(3, 16);
            this.DtvClientes.Name = "DtvClientes";
            this.DtvClientes.Size = new System.Drawing.Size(423, 173);
            this.DtvClientes.TabIndex = 1;
            // 
            // TxtHuesped
            // 
            this.TxtHuesped.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHuesped.Location = new System.Drawing.Point(448, 12);
            this.TxtHuesped.Name = "TxtHuesped";
            this.TxtHuesped.Size = new System.Drawing.Size(253, 31);
            this.TxtHuesped.TabIndex = 4;
            this.TxtHuesped.TextChanged += new System.EventHandler(this.TxtHuesped_TextChanged);
            this.TxtHuesped.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHuesped_KeyPress);
            // 
            // button3
            // 
            this.button3.Image = global::HostelSystem.Properties.Resources.search;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(705, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 42);
            this.button3.TabIndex = 5;
            this.button3.Text = "BUSCAR CLIENTE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Image = global::HostelSystem.Properties.Resources.search;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(273, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 42);
            this.button4.TabIndex = 7;
            this.button4.Text = "BUSCAR CONCEPTO";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TxtConceptos
            // 
            this.TxtConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConceptos.Location = new System.Drawing.Point(13, 12);
            this.TxtConceptos.Name = "TxtConceptos";
            this.TxtConceptos.Size = new System.Drawing.Size(254, 31);
            this.TxtConceptos.TabIndex = 6;
            this.TxtConceptos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConceptos_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtvProductFact);
            this.groupBox3.Location = new System.Drawing.Point(451, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 156);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PRODUCTOS A FACTURAR";
            // 
            // DtvProductFact
            // 
            this.DtvProductFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtvProductFact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtvProductFact.Location = new System.Drawing.Point(3, 16);
            this.DtvProductFact.Name = "DtvProductFact";
            this.DtvProductFact.Size = new System.Drawing.Size(423, 137);
            this.DtvProductFact.TabIndex = 1;
            this.DtvProductFact.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtvProductFact_CellDoubleClick);
            this.DtvProductFact.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DtvProductFact_MouseDown);
            // 
            // MenuVentas
            // 
            this.MenuVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarAFacturaToolStripMenuItem});
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(166, 26);
            // 
            // agregarAFacturaToolStripMenuItem
            // 
            this.agregarAFacturaToolStripMenuItem.Name = "agregarAFacturaToolStripMenuItem";
            this.agregarAFacturaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.agregarAFacturaToolStripMenuItem.Text = "Agregar a factura";
            this.agregarAFacturaToolStripMenuItem.Click += new System.EventHandler(this.agregarAFacturaToolStripMenuItem_Click);
            // 
            // MenuProductFact
            // 
            this.MenuProductFact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.MenuProductFact.Name = "MenuVentas";
            this.MenuProductFact.Size = new System.Drawing.Size(108, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Quitar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Image1
            // 
            this.Image1.Location = new System.Drawing.Point(451, 423);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(50, 50);
            this.Image1.TabIndex = 10;
            this.Image1.TabStop = false;
            // 
            // MetodPago
            // 
            this.MetodPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MetodPago.FormattingEnabled = true;
            this.MetodPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "CHEQUE NOMINATIVO",
            "TRANSFERENCIA ELECTRONICA DE FONDOS",
            "TARJETA DE CREDITO",
            "MONEDERO ELECTRONICO",
            "VALES DE DESPENSA",
            "TARJETA DE DEBITO",
            "TARJETA DE SERVICIO",
            "OTROS"});
            this.MetodPago.Location = new System.Drawing.Point(11, 21);
            this.MetodPago.Name = "MetodPago";
            this.MetodPago.Size = new System.Drawing.Size(243, 21);
            this.MetodPago.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MetodPago);
            this.groupBox4.Location = new System.Drawing.Point(13, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 54);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Metodo de pago";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TipoComprobante);
            this.groupBox5.Location = new System.Drawing.Point(287, 419);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(155, 54);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo de comprobante";
            // 
            // TipoComprobante
            // 
            this.TipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoComprobante.FormattingEnabled = true;
            this.TipoComprobante.Items.AddRange(new object[] {
            "INGRESO",
            "EGRESO",
            "TRASLADO"});
            this.TipoComprobante.Location = new System.Drawing.Point(6, 21);
            this.TipoComprobante.Name = "TipoComprobante";
            this.TipoComprobante.Size = new System.Drawing.Size(142, 21);
            this.TipoComprobante.TabIndex = 14;
            // 
            // Image2
            // 
            this.Image2.Location = new System.Drawing.Point(827, 423);
            this.Image2.Name = "Image2";
            this.Image2.Size = new System.Drawing.Size(50, 50);
            this.Image2.TabIndex = 17;
            this.Image2.TabStop = false;
            // 
            // NewFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 481);
            this.Controls.Add(this.Image2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.TxtConceptos);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TxtHuesped);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnFacturar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewFactura";
            this.Text = "NewFactura";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtvVentas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtvClientes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtvProductFact)).EndInit();
            this.MenuVentas.ResumeLayout(false);
            this.MenuProductFact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFacturar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtvVentas;
        private System.Windows.Forms.DataGridView DtvClientes;
        private System.Windows.Forms.TextBox TxtHuesped;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox TxtConceptos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DtvProductFact;
        private System.Windows.Forms.ContextMenuStrip MenuVentas;
        private System.Windows.Forms.ToolStripMenuItem agregarAFacturaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuProductFact;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.ComboBox MetodPago;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox TipoComprobante;
        private System.Windows.Forms.PictureBox Image2;
    }
}