using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Multifacturas.SDK;
using System.Globalization;
using System.Threading;

namespace HostelSystem
{
    public partial class NewFactura : Form
    {
        Conexion coneccion = new Conexion();
        Datos datos = new Datos();
        int status = 0, mov = 0;
        public NewFactura()
        {
            InitializeComponent();
            this.CenterToScreen();
            loadventas(DtvVentas, "select * from conceptos  order by id desc");            
            LoadDtvHuespeds(DtvClientes, "select * from clientes order by nombre desc");
            LoadReadyFact(DtvProductFact);
            MetodPago.SelectedIndex = 0;
            TipoComprobante.SelectedIndex = 0;
        }

        private void LoadReadyFact(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                dtv.Columns.Clear();

                dtv.Columns.Add("id", "ID");
                dtv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.Columns.Add("concepto", "CONCEPTO");

                dtv.Columns.Add("monto", "MONTO");
                dtv.Columns["monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.ReadOnly = true;
                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtv.RowHeadersVisible = false;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = true;
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
        private void LoadReadyFactAdd(DataGridView dtv, string id, string concepto, string precio)
        {
            try
            {
                dtv.Rows.Add(id, concepto, precio);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LoadDtvHuespeds(DataGridView dtv, string consulta)
        {
            dtv.DataSource = null;
            dtv.Rows.Clear();
            dtv.Columns.Clear();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = consulta;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                dtv.Columns.Add("id", "ID");
                dtv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.Columns.Add("nombre", "NOMBRE");
                dtv.Columns.Add("rfc", "RFC");
                dtv.Columns.Add("razonsocial", "RAZON SOCIAL");
                dtv.Columns.Add("mail", "MAIL");

                dtv.Columns["razonsocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;


                while (Reg.Read())
                {
                    dtv.Rows.Add(Reg["id"].ToString(), Reg["nombre"].ToString().ToUpper(), Reg["rfc"].ToString().ToUpper(), Reg["razonsocial"].ToString().ToUpper(), Reg["mail"].ToString());
                }

                dtv.ReadOnly = true;
                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtv.RowHeadersVisible = false;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (status == 0)
            {
                if (mov == 1)
                {
                    loadventas(DtvVentas, "select * from conceptos  order by id desc");
                    LoadDtvHuespeds(DtvClientes, "select * from clientes order by nombre desc");
                    LoadReadyFact(DtvProductFact);
                    mov = 0;
                }
                else
                {
                    BackgroundWorker process = new BackgroundWorker();
                    process.DoWork += Facturar;
                    process.RunWorkerAsync();
                }
            }else
            {
                MessageBox.Show("Otra factura esta en proceso, porfavor espere.","ESPERE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FacturarActionProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Increment(Convert.ToInt32(e));
        }
        
        private void Facturar(object sender, DoWorkEventArgs e)
        {
            status = 1;
            
            List<Concepto> conceptos = new List<Concepto>();

            Concepto concepto;

            string articulos = "";
            double total = 0;

            CultureInfo ci = new CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;

            foreach (DataGridViewRow item in DtvProductFact.Rows)
            {
                if (item.Cells[0].Value != null)
                {
                    articulos += item.Cells["concepto"].Value.ToString() + ", MONTO $" + item.Cells["monto"].Value.ToString() + "\n";
                    total += double.Parse(item.Cells["monto"].Value.ToString());

                    concepto = new Concepto("1", "pieza", item.Cells["id"].Value.ToString(), item.Cells["concepto"].Value.ToString(), item.Cells["monto"].Value.ToString(), item.Cells["monto"].Value.ToString());

                    conceptos.Add(concepto);
                }
            }

            DataGridViewRow row = DtvClientes.CurrentRow;
            int huesped = Convert.ToInt32(row.Cells["id"].Value);

            if (MessageBox.Show("SE EMITIRA LA SIGUIENTE FACTURA.\n\n" + articulos + "\nTOTAL: $" + total.ToString() + "\n\nPARA EL HUESPED: " + datos.ReturnDatosCliente(Convert.ToInt32(row.Cells["id"].Value), "nombre") + "(" + datos.ReturnDatosCliente(Convert.ToInt32(row.Cells["id"].Value), "RFC") + ")", "EMISION FACTURA - " + datos.ReturnDatos("connombre", 1) + " - "+ datos.ReturnDatos("conrfc", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                mov = 1;
                Image1.Load(coneccion.ReturnLocalData()+@"\resources\spin.gif");
                Image1.SizeMode = PictureBoxSizeMode.Zoom;
                Image2.Load(coneccion.ReturnLocalData() + @"\resources\spin.gif");
                Image2.SizeMode = PictureBoxSizeMode.Zoom;

                facturacion form = new facturacion();

                string MetodoPagoInvoke = "", TipoComprobanteInvoke = "";

                if (InvokeRequired)
                {
                    Invoke(new Action(() => MetodoPagoInvoke = MetodPago.Text));
                    Invoke(new Action(() => TipoComprobanteInvoke = TipoComprobante.Text));
                }

                if (form.FactAction(conceptos, huesped, MetodoPagoInvoke, TipoComprobanteInvoke) == 0)
                {
                    Image1.Image = Properties.Resources.Libre128;
                    Image2.Image = Properties.Resources.Libre128;
                }
                else
                {
                    Image1.Image = Properties.Resources.Ocupada128;
                    Image2.Image = Properties.Resources.Ocupada128;
                }
                form.Dispose();
                status = 0;
            }
            else
            {
                status = 0;
            }
            ci.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        private void loadventas(DataGridView dtv, string consulta)
        {
            dtv.DataSource = null;
            dtv.Rows.Clear();
            dtv.Columns.Clear();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = consulta;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                dtv.Columns.Add("id", "ID");
                dtv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.Columns.Add("concepto", "CONCEPTO");
                
                dtv.Columns.Add("monto", "MONTO");
                dtv.Columns["monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;


                while (Reg.Read())
                {
                    dtv.Rows.Add(Reg["id"].ToString(), Reg["concepto"].ToString().ToUpper(), Reg["monto"].ToString());
                }

                dtv.ReadOnly = true;
                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtv.RowHeadersVisible = false;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = true;
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
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtHuesped_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddProductFAct();
        }

        private void AddProductFAct()
        {
            if (mov == 1)
            {
                loadventas(DtvVentas, "select * from conceptos  order by id desc");
                LoadDtvHuespeds(DtvClientes, "select * from clientes order by nombre desc");
                LoadReadyFact(DtvProductFact);
                mov = 0;
            }else
            {
                try
                {
                    DataGridViewRow row = this.DtvVentas.CurrentRow;
                    LoadReadyFactAdd(DtvProductFact, row.Cells["id"].Value.ToString(), row.Cells["concepto"].Value.ToString(), row.Cells["monto"].Value.ToString().Replace(",", "."));
                }catch(Exception)
                {
                    MessageBox.Show("Verifique su seleccion", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DtvProductFact.Rows.RemoveAt(DtvProductFact.CurrentRow.Index);
            }catch (Exception) { }
        }

        private void DtvVentas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    this.ContextMenuStrip = this.MenuVentas;
                }
                catch (Exception)
                { }
            }   
        }

        private void DtvProductFact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    this.ContextMenuStrip = this.MenuProductFact;
                }
                catch (Exception)
                { }
            }
        }

        private void agregarAFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductFAct();
        }

        private void DtvProductFact_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mov == 1)
            {
                loadventas(DtvVentas, "select * from ventas  order by id desc");
                LoadDtvHuespeds(DtvClientes, "select * from huespedes order by id desc");
                LoadReadyFact(DtvProductFact);
                mov = 0;
            }else
            {
                try
                {
                    DtvProductFact.Rows.RemoveAt(DtvProductFact.CurrentRow.Index);
                }
                catch (Exception)
                {
                    MessageBox.Show("Verifique su seleccion", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchVentas();
        }

        private void SearchVentas()
        {
            loadventas(DtvVentas, "select * from conceptos where concepto like '%" + TxtConceptos.Text + "%' order by id desc");
            TxtConceptos.Focus();
        }

        private void TxtConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                SearchVentas();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchClientes();
        }

        private void SearchClientes()
        {
            LoadDtvHuespeds(DtvClientes, "select * from clientes where nombre like '%"+ TxtHuesped.Text + "%' or rfc like '%" + TxtHuesped.Text + "%' or razonsocial like '%" + TxtHuesped.Text + "%' order by nombre desc");
            TxtHuesped.Focus();
        }

        private void TxtHuesped_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                SearchClientes();
            }
        }

        private void DtvHuespedes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = DtvClientes.CurrentRow;
                loadventas(DtvVentas, "select * from ventas where id_huesped = '" + row.Cells["id"].Value + "' order by id desc");
            }
            catch (Exception)
            {
               MessageBox.Show("Verifique su seleccion", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
            }
        }

    }
}
