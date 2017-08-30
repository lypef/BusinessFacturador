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
            CleanDGV();
        }

        private void LoadReadyFact(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                dtv.Columns.Clear();

                dtv.Columns.Add("id", "ID");
                dtv.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dtv.Columns.Add("unidad", "UNIDAD");
                dtv.Columns.Add("cantidad", "CANTIDAD");
                dtv.Columns.Add("concepto", "CONCEPTO");

                dtv.Columns.Add("monto", "MONTO");
                dtv.Columns["monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                
                dtv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtv.RowHeadersVisible = false;
                dtv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtv.MultiSelect = true;
                dtv.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
                dtv.Focus();
                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LoadReadyFactAdd(DataGridView dtv, string id, int cantidad, string unidad, string concepto, string precio)
        {
            try
            {
                dtv.Rows.Add( id, unidad.ToUpper(), cantidad, concepto.ToUpper(), precio);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LoadDtvHuespeds(ComboBox combo, string consulta)
        {
            combo.Items.Clear();
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = consulta;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                while (Reg.Read())
                {
                    combo.Items.Add(Reg["nombre"].ToString().ToUpper() + "," + Reg["rfc"].ToString().ToUpper() + ". ["+ Reg["id"].ToString() + "]");
                }

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
                    CleanDGV();
                }
                else
                {
                    facturacion form = new facturacion();
                    form.RestoreDirectoryFacturas();
                    form.Dispose();
                    BackgroundWorker process = new BackgroundWorker();
                    process.DoWork += Facturar;
                    process.RunWorkerCompleted += FacturarComplet;
                    process.RunWorkerAsync();
                }
            }else
            {
                MessageBox.Show("Otra factura esta en proceso, porfavor espere.","ESPERE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FacturarComplet(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mov == 1)
            {
                CleanDGV();
            }
        }

        private void CleanDGV()
        {
            loadventas(DtvVentas, "select * from conceptos  order by id desc");
            LoadDtvHuespeds(ComboClientes, "select * from clientes order by nombre desc");
            LoadReadyFact(DtvProductFact);
            MetodPago.SelectedIndex = 0;
            TipoComprobante.SelectedIndex = 0;
            Image1.Image = null;
            Image2.Image = null;
            mov = 0;
            TxtIdentificador.Text = "";
            TxtManualConcepto.Text = "";
            TxtManualMonto.Text = "";
        }

        private void FacturarActionProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Increment(Convert.ToInt32(e));
        }

        private void Facturar(object sender, DoWorkEventArgs e)
        {
            string a = "";

            if (InvokeRequired)
            {
                Invoke(new Action(() => a = ComboClientes.Text));
            }
            String[] substrings = a.Split('[');
            int huesped = 0;
            try {
                huesped = Convert.ToInt32(substrings[1].Replace("]", ""));
            }
            catch (Exception){}

            if (huesped > 0)
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
                        articulos += item.Cells["cantidad"].Value.ToString() + " " + item.Cells["concepto"].Value.ToString() + ", MONTO $" + item.Cells["monto"].Value.ToString() + " C/U\n";
                        total += double.Parse(item.Cells["cantidad"].Value.ToString()) * double.Parse(item.Cells["monto"].Value.ToString());

                        concepto = new Concepto(item.Cells["cantidad"].Value.ToString(), item.Cells["unidad"].Value.ToString().ToUpper(), item.Cells["id"].Value.ToString(), item.Cells["concepto"].Value.ToString().ToUpper(), item.Cells["monto"].Value.ToString(), item.Cells["monto"].Value.ToString());

                        conceptos.Add(concepto);
                    }
                }



                if (MessageBox.Show("SE EMITIRA LA SIGUIENTE FACTURA.\n\n" + articulos + "\nTOTAL: $" + total.ToString() + "\n\nPARA EL HUESPED: " + datos.ReturnDatosCliente(huesped, "nombre") + "(" + datos.ReturnDatosCliente(huesped, "RFC") + ")", "EMISION FACTURA - " + datos.ReturnDatos("connombre", 1) + " - " + datos.ReturnDatos("conrfc", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mov = 1;
                    Image1.Load(coneccion.ReturnLocalData() + @"\resources\spin.gif");
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
            }else
            {
                MessageBox.Show("Seleccione un cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
                dtv.Columns.Add("unidad", "UNIDAD");
                dtv.Columns.Add("cantidad", "CANTIDAD");
                dtv.Columns.Add("concepto", "CONCEPTO");
                
                dtv.Columns.Add("monto", "MONTO");
                dtv.Columns["monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;


                while (Reg.Read())
                {
                    dtv.Rows.Add(Reg["id"].ToString(),"N/A",1, Reg["concepto"].ToString().ToUpper(), Reg["monto"].ToString());
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
                CleanDGV();
            }else
            {
                try
                {
                    DataGridViewRow row = this.DtvVentas.CurrentRow;
                    LoadReadyFactAdd(DtvProductFact, row.Cells["id"].Value.ToString(), 1, row.Cells["unidad"].Value.ToString(), row.Cells["concepto"].Value.ToString(), row.Cells["monto"].Value.ToString().Replace(",", "."));
                }
                catch(Exception)
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
                LoadDtvHuespeds(ComboClientes, "select * from huespedes order by id desc");
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
            
        }
        
        
        private void BtnAddManual_Click(object sender, EventArgs e)
        {
            if (mov == 1)
            {
                CleanDGV();
            }
            else
            {
                try
                {
                    if (IsNumeric(TxtManualMonto.Text.Replace(",", ".").Replace(" ","")) == true)
                    {
                        LoadReadyFactAdd(DtvProductFact ,TxtIdentificador.Text.ToUpper(), Convert.ToInt32(TxtCantidad.Text.Replace(" ", "")), TxtUnidad.Text, TxtManualConcepto.Text.ToUpper(), TxtManualMonto.Text.Replace(",", "."));
                    }
                    else
                    {
                        MessageBox.Show("Verifique el monto.", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Verifique su seleccion", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void TxtManualId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("No se permiten letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtManualMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("No se permiten letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void ComboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] substrings = ComboClientes.Text.Split('[');
            int huesped = Convert.ToInt32(substrings[1].Replace("]", ""));

            loadventas(DtvVentas, "select * from ventas where id_huesped = " + huesped + " order by id desc");
        }

        public bool IsNumeric(object Expression)

        {

            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), out retNum);

            return isNum;

        }
    }
}
