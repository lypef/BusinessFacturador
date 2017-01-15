namespace HostelSystem
{
    partial class facturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(facturacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtvFacturas = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirDirectorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.generarArchivoPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.enviarPorCorreoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.regenerarDirectorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.generarArchivoPdfToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enviarPorCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvFacturas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.MenuDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtvFacturas);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturacion electronica";
            // 
            // DtvFacturas
            // 
            this.DtvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtvFacturas.Location = new System.Drawing.Point(3, 16);
            this.DtvFacturas.Name = "DtvFacturas";
            this.DtvFacturas.Size = new System.Drawing.Size(846, 409);
            this.DtvFacturas.TabIndex = 0;
            this.DtvFacturas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtvFacturas_CellMouseDoubleClick);
            this.DtvFacturas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DtvFacturas_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.buscarToolStripMenuItem1,
            this.actualizarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirDirectorioToolStripMenuItem,
            this.toolStripSeparator6,
            this.abrirToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripSeparator3,
            this.generarArchivoPdfToolStripMenuItem,
            this.toolStripSeparator2,
            this.enviarPorCorreoToolStripMenuItem1,
            this.toolStripSeparator5,
            this.regenerarDirectorioToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirDirectorioToolStripMenuItem
            // 
            this.abrirDirectorioToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.ver;
            this.abrirDirectorioToolStripMenuItem.Name = "abrirDirectorioToolStripMenuItem";
            this.abrirDirectorioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.abrirDirectorioToolStripMenuItem.Text = "Abrir directorio";
            this.abrirDirectorioToolStripMenuItem.Click += new System.EventHandler(this.abrirDirectorioToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::HostelSystem.Properties.Resources._1480727338_docs1;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Image = global::HostelSystem.Properties.Resources._1470815916_DeleteRed;
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // generarArchivoPdfToolStripMenuItem
            // 
            this.generarArchivoPdfToolStripMenuItem.Image = global::HostelSystem.Properties.Resources._1480727396_pdfs;
            this.generarArchivoPdfToolStripMenuItem.Name = "generarArchivoPdfToolStripMenuItem";
            this.generarArchivoPdfToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarArchivoPdfToolStripMenuItem.Text = "Generar archivo pdf";
            this.generarArchivoPdfToolStripMenuItem.Click += new System.EventHandler(this.generarArchivoPdfToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // enviarPorCorreoToolStripMenuItem1
            // 
            this.enviarPorCorreoToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources._1469760698_mail_icon;
            this.enviarPorCorreoToolStripMenuItem1.Name = "enviarPorCorreoToolStripMenuItem1";
            this.enviarPorCorreoToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.enviarPorCorreoToolStripMenuItem1.Text = "Enviar por correo";
            this.enviarPorCorreoToolStripMenuItem1.Click += new System.EventHandler(this.enviarPorCorreoToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // regenerarDirectorioToolStripMenuItem
            // 
            this.regenerarDirectorioToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.change_mode;
            this.regenerarDirectorioToolStripMenuItem.Name = "regenerarDirectorioToolStripMenuItem";
            this.regenerarDirectorioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.regenerarDirectorioToolStripMenuItem.Text = "Regenerar directorio";
            this.regenerarDirectorioToolStripMenuItem.Click += new System.EventHandler(this.regenerarDirectorioToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem1
            // 
            this.buscarToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources.search;
            this.buscarToolStripMenuItem1.Name = "buscarToolStripMenuItem1";
            this.buscarToolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.buscarToolStripMenuItem1.Text = "Buscar";
            this.buscarToolStripMenuItem1.Click += new System.EventHandler(this.buscarToolStripMenuItem1_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::HostelSystem.Properties.Resources.update48;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // MenuDGV
            // 
            this.MenuDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem1,
            this.cancelarToolStripMenuItem1,
            this.toolStripSeparator4,
            this.generarArchivoPdfToolStripMenuItem1,
            this.toolStripSeparator1,
            this.enviarPorCorreoToolStripMenuItem});
            this.MenuDGV.Name = "MenuDGV";
            this.MenuDGV.Size = new System.Drawing.Size(179, 104);
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources._1480727338_docs1;
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.abrirToolStripMenuItem1.Text = "Abrir";
            this.abrirToolStripMenuItem1.Click += new System.EventHandler(this.abrirToolStripMenuItem1_Click);
            // 
            // cancelarToolStripMenuItem1
            // 
            this.cancelarToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources._1470815916_DeleteRed;
            this.cancelarToolStripMenuItem1.Name = "cancelarToolStripMenuItem1";
            this.cancelarToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.cancelarToolStripMenuItem1.Text = "Cancelar";
            this.cancelarToolStripMenuItem1.Click += new System.EventHandler(this.cancelarToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // generarArchivoPdfToolStripMenuItem1
            // 
            this.generarArchivoPdfToolStripMenuItem1.Image = global::HostelSystem.Properties.Resources._1480727396_pdfs;
            this.generarArchivoPdfToolStripMenuItem1.Name = "generarArchivoPdfToolStripMenuItem1";
            this.generarArchivoPdfToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.generarArchivoPdfToolStripMenuItem1.Text = "Generar archivo pdf";
            this.generarArchivoPdfToolStripMenuItem1.Click += new System.EventHandler(this.generarArchivoPdfToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // enviarPorCorreoToolStripMenuItem
            // 
            this.enviarPorCorreoToolStripMenuItem.Image = global::HostelSystem.Properties.Resources._1469760698_mail_icon;
            this.enviarPorCorreoToolStripMenuItem.Name = "enviarPorCorreoToolStripMenuItem";
            this.enviarPorCorreoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.enviarPorCorreoToolStripMenuItem.Text = "Enviar por correo";
            this.enviarPorCorreoToolStripMenuItem.Click += new System.EventHandler(this.enviarPorCorreoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(803, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 23);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(751, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 23);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(699, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 23);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(876, 467);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "facturacion";
            this.Text = "facturacion";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtvFacturas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MenuDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.DataGridView DtvFacturas;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuDGV;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem enviarPorCorreoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem enviarPorCorreoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem generarArchivoPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem generarArchivoPdfToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem regenerarDirectorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirDirectorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}