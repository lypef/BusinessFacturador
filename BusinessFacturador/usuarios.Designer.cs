namespace HostelSystem
{
    partial class usuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usuarios));
            this.GbUsuarios = new System.Windows.Forms.GroupBox();
            this.TabUsers = new System.Windows.Forms.TabControl();
            this.TabAdd = new System.Windows.Forms.TabPage();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.TxtDate = new System.Windows.Forms.TextBox();
            this.TableUsers = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbAddHuesped = new System.Windows.Forms.GroupBox();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxNivel = new System.Windows.Forms.ComboBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnAddHuesped = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TabModif = new System.Windows.Forms.TabPage();
            this.BtnDeleteUser = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtTelUpdate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtApellidosUpdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNameUpdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboBoxUpdate = new System.Windows.Forms.ComboBox();
            this.TxtPasswordUpdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUsernameUpdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.GbUsuarios.SuspendLayout();
            this.TabUsers.SuspendLayout();
            this.TabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableUsers)).BeginInit();
            this.GbAddHuesped.SuspendLayout();
            this.TabModif.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbUsuarios
            // 
            this.GbUsuarios.Controls.Add(this.TabUsers);
            this.GbUsuarios.Location = new System.Drawing.Point(4, 5);
            this.GbUsuarios.Name = "GbUsuarios";
            this.GbUsuarios.Size = new System.Drawing.Size(852, 406);
            this.GbUsuarios.TabIndex = 2;
            this.GbUsuarios.TabStop = false;
            this.GbUsuarios.Text = "Usuarios";
            // 
            // TabUsers
            // 
            this.TabUsers.Controls.Add(this.TabAdd);
            this.TabUsers.Controls.Add(this.TabModif);
            this.TabUsers.Location = new System.Drawing.Point(6, 13);
            this.TabUsers.Name = "TabUsers";
            this.TabUsers.SelectedIndex = 0;
            this.TabUsers.Size = new System.Drawing.Size(840, 381);
            this.TabUsers.TabIndex = 2;
            // 
            // TabAdd
            // 
            this.TabAdd.BackColor = System.Drawing.SystemColors.Control;
            this.TabAdd.Controls.Add(this.BtnConsultar);
            this.TabAdd.Controls.Add(this.TxtDate);
            this.TabAdd.Controls.Add(this.TableUsers);
            this.TabAdd.Controls.Add(this.GbAddHuesped);
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
            this.BtnConsultar.Location = new System.Drawing.Point(680, 7);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(146, 38);
            this.BtnConsultar.TabIndex = 24;
            this.BtnConsultar.Text = "Consultar";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            // 
            // TxtDate
            // 
            this.TxtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDate.Location = new System.Drawing.Point(404, 12);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(269, 26);
            this.TxtDate.TabIndex = 23;
            // 
            // TableUsers
            // 
            this.TableUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.password,
            this.level});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.TableUsers.Location = new System.Drawing.Point(6, 51);
            this.TableUsers.Name = "TableUsers";
            this.TableUsers.Size = new System.Drawing.Size(820, 124);
            this.TableUsers.TabIndex = 22;
            this.TableUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableUsers_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // username
            // 
            this.username.HeaderText = "NOMBRE DE USUARIO";
            this.username.Name = "username";
            // 
            // password
            // 
            this.password.HeaderText = "CONTRASEÑA";
            this.password.Name = "password";
            // 
            // level
            // 
            this.level.HeaderText = "NIVEL";
            this.level.Name = "level";
            // 
            // GbAddHuesped
            // 
            this.GbAddHuesped.Controls.Add(this.TxtTel);
            this.GbAddHuesped.Controls.Add(this.label7);
            this.GbAddHuesped.Controls.Add(this.TxtApellidos);
            this.GbAddHuesped.Controls.Add(this.label4);
            this.GbAddHuesped.Controls.Add(this.TxtName);
            this.GbAddHuesped.Controls.Add(this.label6);
            this.GbAddHuesped.Controls.Add(this.ComboBoxNivel);
            this.GbAddHuesped.Controls.Add(this.TxtPassword);
            this.GbAddHuesped.Controls.Add(this.BtnAddHuesped);
            this.GbAddHuesped.Controls.Add(this.label1);
            this.GbAddHuesped.Controls.Add(this.TxtUsername);
            this.GbAddHuesped.Controls.Add(this.label5);
            this.GbAddHuesped.Location = new System.Drawing.Point(6, 181);
            this.GbAddHuesped.Name = "GbAddHuesped";
            this.GbAddHuesped.Size = new System.Drawing.Size(820, 168);
            this.GbAddHuesped.TabIndex = 21;
            this.GbAddHuesped.TabStop = false;
            this.GbAddHuesped.Text = "Agregar huesped";
            // 
            // TxtTel
            // 
            this.TxtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtTel.Location = new System.Drawing.Point(137, 101);
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(298, 24);
            this.TxtTel.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(15, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 25;
            this.label7.Text = "TELEFONO :";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtApellidos.Location = new System.Drawing.Point(575, 70);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(239, 24);
            this.TxtApellidos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "NOMBRE:";
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtName.Location = new System.Drawing.Point(575, 34);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(239, 24);
            this.TxtName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(453, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "APELLIDOS :";
            // 
            // ComboBoxNivel
            // 
            this.ComboBoxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxNivel.FormattingEnabled = true;
            this.ComboBoxNivel.Items.AddRange(new object[] {
            "ADMINISTRADOR",
            "STAFF"});
            this.ComboBoxNivel.Location = new System.Drawing.Point(480, 121);
            this.ComboBoxNivel.Name = "ComboBoxNivel";
            this.ComboBoxNivel.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxNivel.TabIndex = 6;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtPassword.Location = new System.Drawing.Point(137, 67);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(298, 24);
            this.TxtPassword.TabIndex = 2;
            // 
            // BtnAddHuesped
            // 
            this.BtnAddHuesped.Image = global::HostelSystem.Properties.Resources.staff;
            this.BtnAddHuesped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddHuesped.Location = new System.Drawing.Point(640, 101);
            this.BtnAddHuesped.Name = "BtnAddHuesped";
            this.BtnAddHuesped.Size = new System.Drawing.Size(174, 58);
            this.BtnAddHuesped.TabIndex = 7;
            this.BtnAddHuesped.Text = "Agregar";
            this.BtnAddHuesped.UseVisualStyleBackColor = true;
            this.BtnAddHuesped.Click += new System.EventHandler(this.BtnAddHuesped_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "USUARIO:";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtUsername.Location = new System.Drawing.Point(137, 31);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(298, 24);
            this.TxtUsername.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(5, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "CONTRASEÑA :";
            // 
            // TabModif
            // 
            this.TabModif.BackColor = System.Drawing.SystemColors.Control;
            this.TabModif.Controls.Add(this.BtnDeleteUser);
            this.TabModif.Controls.Add(this.groupBox2);
            this.TabModif.Location = new System.Drawing.Point(4, 22);
            this.TabModif.Name = "TabModif";
            this.TabModif.Size = new System.Drawing.Size(832, 355);
            this.TabModif.TabIndex = 2;
            this.TabModif.Text = "Modificar";
            // 
            // BtnDeleteUser
            // 
            this.BtnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteUser.ForeColor = System.Drawing.Color.Red;
            this.BtnDeleteUser.Image = global::HostelSystem.Properties.Resources.Ocupada128;
            this.BtnDeleteUser.Location = new System.Drawing.Point(564, 52);
            this.BtnDeleteUser.Name = "BtnDeleteUser";
            this.BtnDeleteUser.Size = new System.Drawing.Size(211, 259);
            this.BtnDeleteUser.TabIndex = 21;
            this.BtnDeleteUser.Text = "Eliminar usuario";
            this.BtnDeleteUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDeleteUser.UseVisualStyleBackColor = true;
            this.BtnDeleteUser.Click += new System.EventHandler(this.BtnDeleteUser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtTelUpdate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtApellidosUpdate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtNameUpdate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ComboBoxUpdate);
            this.groupBox2.Controls.Add(this.TxtPasswordUpdate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtUsernameUpdate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BtnUpdate);
            this.groupBox2.Location = new System.Drawing.Point(23, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 305);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar huesped";
            // 
            // TxtTelUpdate
            // 
            this.TxtTelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtTelUpdate.Location = new System.Drawing.Point(143, 162);
            this.TxtTelUpdate.Name = "TxtTelUpdate";
            this.TxtTelUpdate.Size = new System.Drawing.Size(298, 24);
            this.TxtTelUpdate.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.Location = new System.Drawing.Point(34, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 18);
            this.label10.TabIndex = 31;
            this.label10.Text = "TELEFONO :";
            // 
            // TxtApellidosUpdate
            // 
            this.TxtApellidosUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtApellidosUpdate.Location = new System.Drawing.Point(143, 128);
            this.TxtApellidosUpdate.Name = "TxtApellidosUpdate";
            this.TxtApellidosUpdate.Size = new System.Drawing.Size(298, 24);
            this.TxtApellidosUpdate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "NOMBRE :";
            // 
            // TxtNameUpdate
            // 
            this.TxtNameUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtNameUpdate.Location = new System.Drawing.Point(143, 92);
            this.TxtNameUpdate.Name = "TxtNameUpdate";
            this.TxtNameUpdate.Size = new System.Drawing.Size(298, 24);
            this.TxtNameUpdate.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(28, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "APELLIDOS :";
            // 
            // ComboBoxUpdate
            // 
            this.ComboBoxUpdate.AutoCompleteCustomSource.AddRange(new string[] {
            "ADMINISTRADOR",
            "STAFF"});
            this.ComboBoxUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxUpdate.FormattingEnabled = true;
            this.ComboBoxUpdate.Items.AddRange(new object[] {
            "ADMINISTRADOR",
            "STAFF"});
            this.ComboBoxUpdate.Location = new System.Drawing.Point(153, 219);
            this.ComboBoxUpdate.Name = "ComboBoxUpdate";
            this.ComboBoxUpdate.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxUpdate.TabIndex = 25;
            // 
            // TxtPasswordUpdate
            // 
            this.TxtPasswordUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtPasswordUpdate.Location = new System.Drawing.Point(143, 58);
            this.TxtPasswordUpdate.Name = "TxtPasswordUpdate";
            this.TxtPasswordUpdate.PasswordChar = '*';
            this.TxtPasswordUpdate.Size = new System.Drawing.Size(298, 24);
            this.TxtPasswordUpdate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "USUARIO:";
            // 
            // TxtUsernameUpdate
            // 
            this.TxtUsernameUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.TxtUsernameUpdate.Location = new System.Drawing.Point(143, 22);
            this.TxtUsernameUpdate.Name = "TxtUsernameUpdate";
            this.TxtUsernameUpdate.Size = new System.Drawing.Size(298, 24);
            this.TxtUsernameUpdate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(11, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "CONTRASEÑA :";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.Image = global::HostelSystem.Properties.Resources.update48;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdate.Location = new System.Drawing.Point(120, 246);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(185, 52);
            this.BtnUpdate.TabIndex = 8;
            this.BtnUpdate.Text = "Actualizar";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 420);
            this.Controls.Add(this.GbUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "usuarios";
            this.Text = "usuarios";
            this.GbUsuarios.ResumeLayout(false);
            this.TabUsers.ResumeLayout(false);
            this.TabAdd.ResumeLayout(false);
            this.TabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableUsers)).EndInit();
            this.GbAddHuesped.ResumeLayout(false);
            this.GbAddHuesped.PerformLayout();
            this.TabModif.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbUsuarios;
        private System.Windows.Forms.TabControl TabUsers;
        private System.Windows.Forms.TabPage TabAdd;
        private System.Windows.Forms.DataGridView TableUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn level;
        private System.Windows.Forms.GroupBox GbAddHuesped;
        private System.Windows.Forms.TextBox TxtTel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBoxNivel;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnAddHuesped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage TabModif;
        private System.Windows.Forms.Button BtnDeleteUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtTelUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtApellidosUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNameUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ComboBoxUpdate;
        private System.Windows.Forms.TextBox TxtPasswordUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUsernameUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.TextBox TxtDate;
    }
}