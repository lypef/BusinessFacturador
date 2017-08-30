﻿namespace HostelSystem
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
            this.ComboClientes = new System.Windows.Forms.ComboBox();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtUnidad = new System.Windows.Forms.TextBox();
            this.BtnAddManual = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtManualMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtManualConcepto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIdentificador = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvVentas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvProductFact)).BeginInit();
            this.MenuVentas.SuspendLayout();
            this.MenuProductFact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFacturar
            // 
            this.BtnFacturar.Image = global::HostelSystem.Properties.Resources.Activate;
            this.BtnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFacturar.Location = new System.Drawing.Point(510, 423);
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
            this.groupBox1.Size = new System.Drawing.Size(429, 226);
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
            this.DtvVentas.Size = new System.Drawing.Size(423, 207);
            this.DtvVentas.TabIndex = 0;
            this.DtvVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtvVentas_CellDoubleClick);
            this.DtvVentas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DtvVentas_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboClientes);
            this.groupBox2.Location = new System.Drawing.Point(451, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CLIENTES";
            // 
            // ComboClientes
            // 
            this.ComboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboClientes.FormattingEnabled = true;
            this.ComboClientes.Location = new System.Drawing.Point(6, 19);
            this.ComboClientes.Name = "ComboClientes";
            this.ComboClientes.Size = new System.Drawing.Size(417, 28);
            this.ComboClientes.TabIndex = 19;
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
            this.groupBox3.Location = new System.Drawing.Point(451, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 278);
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
            this.DtvProductFact.Size = new System.Drawing.Size(423, 259);
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
            this.Image1.Location = new System.Drawing.Point(454, 423);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(50, 50);
            this.Image1.TabIndex = 10;
            this.Image1.TabStop = false;
            // 
            // MetodPago
            // 
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
            this.groupBox4.Location = new System.Drawing.Point(451, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 54);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Metodo de pago";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TipoComprobante);
            this.groupBox5.Location = new System.Drawing.Point(725, 72);
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
            this.Image2.Location = new System.Drawing.Point(830, 423);
            this.Image2.Name = "Image2";
            this.Image2.Size = new System.Drawing.Size(50, 50);
            this.Image2.TabIndex = 17;
            this.Image2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.TxtUnidad);
            this.groupBox6.Controls.Add(this.BtnAddManual);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.TxtCantidad);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.TxtManualMonto);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.TxtManualConcepto);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.TxtIdentificador);
            this.groupBox6.Location = new System.Drawing.Point(12, 288);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(429, 185);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "VENTAS MANUAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(47, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Unidad:";
            // 
            // TxtUnidad
            // 
            this.TxtUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUnidad.Location = new System.Drawing.Point(117, 51);
            this.TxtUnidad.Name = "TxtUnidad";
            this.TxtUnidad.Size = new System.Drawing.Size(305, 26);
            this.TxtUnidad.TabIndex = 8;
            this.TxtUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnidad_KeyPress);
            // 
            // BtnAddManual
            // 
            this.BtnAddManual.Location = new System.Drawing.Point(297, 147);
            this.BtnAddManual.Name = "BtnAddManual";
            this.BtnAddManual.Size = new System.Drawing.Size(125, 26);
            this.BtnAddManual.TabIndex = 12;
            this.BtnAddManual.Text = "Agregar";
            this.BtnAddManual.UseVisualStyleBackColor = true;
            this.BtnAddManual.Click += new System.EventHandler(this.BtnAddManual_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(34, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad:";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.Location = new System.Drawing.Point(117, 19);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(305, 26);
            this.TxtCantidad.TabIndex = 7;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(54, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio:";
            // 
            // TxtManualMonto
            // 
            this.TxtManualMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtManualMonto.Location = new System.Drawing.Point(117, 147);
            this.TxtManualMonto.Name = "TxtManualMonto";
            this.TxtManualMonto.Size = new System.Drawing.Size(174, 26);
            this.TxtManualMonto.TabIndex = 11;
            this.TxtManualMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtManualMonto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(29, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Concepto:";
            // 
            // TxtManualConcepto
            // 
            this.TxtManualConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtManualConcepto.Location = new System.Drawing.Point(117, 115);
            this.TxtManualConcepto.Name = "TxtManualConcepto";
            this.TxtManualConcepto.Size = new System.Drawing.Size(305, 26);
            this.TxtManualConcepto.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(10, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificador:";
            // 
            // TxtIdentificador
            // 
            this.TxtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdentificador.Location = new System.Drawing.Point(117, 83);
            this.TxtIdentificador.Name = "TxtIdentificador";
            this.TxtIdentificador.Size = new System.Drawing.Size(305, 26);
            this.TxtIdentificador.TabIndex = 9;
            this.TxtIdentificador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtManualId_KeyPress);
            // 
            // NewFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 481);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.Image2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.TxtConceptos);
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
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtvProductFact)).EndInit();
            this.MenuVentas.ResumeLayout(false);
            this.MenuProductFact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFacturar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtvVentas;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnAddManual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtManualMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtManualConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIdentificador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtUnidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.ComboBox ComboClientes;
    }
}