using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HostelSystem
{
    public partial class clientes : Form
    {
        Conexion coneccion = new Conexion();
        public clientes()
        {
            InitializeComponent();
        }

        private void BtnAddHuesped_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text.Replace(" ", "") != "")
            {
                try
                {
                    coneccion.cnn.Close();

                    coneccion.sql = "insert into clientes (nombre, rfc, razonsocial, mail, calle, noext, noint, colonia, loc, municipio, estado, pais, cp, telefono) values ('"+ TxtNombre.Text.ToUpper() + "', '" + TxtRfc.Text.ToUpper() + "', '" + TxtRsocial.Text.ToUpper() + "', '" + TxtMail.Text.ToUpper()  + "', '" + TxtCalle.Text.ToUpper()  + "', '" + TxtNoExt.Text.ToUpper() + "', '" + TxtNoInt.Text.ToUpper()  + "', '" + TxtColonia.Text.ToUpper()  + "', '" + TxtLocalidad.Text.ToUpper()  + "', '" + TxtMunicipio.Text.ToUpper()  + "', '" + TxtEstado.Text.ToUpper()  + "', '" + TxtPais.Text.ToUpper()  + "', '" + TxtCP.Text.ToUpper()  + "' , '"+ TxtTel.Text.ToUpper() +"')";
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    coneccion.mensaje = "Cliente agregado";
                    coneccion.cnn.Close();
                    if (MessageBox.Show(coneccion.mensaje, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        TxtNombre.Text = "";
                        TxtMail.Text = "";
                        TxtRfc.Text = "";
                        TxtRsocial.Text = "";
                        TxtCalle.Text = "";
                        TxtNoExt.Text = "";
                        TxtNoInt.Text = "";
                        TxtColonia.Text = "";
                        TxtLocalidad.Text = "";
                        TxtMunicipio.Text = "";
                        TxtEstado.Text = "";
                        TxtPais.Text = "";
                        TxtCP.Text = "";
                        TxtTel.Text.ToUpper();
                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("INSERTE COMO MINIMO UN NOMBRE", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void TabHuespedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabHuespedes.SelectedIndex == 1)
            {
                loadClientes(DgConsultarClientes, "select * from clientes");
            }
            if (TabHuespedes.SelectedIndex != 2)
            {
                CleanModif();
            }
            
        }

        private void loadClientes(DataGridView dtv, string consulta)
        {
            DgConsultarClientes.DataSource = null;
            try
            {
                coneccion.sql = consulta;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);

                SqlDataAdapter da = new SqlDataAdapter(coneccion.comandosql);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dtv.DataSource = dt;

                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dtv.Columns["id"].HeaderText = "ID";
                dtv.Columns["nombre"].HeaderText = "NOMBRE";
                dtv.Columns["rfc"].HeaderText = "RFC";
                dtv.Columns["razonsocial"].HeaderText = "RAZON SOCIAL";


                dtv.Columns["telefono"].Visible = false;
                dtv.Columns["mail"].Visible = false;
                dtv.Columns["calle"].Visible = false;
                dtv.Columns["noext"].Visible = false;
                dtv.Columns["noint"].Visible = false;
                dtv.Columns["colonia"].Visible = false;
                dtv.Columns["loc"].Visible = false;
                dtv.Columns["estado"].Visible = false;
                dtv.Columns["pais"].Visible = false;
                dtv.Columns["cp"].Visible = false;
                dtv.Columns["municipio"].Visible = false;


                dtv.ReadOnly = true;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = false;
                dtv.DefaultCellStyle.SelectionBackColor = Color.Brown;
                dtv.RowHeadersVisible = false;
                dtv.DefaultCellStyle.SelectionBackColor = Color.Brown;
                dtv.Focus();
                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            SearchCliente();
        }

        private void SearchCliente()
        {
            loadClientes(DgConsultarClientes, "select * from clientes where nombre like  '%" + TxtSearchClient.Text + "%' or rfc like  '%" + TxtSearchClient.Text + "%' or razonsocial like  '%" + TxtSearchClient.Text + "%' ");
        }

        private void TxtSearchClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                SearchCliente();
            }
        }

        private void FunctionEditClient(int id)
        {
            BtnDeleteHuesped.Name = id.ToString();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from clientes where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    TxtNombreEdit.Text = Reg[1].ToString();
                    TxtEmailEdit.Text = Reg[2].ToString();
                    TxtRfcEdit.Text = Reg[3].ToString();
                    TxtRsocialEdit.Text = Reg[4].ToString();
                    TxtCalleEdit.Text = Reg[5].ToString();
                    TxtNoExtEdit.Text = Reg[6].ToString();
                    TxtNoIntEdit.Text = Reg[7].ToString();
                    TxtColoniaEdit.Text = Reg[8].ToString();
                    TxtLocalidadEdit.Text = Reg[9].ToString();
                    TxtMunicipioEdit.Text = Reg[10].ToString();
                    TxtEstadoEdit.Text = Reg[11].ToString();
                    TxtPaisEdit.Text = Reg[12].ToString();
                    TxtCpEdit.Text = Reg[13].ToString();
                    TxtTelEdit.Text = Reg[14].ToString();
                }

                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnDeleteHuesped_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("El cliente sera eliminado permanententemente. ¿Esta seguro?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteCliente(Convert.ToInt32(BtnDeleteHuesped.Name));
                    CleanModif();
                    TabHuespedes.SelectedIndex = 1;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CleanModif()
        {
            TxtNombreEdit.Text = "";
            TxtEmailEdit.Text = "";
            TxtRfcEdit.Text = "";
            TxtRsocialEdit.Text = "";
            TxtCalleEdit.Text = "";
            TxtNoExtEdit.Text = "";
            TxtNoIntEdit.Text = "";
            TxtColoniaEdit.Text = "";
            TxtLocalidadEdit.Text = "";
            TxtMunicipioEdit.Text = "";
            TxtEstadoEdit.Text = "";
            TxtPaisEdit.Text = "";
            TxtCpEdit.Text = "";
            TxtTelEdit.Text = "";
            BtnDeleteHuesped.Name = "boton";
        }

        private void DeleteCliente(int id)
        {
            try
            {
                coneccion.sql = "delete from clientes where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                MessageBox.Show("Cliente Eliminado.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("El huesped se actualizara con los cambios establecidos. ¿Esta seguro?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UpdateCliente(Convert.ToInt32(BtnDeleteHuesped.Name));
                    CleanModif();
                    TabHuespedes.SelectedIndex = 1;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void UpdateCliente(int id)
        {
            try
            {
                coneccion.sql = "update clientes set nombre = '" + TxtNombreEdit.Text.ToUpper() + "', mail = '" + TxtEmailEdit.Text.ToUpper() + "', rfc = '" + TxtRfcEdit.Text.ToUpper() + "', razonsocial = '" + TxtRsocialEdit.Text.ToUpper() + "', calle = '" + TxtCalleEdit.Text.ToUpper() + "', noext = '" + TxtNoExtEdit.Text.ToUpper() + "', noint = '" + TxtNoIntEdit.Text.ToUpper() + "', colonia = '" + TxtColoniaEdit.Text.ToUpper() + "', loc = '" + TxtLocalidadEdit.Text.ToUpper() + "', municipio = '" + TxtMunicipioEdit.Text.ToUpper() + "', estado = '" + TxtEstadoEdit.Text.ToUpper() + "', pais = '" + TxtPaisEdit.Text.ToUpper() + "', cp = '" + TxtCpEdit.Text.ToUpper() + "', telefono = '"+ TxtTelEdit.Text.ToUpper() + "' where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                MessageBox.Show("Cliente actualizado.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DgConsultarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.DgConsultarClientes.Rows[e.RowIndex];
                FunctionEditClient(Convert.ToInt32(row.Cells["id"].Value.ToString()));
                TabHuespedes.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
