namespace HostelSystem
{
    partial class conceptos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conceptos));
            this.Gbhuesped = new System.Windows.Forms.GroupBox();
            this.TabHuespedes = new System.Windows.Forms.TabControl();
            this.TabAdd = new System.Windows.Forms.TabPage();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.TxtSearchConcepto = new System.Windows.Forms.TextBox();
            this.DtvConceptos = new System.Windows.Forms.DataGridView();
            this.BtnAddHuesped = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtConcepto = new System.Windows.Forms.TextBox();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.TabModif = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtConceptoEdit = new System.Windows.Forms.TextBox();
            this.TxtMontoEdit = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDeleteHuesped = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_id_edit = new System.Windows.Forms.TextBox();
            this.Gbhuesped.SuspendLayout();
            this.TabHuespedes.SuspendLayout();
            this.TabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvConceptos)).BeginInit();
            this.TabModif.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gbhuesped
            // 
            this.Gbhuesped.Controls.Add(this.TabHuespedes);
            this.Gbhuesped.Location = new System.Drawing.Point(14, 5);
            this.Gbhuesped.Name = "Gbhuesped";
            this.Gbhuesped.Size = new System.Drawing.Size(852, 406);
            this.Gbhuesped.TabIndex = 3;
            this.Gbhuesped.TabStop = false;
            this.Gbhuesped.Text = "CLIENTES";
            // 
            // TabHuespedes
            // 
            this.TabHuespedes.Controls.Add(this.TabAdd);
            this.TabHuespedes.Controls.Add(this.TabModif);
            this.TabHuespedes.Location = new System.Drawing.Point(6, 19);
            this.TabHuespedes.Name = "TabHuespedes";
            this.TabHuespedes.SelectedIndex = 0;
            this.TabHuespedes.Size = new System.Drawing.Size(840, 381);
            this.TabHuespedes.TabIndex = 0;
            // 
            // TabAdd
            // 
            this.TabAdd.BackColor = System.Drawing.SystemColors.Control;
            this.TabAdd.Controls.Add(this.label4);
            this.TabAdd.Controls.Add(this.Txt_id);
            this.TabAdd.Controls.Add(this.BtnConsultar);
            this.TabAdd.Controls.Add(this.TxtSearchConcepto);
            this.TabAdd.Controls.Add(this.DtvConceptos);
            this.TabAdd.Controls.Add(this.BtnAddHuesped);
            this.TabAdd.Controls.Add(this.label1);
            this.TabAdd.Controls.Add(this.label6);
            this.TabAdd.Controls.Add(this.TxtConcepto);
            this.TabAdd.Controls.Add(this.TxtMonto);
            this.TabAdd.Location = new System.Drawing.Point(4, 22);
            this.TabAdd.Name = "TabAdd";
            this.TabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.TabAdd.Size = new System.Drawing.Size(832, 355);
            this.TabAdd.TabIndex = 0;
            this.TabAdd.Text = "Agregar";
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.BtnConsultar.Location = new System.Drawing.Point(678, 76);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(146, 33);
            this.BtnConsultar.TabIndex = 5;
            this.BtnConsultar.Text = "Consultar";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // TxtSearchConcepto
            // 
            this.TxtSearchConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchConcepto.Location = new System.Drawing.Point(405, 79);
            this.TxtSearchConcepto.Name = "TxtSearchConcepto";
            this.TxtSearchConcepto.Size = new System.Drawing.Size(269, 26);
            this.TxtSearchConcepto.TabIndex = 4;
            this.TxtSearchConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearchConcepto_KeyPress);
            // 
            // DtvConceptos
            // 
            this.DtvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtvConceptos.Location = new System.Drawing.Point(13, 115);
            this.DtvConceptos.Name = "DtvConceptos";
            this.DtvConceptos.Size = new System.Drawing.Size(807, 227);
            this.DtvConceptos.TabIndex = 67;
            this.DtvConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtvConceptos_CellDoubleClick);
            // 
            // BtnAddHuesped
            // 
            this.BtnAddHuesped.Image = global::HostelSystem.Properties.Resources.Add_32;
            this.BtnAddHuesped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddHuesped.Location = new System.Drawing.Point(678, 6);
            this.BtnAddHuesped.Name = "BtnAddHuesped";
            this.BtnAddHuesped.Size = new System.Drawing.Size(148, 54);
            this.BtnAddHuesped.TabIndex = 4;
            this.BtnAddHuesped.Text = "Agregar";
            this.BtnAddHuesped.UseVisualStyleBackColor = true;
            this.BtnAddHuesped.Click += new System.EventHandler(this.BtnAddHuesped_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "CONCEPTO :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(311, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 66;
            this.label6.Text = "MONTO :";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtConcepto.Location = new System.Drawing.Point(129, 6);
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(543, 24);
            this.TxtConcepto.TabIndex = 1;
            // 
            // TxtMonto
            // 
            this.TxtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtMonto.Location = new System.Drawing.Point(390, 36);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(282, 24);
            this.TxtMonto.TabIndex = 3;
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            // 
            // TabModif
            // 
            this.TabModif.BackColor = System.Drawing.SystemColors.Control;
            this.TabModif.Controls.Add(this.label5);
            this.TabModif.Controls.Add(this.txt_id_edit);
            this.TabModif.Controls.Add(this.label2);
            this.TabModif.Controls.Add(this.label3);
            this.TabModif.Controls.Add(this.TxtConceptoEdit);
            this.TabModif.Controls.Add(this.TxtMontoEdit);
            this.TabModif.Controls.Add(this.BtnUpdate);
            this.TabModif.Controls.Add(this.BtnDeleteHuesped);
            this.TabModif.Location = new System.Drawing.Point(4, 22);
            this.TabModif.Name = "TabModif";
            this.TabModif.Size = new System.Drawing.Size(832, 355);
            this.TabModif.TabIndex = 2;
            this.TabModif.Text = "Modificar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 107;
            this.label2.Text = "CONCEPTO :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(57, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 108;
            this.label3.Text = "MONTO :";
            // 
            // TxtConceptoEdit
            // 
            this.TxtConceptoEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtConceptoEdit.Location = new System.Drawing.Point(136, 22);
            this.TxtConceptoEdit.Name = "TxtConceptoEdit";
            this.TxtConceptoEdit.Size = new System.Drawing.Size(543, 24);
            this.TxtConceptoEdit.TabIndex = 1;
            this.TxtConceptoEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConceptoEdit_KeyPress);
            // 
            // TxtMontoEdit
            // 
            this.TxtMontoEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtMontoEdit.Location = new System.Drawing.Point(136, 52);
            this.TxtMontoEdit.Name = "TxtMontoEdit";
            this.TxtMontoEdit.Size = new System.Drawing.Size(543, 24);
            this.TxtMontoEdit.TabIndex = 2;
            this.TxtMontoEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoEdit_KeyPress);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Image = global::HostelSystem.Properties.Resources.update48;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdate.Location = new System.Drawing.Point(689, 15);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(133, 41);
            this.BtnUpdate.TabIndex = 4;
            this.BtnUpdate.Text = "Actualizar";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDeleteHuesped
            // 
            this.BtnDeleteHuesped.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteHuesped.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteHuesped.Image = global::HostelSystem.Properties.Resources._1470815916_DeleteRed;
            this.BtnDeleteHuesped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeleteHuesped.Location = new System.Drawing.Point(689, 65);
            this.BtnDeleteHuesped.Name = "BtnDeleteHuesped";
            this.BtnDeleteHuesped.Size = new System.Drawing.Size(133, 41);
            this.BtnDeleteHuesped.TabIndex = 5;
            this.BtnDeleteHuesped.Text = "Eliminar";
            this.BtnDeleteHuesped.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteHuesped.UseVisualStyleBackColor = true;
            this.BtnDeleteHuesped.Click += new System.EventHandler(this.BtnDeleteHuesped_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(93, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "ID :";
            // 
            // Txt_id
            // 
            this.Txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Txt_id.Location = new System.Drawing.Point(129, 36);
            this.Txt_id.Name = "Txt_id";
            this.Txt_id.Size = new System.Drawing.Size(176, 24);
            this.Txt_id.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(57, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 18);
            this.label5.TabIndex = 110;
            this.label5.Text = "ID :";
            // 
            // txt_id_edit
            // 
            this.txt_id_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_id_edit.Location = new System.Drawing.Point(136, 82);
            this.txt_id_edit.Name = "txt_id_edit";
            this.txt_id_edit.Size = new System.Drawing.Size(543, 24);
            this.txt_id_edit.TabIndex = 3;
            // 
            // conceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 417);
            this.Controls.Add(this.Gbhuesped);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "conceptos";
            this.Text = "conceptos";
            this.Gbhuesped.ResumeLayout(false);
            this.TabHuespedes.ResumeLayout(false);
            this.TabAdd.ResumeLayout(false);
            this.TabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtvConceptos)).EndInit();
            this.TabModif.ResumeLayout(false);
            this.TabModif.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gbhuesped;
        private System.Windows.Forms.TabControl TabHuespedes;
        private System.Windows.Forms.TabPage TabAdd;
        private System.Windows.Forms.Button BtnAddHuesped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtConcepto;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.TabPage TabModif;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDeleteHuesped;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.TextBox TxtSearchConcepto;
        private System.Windows.Forms.DataGridView DtvConceptos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtConceptoEdit;
        private System.Windows.Forms.TextBox TxtMontoEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_id_edit;
    }
}