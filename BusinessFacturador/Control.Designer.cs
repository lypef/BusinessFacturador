namespace HostelSystem
{
    partial class Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.importarXLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.conceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirDirecrotioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vaciarReferenciasDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.MenuMantenimiento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarALIBREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carbiarStatusALIMPIEZAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.verUltimoFolioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLimpieza = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarALIBREToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.verUltimoFolioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLibre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.informacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.verUltimoFolioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarALIMPIEZAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarAMANTENIMIENTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.process1 = new System.ComponentModel.BackgroundWorker();
            this.PorcentajeCompletado = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.MenuMantenimiento.SuspendLayout();
            this.MenuLimpieza.SuspendLayout();
            this.MenuLibre.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.nuevaFacturaToolStripMenuItem,
            this.emisionesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem1,
            this.toolStripSeparator4,
            this.importarXLSToolStripMenuItem,
            this.toolStripSeparator3,
            this.conceptosToolStripMenuItem,
            this.abrirDirecrotioToolStripMenuItem,
            this.toolStripSeparator1,
            this.vaciarReferenciasDeFacturasToolStripMenuItem,
            this.toolStripSeparator6,
            this.configurarToolStripMenuItem,
            this.bloquearToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.File;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources.Customers;
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(282, 26);
            this.usuariosToolStripMenuItem1.Text = "Usuarios";
            this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(279, 6);
            // 
            // importarXLSToolStripMenuItem
            // 
            this.importarXLSToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.cardboard_box_48;
            this.importarXLSToolStripMenuItem.Name = "importarXLSToolStripMenuItem";
            this.importarXLSToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.importarXLSToolStripMenuItem.Text = "Importar XLS";
            this.importarXLSToolStripMenuItem.Click += new System.EventHandler(this.importarXLSToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(279, 6);
            // 
            // conceptosToolStripMenuItem
            // 
            this.conceptosToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.curx;
            this.conceptosToolStripMenuItem.Name = "conceptosToolStripMenuItem";
            this.conceptosToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.conceptosToolStripMenuItem.Text = "Conceptos";
            this.conceptosToolStripMenuItem.Click += new System.EventHandler(this.conceptosToolStripMenuItem_Click_2);
            // 
            // abrirDirecrotioToolStripMenuItem
            // 
            this.abrirDirecrotioToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.ver;
            this.abrirDirecrotioToolStripMenuItem.Name = "abrirDirecrotioToolStripMenuItem";
            this.abrirDirecrotioToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.abrirDirecrotioToolStripMenuItem.Text = "Abrir directorio";
            this.abrirDirecrotioToolStripMenuItem.Click += new System.EventHandler(this.abrirDirecrotioToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // vaciarReferenciasDeFacturasToolStripMenuItem
            // 
            this.vaciarReferenciasDeFacturasToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.db;
            this.vaciarReferenciasDeFacturasToolStripMenuItem.Name = "vaciarReferenciasDeFacturasToolStripMenuItem";
            this.vaciarReferenciasDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.vaciarReferenciasDeFacturasToolStripMenuItem.Text = "Vaciar referencias de facturas";
            this.vaciarReferenciasDeFacturasToolStripMenuItem.Click += new System.EventHandler(this.vaciarReferenciasDeFacturasToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(279, 6);
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.setup1;
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.configurarToolStripMenuItem.Text = "Configuracion";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click);
            // 
            // bloquearToolStripMenuItem
            // 
            this.bloquearToolStripMenuItem.Image = global::HostelSystem.Properties.Resources._lock;
            this.bloquearToolStripMenuItem.Name = "bloquearToolStripMenuItem";
            this.bloquearToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.bloquearToolStripMenuItem.Text = "Bloquear";
            this.bloquearToolStripMenuItem.Click += new System.EventHandler(this.bloquearToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(279, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.Exit;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nuevaFacturaToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.Activate;
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            this.nuevaFacturaToolStripMenuItem.Size = new System.Drawing.Size(135, 25);
            this.nuevaFacturaToolStripMenuItem.Text = "Nueva factura";
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click);
            // 
            // emisionesToolStripMenuItem
            // 
            this.emisionesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.emisionesToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.calendar;
            this.emisionesToolStripMenuItem.Name = "emisionesToolStripMenuItem";
            this.emisionesToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.emisionesToolStripMenuItem.Text = "Emisiones";
            this.emisionesToolStripMenuItem.Click += new System.EventHandler(this.emisionesToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Image = global::HostelSystem.Properties.Resources.Users;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(93, 25);
            this.toolStripMenuItem2.Text = "Clientes";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.acercaDeToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.About;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // Panel
            // 
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 29);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(888, 493);
            this.Panel.TabIndex = 1;
            // 
            // Timer
            // 
            this.Timer.Interval = 10000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MenuMantenimiento
            // 
            this.MenuMantenimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarALIBREToolStripMenuItem,
            this.carbiarStatusALIMPIEZAToolStripMenuItem,
            this.toolStripSeparator16,
            this.verUltimoFolioToolStripMenuItem});
            this.MenuMantenimiento.Name = "MenuMantenimiento";
            this.MenuMantenimiento.Size = new System.Drawing.Size(183, 76);
            // 
            // cambiarALIBREToolStripMenuItem
            // 
            this.cambiarALIBREToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.Activate;
            this.cambiarALIBREToolStripMenuItem.Name = "cambiarALIBREToolStripMenuItem";
            this.cambiarALIBREToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarALIBREToolStripMenuItem.Text = "Cambiar a LIBRE";
            // 
            // carbiarStatusALIMPIEZAToolStripMenuItem
            // 
            this.carbiarStatusALIMPIEZAToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.cleaning;
            this.carbiarStatusALIMPIEZAToolStripMenuItem.Name = "carbiarStatusALIMPIEZAToolStripMenuItem";
            this.carbiarStatusALIMPIEZAToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.carbiarStatusALIMPIEZAToolStripMenuItem.Text = "Cambiar a LIMPIEZA";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(179, 6);
            // 
            // verUltimoFolioToolStripMenuItem
            // 
            this.verUltimoFolioToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.File;
            this.verUltimoFolioToolStripMenuItem.Name = "verUltimoFolioToolStripMenuItem";
            this.verUltimoFolioToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.verUltimoFolioToolStripMenuItem.Text = "Ver ultimo folio";
            // 
            // MenuLimpieza
            // 
            this.MenuLimpieza.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarALIBREToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.toolStripSeparator17,
            this.verUltimoFolioToolStripMenuItem1});
            this.MenuLimpieza.Name = "MenuMantenimiento";
            this.MenuLimpieza.Size = new System.Drawing.Size(229, 76);
            // 
            // cambiarALIBREToolStripMenuItem1
            // 
            this.cambiarALIBREToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources.Activate;
            this.cambiarALIBREToolStripMenuItem1.Name = "cambiarALIBREToolStripMenuItem1";
            this.cambiarALIBREToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.cambiarALIBREToolStripMenuItem1.Text = "Cambiar a LIBRE";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::HostelSystem.Properties.Resources.cleaning;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItem1.Text = "Cambiar a MANTENIMIENTO";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(225, 6);
            // 
            // verUltimoFolioToolStripMenuItem1
            // 
            this.verUltimoFolioToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources.File;
            this.verUltimoFolioToolStripMenuItem1.Name = "verUltimoFolioToolStripMenuItem1";
            this.verUltimoFolioToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.verUltimoFolioToolStripMenuItem1.Text = "Ver ultimo folio";
            // 
            // MenuLibre
            // 
            this.MenuLibre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionToolStripMenuItem,
            this.toolStripSeparator14,
            this.verUltimoFolioToolStripMenuItem2,
            this.toolStripSeparator15,
            this.cambiarALIMPIEZAToolStripMenuItem,
            this.cambiarAMANTENIMIENTOToolStripMenuItem});
            this.MenuLibre.Name = "MenuLibre";
            this.MenuLibre.Size = new System.Drawing.Size(229, 104);
            // 
            // informacionToolStripMenuItem
            // 
            this.informacionToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.About;
            this.informacionToolStripMenuItem.Name = "informacionToolStripMenuItem";
            this.informacionToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.informacionToolStripMenuItem.Text = "Informacion";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(225, 6);
            // 
            // verUltimoFolioToolStripMenuItem2
            // 
            this.verUltimoFolioToolStripMenuItem2.Image = global::HostelSystem.Properties.Resources.File;
            this.verUltimoFolioToolStripMenuItem2.Name = "verUltimoFolioToolStripMenuItem2";
            this.verUltimoFolioToolStripMenuItem2.Size = new System.Drawing.Size(228, 22);
            this.verUltimoFolioToolStripMenuItem2.Text = "Ver ultimo folio";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(225, 6);
            // 
            // cambiarALIMPIEZAToolStripMenuItem
            // 
            this.cambiarALIMPIEZAToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.cleaning;
            this.cambiarALIMPIEZAToolStripMenuItem.Name = "cambiarALIMPIEZAToolStripMenuItem";
            this.cambiarALIMPIEZAToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.cambiarALIMPIEZAToolStripMenuItem.Text = "Cambiar a LIMPIEZA";
            // 
            // cambiarAMANTENIMIENTOToolStripMenuItem
            // 
            this.cambiarAMANTENIMIENTOToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.setup1;
            this.cambiarAMANTENIMIENTOToolStripMenuItem.Name = "cambiarAMANTENIMIENTOToolStripMenuItem";
            this.cambiarAMANTENIMIENTOToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.cambiarAMANTENIMIENTOToolStripMenuItem.Text = "Cambiar a MANTENIMIENTO";
            // 
            // process1
            // 
            this.process1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // PorcentajeCompletado
            // 
            this.PorcentajeCompletado.AutoSize = true;
            this.PorcentajeCompletado.BackColor = System.Drawing.Color.Lime;
            this.PorcentajeCompletado.ForeColor = System.Drawing.Color.Black;
            this.PorcentajeCompletado.Location = new System.Drawing.Point(749, 9);
            this.PorcentajeCompletado.Name = "PorcentajeCompletado";
            this.PorcentajeCompletado.Size = new System.Drawing.Size(113, 13);
            this.PorcentajeCompletado.TabIndex = 4;
            this.PorcentajeCompletado.Text = "100 % COMPLETADO";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(888, 522);
            this.Controls.Add(this.PorcentajeCompletado);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Control";
            this.Text = "Control";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MenuMantenimiento.ResumeLayout(false);
            this.MenuLimpieza.ResumeLayout(false);
            this.MenuLibre.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip MenuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem carbiarStatusALIMPIEZAToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuLimpieza;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cambiarALIBREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verUltimoFolioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarALIBREToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verUltimoFolioToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip MenuLibre;
        private System.Windows.Forms.ToolStripMenuItem informacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem verUltimoFolioToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cambiarAMANTENIMIENTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarALIMPIEZAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem vaciarReferenciasDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloquearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirDirecrotioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem emisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem importarXLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.ComponentModel.BackgroundWorker process1;
        private System.Windows.Forms.Label PorcentajeCompletado;
    }
}