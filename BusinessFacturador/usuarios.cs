using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HostelSystem
{
    public partial class usuarios : Form
    {
        Conexion coneccion = new Conexion();
        Datos datos = new Datos();
        public usuarios()
        {
            InitializeComponent();
            FormatWindows();
        }
        private void FormatWindows()
        {
            GbUsuarios.Width = this.Width;
            GbUsuarios.Height = this.Height;

            GbUsuarios.Top = this.Top;
            GbUsuarios.Left = this.Left;

            LoadUsers();

            ComboBoxNivel.SelectedIndex = 1;
        }
        public void LoadUsers()
        {
            DataGridView dtv = TableUsers;
            dtv.DataSource = null;
            dtv.Rows.Clear();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from usuarios order by id desc";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                while (Reg.Read())
                {
                    dtv.Rows.Add(Reg["id"].ToString(), Reg["username"].ToString(), "******", Reg["level"].ToString().ToUpper());
                }
                dtv.ReadOnly = true;
                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtv.RowHeadersVisible = false;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = false;
                dtv.DefaultCellStyle.SelectionBackColor = Color.Brown;
                dtv.Focus();
                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnAddHuesped_Click(object sender, EventArgs e)
        {
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "insert into usuarios (username,password,level,nombre,apellidos,telefono) values ('" + TxtUsername.Text.Replace(" ", "") + "', '" + TxtPassword.Text.Replace(" ", "") + "','" + ComboBoxNivel.Text.ToLower() + "', '" + TxtName.Text.ToUpper() + "', '" + TxtApellidos.Text.ToUpper() + "', '" + TxtTel.Text + "')";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                MessageBox.Show("Usuario agregado con exito", datos.ReturnDatos("conrfc", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                TxtUsername.Text = "";
                TxtPassword.Text = "";
                TxtName.Text = "";
                TxtApellidos.Text = "";
                TxtTel.Text = "";
                coneccion.cnn.Close();
            }
            catch (Exception a)
            {
                coneccion.cnn.Close();
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void TableUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.TableUsers.Rows[e.RowIndex];

                LoadTxtUpdate(Convert.ToInt32(row.Cells["id"].Value.ToString()));
                if (row.Cells["level"].Value.ToString().ToLower() == "administrador")
                {
                    ComboBoxUpdate.SelectedIndex = 0;
                }
                else
                {
                    ComboBoxUpdate.SelectedIndex = 1;
                }

                BtnDeleteUser.Name = row.Cells["username"].Value.ToString();
                TabUsers.SelectedIndex = 1;
            }
            catch (Exception) { }

            
        }
        private void LoadTxtUpdate(int id)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from usuarios where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    TxtUsernameUpdate.Text = Reg["username"].ToString();
                    TxtPasswordUpdate.Text = Reg["password"].ToString();
                    TxtNameUpdate.Text = Reg["nombre"].ToString();
                    TxtApellidosUpdate.Text = Reg["apellidos"].ToString();
                    TxtTelUpdate.Text = Reg["telefono"].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), datos.ReturnDatos("nombre", 1), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "update usuarios set username = '" + TxtUsernameUpdate.Text.Replace(" ", "") + "', password = '" + TxtPasswordUpdate.Text.Replace(" ", "") + "', level = '" + ComboBoxUpdate.Text.ToString().ToLower() + "', nombre = '" + TxtNameUpdate.Text.ToUpper() + "', apellidos = '" + TxtApellidosUpdate.Text.ToUpper() + "', telefono = '" + TxtTelUpdate.Text + "' where username = '" + BtnDeleteUser.Name + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                MessageBox.Show("Hecho", datos.ReturnDatos("conrfc", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                coneccion.cnn.Close();
                LoadUsers();
                TabUsers.SelectedIndex = 0;
                TxtUsernameUpdate.Text = "";
                TxtPasswordUpdate.Text = "";
                TxtNameUpdate.Text = "";
                TxtApellidosUpdate.Text = "";
                TxtTelUpdate.Text = "";
            }
            catch (Exception a)
            {
                coneccion.cnn.Close();
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar el usuario:" + BtnDeleteUser.Name + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    coneccion.cnn.Close();

                    coneccion.sql = "delete usuarios  where username = '" + BtnDeleteUser.Name + "' ";
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    MessageBox.Show("Hecho", datos.ReturnDatos("conrfc", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    coneccion.cnn.Close();
                    LoadUsers();
                    TabUsers.SelectedIndex = 0;
                    TxtUsernameUpdate.Text = "";
                    TxtPasswordUpdate.Text = "";
                    TxtNameUpdate.Text = "";
                    TxtApellidosUpdate.Text = "";
                    TxtTelUpdate.Text = "";
                    BtnDeleteUser.Name = "boton";
                }
                catch (Exception a)
                {
                    coneccion.cnn.Close();
                    MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
             
        }
    }
}
