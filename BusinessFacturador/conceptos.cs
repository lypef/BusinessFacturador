using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HostelSystem
{
    public partial class conceptos : Form
    {
        Conexion coneccion = new Conexion();
        public conceptos()
        {
            InitializeComponent();
            loadConceptos(DtvConceptos, "select * from conceptos");
        }

        private void loadConceptos(DataGridView dtv, string consulta)
        {
            dtv.DataSource = null;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = consulta;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);

                SqlDataAdapter da = new SqlDataAdapter(coneccion.comandosql);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dtv.DataSource = dt;

                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dtv.Columns["id"].HeaderText = "ID";
                dtv.Columns["concepto"].HeaderText = "CONCEPTO";
                dtv.Columns["monto"].HeaderText = "MONTO";
                
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
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnAddHuesped_Click(object sender, EventArgs e)
        {
            AddConcepto();
        }

        private void AddConcepto()
        {
            if (TxtConcepto.Text.Replace(" ", "") != "" && Txt_id.Text.Replace(" ", "") != "")
            {
                try
                {
                    coneccion.cnn.Close();

                    coneccion.sql = "insert into conceptos (id,concepto, monto) values ('"+Txt_id.Text+"','" + TxtConcepto.Text.ToUpper() + "', '" + TxtMonto.Text.ToUpper() + "' )";
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    loadConceptos(DtvConceptos, "select * from conceptos");
                    coneccion.mensaje = "Concepto agregado";
                    coneccion.cnn.Close();
                    if (MessageBox.Show(coneccion.mensaje, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        TxtConcepto.Text = "";
                        TxtMonto.Text = "";
                        Txt_id.Text = "";
                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("INSERTE COMO MINIMO UN CONCEPTO", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            SearchConcepto();
        }

        private void SearchConcepto()
        {
            loadConceptos(DtvConceptos, "select * from conceptos where concepto like '%" + TxtSearchConcepto.Text + "%' ");
        }

        private void TxtSearchConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                SearchConcepto();
            }
        }

       
        private void FunctionEditConcepto(Decimal id)
        {
            BtnDeleteHuesped.Name = id.ToString();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from conceptos where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    txt_id_edit.Text = Reg[0].ToString();
                    TxtConceptoEdit.Text = Reg[1].ToString();
                    TxtMontoEdit.Text = Reg[2].ToString();
                }

                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DtvConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.DtvConceptos.Rows[e.RowIndex];
                FunctionEditConcepto(Decimal.Parse(row.Cells["id"].Value.ToString()));
                TabHuespedes.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateConcepto();
        }

        private void UpdateConcepto()
        {
            try
            {
                if (MessageBox.Show("El concepto se actualizara con los cambios establecidos. ¿Esta seguro?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UpdateConcepto(Decimal.Parse(BtnDeleteHuesped.Name));
                    CleanModif();
                    loadConceptos(DtvConceptos, "select * from conceptos");
                    TabHuespedes.SelectedIndex = 0;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CleanModif()
        {
            TxtConceptoEdit.Text = "";
            TxtMontoEdit.Text = "";
            BtnDeleteHuesped.Name = "boton";
        }
        private void UpdateConcepto(Decimal id)
        {
            try
            {
                coneccion.sql = "update conceptos set id = '"+txt_id_edit.Text.Replace(" ","")+"', concepto = '" + TxtConceptoEdit.Text.ToUpper() + "', monto = '" + TxtMontoEdit.Text.ToUpper() + "' where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                MessageBox.Show("Concepto actualizado.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnDeleteHuesped_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("El concepto sera eliminado permanententemente. ¿Esta seguro?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteConcepto(Convert.ToInt32(BtnDeleteHuesped.Name));
                    CleanModif();
                    loadConceptos(DtvConceptos, "select * from conceptos");
                    TabHuespedes.SelectedIndex = 0;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DeleteConcepto(int id)
        {
            try
            {
                coneccion.sql = "delete from conceptos where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                MessageBox.Show("Concepto Eliminado.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void TxtConceptoEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                UpdateConcepto();
            }
        }

        private void TxtMontoEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                UpdateConcepto();
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                AddConcepto();
            }
        }
    }
}
