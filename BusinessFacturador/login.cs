using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HostelSystem
{
    public partial class login : Form
    {
        Conexion coneccion = new Conexion();
        public login()
        {
            InitializeComponent();
            BtnSession.BackColor = Color.FromArgb(0, 188, 212);
            this.CenterToScreen();
        }

        private void BtnSession_Click(object sender, EventArgs e)
        {
            loadsession();
        }

        private void loadsession()
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from usuarios where username = '" + TxtUsuario.Text.Replace(" ", "") + "' and password = '" + TxtPassword.Text + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    Control control = new Control(Reg["level"].ToString(), Convert.ToInt32(Reg["id"].ToString()));
                    control.Show();
                    this.Visible = false;
                    coneccion.cnn.Close();
                }
                else
                {
                    coneccion.cnn.Close();
                    TxtUsuario.Text = "";
                    TxtPassword.Text = "";
                    MessageBox.Show("Error, acceso no autorizado","NO FOUND", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtUsuario.Focus();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            TxtPassword.Text = "";
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                loadsession();
            }
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                TxtPassword.Focus();
            }
        }

        private void TxtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            TxtUsuario.Text = "";
        }
    }
}
