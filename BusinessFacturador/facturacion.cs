using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MultiFacturasSDK;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net.Mail;

namespace HostelSystem
{
    public partial class facturacion : Form
    {
        MFSDK sdk;
        Datos datos = new Datos();
        Conexion coneccion = new Conexion();
        private string rutaxml, rutasave,  rutalogo, mailfact, nombrexml, totalfact;
        private int idfacturadb;

        public facturacion()
        {
            InitializeComponent();
            this.CenterToScreen();
            UpdateDTV();
        }

        public MFObject PAC()
        {
            /*MFObject pac = new MFObject("PAC");

            pac["usuario"] = "DEMO700101XXX";//"DEMO700101XXX"
            pac["pass"] = "DEMO700101XXX";//"DEMO700101XXX"
            pac["produccion"] = "NO";

            return pac;*/
            MFObject pac = new MFObject("PAC");

            pac["usuario"] = datos.ReturnDatos("conrfc", 1);
            pac["pass"] = datos.ReturnDatosMinMa("passfact", 1);
            pac["produccion"] = "SI";

            return pac;
        }

        public MFObject Conf()
        {
            MFObject conf = new MFObject("conf");
            conf["cer"] = datos.ReturnDatos("urlcer", 1);
            conf["key"] = datos.ReturnDatos("urlkey", 1);
            conf["pass"] = datos.ReturnDatosMinMa("passfact", 1);
            return conf;
        }

        public void MostrarDatos(MFSDK sdk)
        {

            TreeNode raiz = new TreeNode("Archivo INI"); //Nombre del archivo

            //Se agregan los campos iniciales a la raíz del árbol
            foreach (KeyValuePair<string, string> campo in sdk.Iniciales)
            {
                TreeNode inicia = new TreeNode(campo.Key + "=" + campo.Value);
                raiz.Nodes.Add(inicia);
            }
            //Se asigna el orden correcto para cada nodo de la factura
            sdk.AsignaValor();
            //Se agrega cada apartado con sus campos
            foreach (KeyValuePair<string, MFObject> sub in sdk.Apartados)
            {
                string nombre = sub.Key;
                TreeNode aparta = new TreeNode(nombre);
                foreach (KeyValuePair<string, string> dato in sub.Value.Atributos)
                {
                    TreeNode info = new TreeNode(dato.Key + "=" + dato.Value);
                    aparta.Nodes.Add(info);
                }
                raiz.Nodes.Add(aparta);
                //Si el apartado tiene subnodos, se recorren
                if (sub.Value.Subnodos.Count > 0)
                {
                    foreach (KeyValuePair<string, MFObject> subnodo in sub.Value.Subnodos)
                    {
                        string aps = nombre + "." + subnodo.Key;
                        recorreSubnodos(aps, subnodo.Value, aparta);
                    }
                }
            }
        }

        public void recorreSubnodos(string apartado, MFObject subnodo, TreeNode padre)
        {
            //Agrega el nombre y los atributos de los subnodos al árbol
            TreeNode hijo = new TreeNode(apartado);
            foreach (KeyValuePair<string, string> dato in subnodo.Atributos)
            {
                TreeNode info = new TreeNode(dato.Key + "=" + dato.Value);
                hijo.Nodes.Add(info);
            }
            padre.Nodes.Add(hijo);
            foreach (KeyValuePair<string, MFObject> dato in subnodo.Subnodos)
            {
                string respaldo = apartado;
                string nombre = dato.Key;
                apartado += "." + nombre;
                recorreSubnodos(apartado, dato.Value, hijo);
                apartado = respaldo;
            }
        }

        public int FactAction(MFObject conceptos, double iva, int IdHuesped, string metododepago, string TipoComprobante, string total, List<int> ids, string usocfdi, string metodopagov)
        {
            sdk = new MFSDK();
            sdk.Iniciales.Add("version_cfdi", "3.3");
            sdk.Iniciales.Add("MODOINI", "DIVISOR");
            string nombre_doc = ReturnIdFactura().ToString();
            sdk.Iniciales.Add("cfdi", datos.ReturnDatos("urlsavefact", 1) + nombre_doc + ".xml");
            sdk.Iniciales.Add("xml_debug", datos.ReturnDatos("urlsavefact", 1) + nombre_doc + "_debug.xml");
            sdk.Iniciales.Add("remueve_acentos", "NO");
            sdk.Iniciales.Add("RESPUESTA_UTF8", "SI");
            sdk.Iniciales.Add("html_a_txt", "NO");

            MFObject factura = new MFObject("factura");
            factura["serie"] = "A";
            factura["folio"] = nombre_doc;
            factura["fecha_expedicion"] = DateTime.Now.ToString("s");

            String[] substringsmetodopago = metodopagov.Split('-');
            factura["metodo_pago"] = substringsmetodopago[0];

            String[] m_pago = metododepago.Split('-');
            factura["forma_pago"] = m_pago[0];
            factura["condicionesDePago"] = "condiciones";
            String[] tcomp = TipoComprobante.Split('-');
            factura["tipocomprobante"] = tcomp[0].ToUpper();
            factura["moneda"] = "MXN";
            factura["tipocambio"] = "1";
            factura["LugarExpedicion"] = datos.ReturnDatos("lexpedicion", 1);
            factura["RegimenFiscal"] = datos.ReturnDatos("regimenfiscal", 1); ;
            factura["subtotal"] = (float.Parse(total) - iva).ToString("#.##");// Total / 1.16
            factura["descuento"] = "0.00";
            factura["total"] = total;//Total con iva

            MFObject emisor = new MFObject("emisor");
            emisor["rfc"] = datos.ReturnDatos("conrfc", 1); //LAN7008173R5
            emisor["nombre"] = datos.ReturnDatos("connombre", 1);
            emisor["RegimenFiscal"] = datos.ReturnDatos("regimenfiscal", 1);
            
            MFObject receptor = new MFObject("receptor");
            receptor["rfc"] = ReturnDatosHuesped("rfc", IdHuesped).ToUpper();
            receptor["nombre"] = ReturnDatosHuesped("razonsocial", IdHuesped);
            
            String[] uso = usocfdi.Split('-');
            receptor["UsoCFDI"] = uso[0];


            // Impuestos
            MFObject impuestos = new MFObject("impuestos");
            impuestos["TotalImpuestosTrasladados"] = iva.ToString("#.##");

            // Traslados
            MFObject itras = new MFObject("translados");
            MFObject itra0 = new MFObject("0");
            itra0["Impuesto"] = "002";
            itra0["Importe"] = iva.ToString("#.##");
            itra0["TasaOCuota"] = "0.160000";
            itra0["TipoFactor"] = "Tasa";
            itras.AgregaSubnodo(itra0);
            impuestos.AgregaSubnodo(itras);
            
            sdk.AgregaObjeto(PAC());
            sdk.AgregaObjeto(Conf());
            sdk.AgregaObjeto(factura);
            sdk.AgregaObjeto(emisor);
            sdk.AgregaObjeto(receptor);
            sdk.AgregaObjeto(conceptos);
            sdk.AgregaObjeto(impuestos);
            // Muestras la estructura
            MostrarDatos(sdk);

            // Se timbra el CFDI
            SDKRespuesta respuesta = sdk.Timbrar(@"C:\sdk2\timbrar32.bat", @"C:\sdk2\timbrados\", "factura", false);

            if (Convert.ToInt32(respuesta.Codigo_MF_Numero) == 0)
            {
                GeneratePdfFactura(datos.ReturnDatos("urlsavefact", 1) + nombre_doc + ".xml", datos.ReturnDatos("urlsavefact", 1) + nombre_doc + ".pdf", datos.ReturnDatos("urllogofact", 1), ReturnDatosHuesped("mail", IdHuesped), nombre_doc, total);
                Notificacion("Factura A" + nombre_doc + " timbrada correctamente", 1);
                AddFactureDB(nombre_doc + ".xml", IdHuesped, "VALIDA");
            }
            else
            {
                Notificacion(respuesta.Codigo_MF_Texto, 2);
            }

            return Convert.ToInt32(respuesta.Codigo_MF_Numero);

        }

        private void AddFactureDB(string nombre, int idHuesped, string ststus)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "INSERT INTO facturas(id, nombre, id_huesped, status) VALUES('" + nombre.Replace(".xml", "") + "', '" + nombre + "', '" + idHuesped + "', 'VALIDA')";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception a)
            {
                coneccion.cnn.Close();
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void UpdateFactureDB(int id, string status)
        {
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "update facturas set status = '" + status + "' where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private int ReturnIdFactura()
        {
            int i = 0;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select top 1* from facturas order by id desc";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    i = Convert.ToInt32(Reg[0]);
                }
                coneccion.cnn.Close();
            }
            catch (Exception a)
            {
                coneccion.cnn.Close();
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            coneccion.cnn.Close();
            return i + 1;
        }

        private void ChangeFacturadoIdVenta(string id)
        {
            try
            {
                coneccion.sql = "update ventas set facturado = 1 where id = '" + id + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), datos.ReturnDatos("connombre", 1), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadFacturas(DataGridView dtv, string consulta)
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

                dtv.Columns.Add("status", "STATUS");
                dtv.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.Columns.Add("id_huesped", "HUESPED");
                dtv.Columns["id_huesped"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                dtv.Columns.Add("huespednombre", "HUESPED");
                dtv.Columns["huespednombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;



                while (Reg.Read())
                {
                    dtv.Rows.Add(Reg[0].ToString(), Reg[1].ToString(), Reg[2].ToString(), Reg[3], Reg[4]);
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

        private void loadSearch()
        {
            string valor = valor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese numero de factura o nombre del huesped.", datos.ReturnDatos("Nombre", 1), "", -1, -1);

            LoadFacturas(DtvFacturas, "select fa.id, fa.nombre, fa.status, fa.id_huesped, hu.nombre from facturas fa, huespedes hu where fa.id_huesped = hu.id and fa.nombre like '%" + valor + "%' or fa.id_huesped = hu.id and hu.nombre like '%" + valor + "%' order by id desc");
        }

        private void DtvFacturas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AbrirPdf();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPdf();
        }

        private void DtvFacturas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = DtvFacturas.HitTest(e.X, e.Y);
                    DtvFacturas.ClearSelection();
                    DtvFacturas.Rows[hti.RowIndex].Selected = true;
                    this.ContextMenuStrip = this.MenuDGV;
                }
                catch (Exception)
                { }
            }
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirPdf();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadSearch();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewFactura form = new NewFactura();
            form.Show();
        }

        private void cancelarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CancelarFactura();
        }

        private void AbrirPdf()
        {
            try
            {
                DataGridViewRow row = DtvFacturas.CurrentRow;
                System.Diagnostics.Process.Start(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", ".pdf"));
            }
            catch (Exception)
            {
                if (MessageBox.Show("Verifique sus movimientos, posiblemente la factura PDF, ya no existe en la carpeta : " + datos.ReturnDatos("urlsavefact", 1) + "\n\nDESEA QUE EL SISTEMA TRATE DE GENERAR NUEVAMENTE EL PDF ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    RegeneratePDF();
                }
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelarFactura();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDTV();
        }

        private void UpdateDTV()
        {
            LoadFacturas(DtvFacturas, "select fa.id, fa.nombre, fa.status, fa.id_huesped, cli.nombre from facturas fa, clientes cli where fa.id_huesped = cli.id order by fa.id desc");
        }

        private void CancelarFactura()
        {
            try
            {
                DataGridViewRow rowtmp = DtvFacturas.CurrentRow;

                if (MessageBox.Show("Cancelar factura : " + rowtmp.Cells["nombre"].Value.ToString(), "CANCELAR FACTURA PDF- " + datos.ReturnDatos("connombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pictureBox1.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox3.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                    CancellFactura(Convert.ToInt32(rowtmp.Cells["id"].Value), datos.ReturnDatos("urlsavefact", 1) + rowtmp.Cells["nombre"].Value.ToString());
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        public void GeneratePdfFactura(string rutaxmltmp, string rutasavetmp, string rutalogotmp, string mailtmp, string nombre_doc, string total)
        {
            nombrexml = nombre_doc;
            totalfact = total;
            rutaxml = rutaxmltmp;
            rutasave = rutasavetmp;
            rutalogo = rutalogotmp;
            mailfact = mailtmp;
            BackgroundWorker process = new BackgroundWorker();
            process.DoWork += GeneratePdfFacturaAction;
            process.RunWorkerAsync();
        }
        public void GeneratePdfFacturaAction(object o, DoWorkEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;

            DocumentoPDF.CreaPDF crearPDF = new DocumentoPDF.CreaPDF(rutaxml, rutasave, Image.FromFile(rutalogo));
            List<string> list = new List<string>();
            list.Add(rutaxml);
            list.Add(rutaxml.Replace(".xml", ".pdf"));

            SendMail(list, mailfact);

            ci.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        public void ReGeneratePdfFactura(string rutaxmltmp, string rutapdftmp, string rutalogotmp)
        {
            rutaxml = rutaxmltmp;
            rutasave = rutapdftmp;
            rutalogo = rutalogotmp;
            BackgroundWorker process = new BackgroundWorker();
            process.DoWork += ReGeneratePdfFacturaAction;
            process.RunWorkerCompleted += ReGeneratePdfFacturaActionComplet;
            process.RunWorkerAsync();
        }

        private void ReGeneratePdfFacturaActionComplet(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        public void ReGeneratePdfFacturaAction(object o, DoWorkEventArgs e)
        {
            try
            {
                CultureInfo ci = new CultureInfo("en-US");
                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;

                DocumentoPDF.CreaPDF crearPDF = new DocumentoPDF.CreaPDF(rutaxml, rutasave, Image.FromFile(rutalogo));

                ci.NumberFormat.NumberDecimalSeparator = ",";
                Thread.CurrentThread.CurrentCulture = ci;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void CancellFactura(int id, string rutaxmltmp)
        {
            rutaxml = rutaxmltmp;
            idfacturadb = id;
            BackgroundWorker process = new BackgroundWorker();
            process.DoWork += CancellFacturaAction;
            process.RunWorkerAsync();
            process.RunWorkerCompleted += CancellFacturaComplet;
        }

        private void CancellFacturaComplet(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateDTV();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        public void CancellFacturaAction(object o, DoWorkEventArgs e)
        {
            sdk = new MFSDK();
            sdk.Iniciales.Add("cfdi", rutaxml);
            sdk.Iniciales.Add("cancelar", "SI");
            sdk.AgregaObjeto(PAC());
            sdk.AgregaObjeto(Conf());
            // Se timbra el CFDI
            SDKRespuesta respuesta = sdk.Timbrar(@"C:\sdk2\timbrar32.bat", @"C:\sdk2\timbrados\", "factura", false);
            if (respuesta.Codigo_MF_Numero == "0")
            {
                Conexion coneccion = new Conexion();
                try
                {

                    coneccion.cnn.Close();

                    coneccion.sql = "update facturas set status = 'CANCELADA' where id = '" + idfacturadb + "'";
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    coneccion.cnn.Close();
                }
                catch (Exception)
                { coneccion.cnn.Close(); }
                //UpdateDTV();
                Notificacion(respuesta.Codigo_MF_Texto, 1);
            }
            else
            {
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
        }
        private void enviarPorCorreoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendMailAgain();
        }

        private void SendMailAgain()
        {
            try
            {
                DataGridViewRow row = DtvFacturas.CurrentRow;

                List<string> list = new List<string>();
                list.Add(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString());
                list.Add(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", ".pdf"));
                nombrexml = row.Cells["nombre"].Value.ToString();
                SendMail(list, ReturnDatosHuesped("mail", Convert.ToInt32(row.Cells["id_huesped"].Value.ToString())));

                MessageBox.Show("La factura se enviara en un momento, puede realizar otras tareas, el sistema le avisara.", "FACTURA SEND", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique sus movimientos, posiblemente la factura ya no existe en la carpeta : " + datos.ReturnDatos("urlsavefact", 1), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void enviarPorCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMailAgain();
        }

        private void generarArchivoPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegeneratePDF();
        }

        private void RegeneratePDF()
        {
            try
            {
                DataGridViewRow row = DtvFacturas.CurrentRow;

                if (MessageBox.Show("Se intentara generar nuevamente el pdf de la factura : " + row.Cells["nombre"].Value.ToString() + ", en caso de existir un pdf con el mismo nombre este se reemplazara.", "REGENERACION FACTURA PDF- " + datos.ReturnDatos("connombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pictureBox1.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox3.Load(@"C:\HostelData\resources\spin.gif");
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

                    if (row.Cells["status"].Value.ToString().ToLower() == "valida")
                    {
                        ReGeneratePdfFactura(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString(), datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", ".pdf"), datos.ReturnDatos("urllogofact", 1));
                    }
                    else if (row.Cells["status"].Value.ToString().ToLower() == "cancelada")
                    {
                        GeneratePdfAcuse(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", "_acuse.xml"), datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", "_acuse.pdf"));
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        private void GeneratePdfAcuse(string rutaxml, string rutapdf)
        {
            MessageBox.Show("El modulo de generacion de acuse de cancelacion actualmente no esta disponibles, espere la proxima actualizacion", "Modulo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        private void generarArchivoPdfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegeneratePDF();
        }

        public string ReturnDatosHuesped(string dato, int huesped)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT " + dato + " FROM clientes WHERE id= " + huesped + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[0].ToString().ToLower();
                    }
                }
                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            coneccion.cnn.Close();
            return valor;
        }

        private void regenerarDirecorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDirectoryFacturas();
        }

        public void RestoreDirectoryFacturas()
        {
            DirectoryInfo di = new DirectoryInfo(datos.ReturnDatos("urlsavefact", 1));

            foreach (var fi in di.GetFiles())
            {
                if (fi.Extension == ".xml")
                {
                    SearchAndProcessIDfactura(Convert.ToInt32(fi.Name.ToString().Replace(".xml", "").Replace("_acuse", "")));
                }
            }
            UpdateDTV();
        }

        public void CleanTableDb(String sql, string tableDB)
        {

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = sql;
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SearchAndProcessIDfactura(int factura)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT id FROM facturas WHERE id= " + factura + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (!Reg.Read())
                {
                    AgregarReferenceFacturaManual(factura);
                }

                coneccion.cnn.Close();
            }
            catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AgregarReferenceFacturaManual(int factura)
        {
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "INSERT INTO facturas (id,nombre,id_huesped,status) VALUES ('" + factura + "','" + factura + ".xml" + "','" + 1 + "','VALIDA')";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception a)
            {
                coneccion.cnn.Close();
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private string correofact = "";
        private List<string> lista = new List<string>();

        public void SendMail(List<string> list, string mail)
        {
            BackgroundWorker process = new BackgroundWorker();
            lista = list;
            correofact = mail;
            process.DoWork += SendMailStart;
            process.RunWorkerAsync();
            process.RunWorkerCompleted += finalisnedmail;
        }

        private void finalisnedmail(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        public void SendMailStart(object o, DoWorkEventArgs e)
        {
            pictureBox1.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

            MailMessage msg = new MailMessage();

            //Email a quien se le envia
            if (correofact.Replace(" ", "") != "")
            {
                correofact += "," + datos.ReturnDatos("mailr", 1);
                correofact = correofact.Replace(",,", ",");
                msg.To.Add(correofact);
            }
            else
            {
                msg.To.Add(datos.ReturnDatos("mailr", 1));
            }

            //Email que quieras que aparezca de quien envia y nombre de quien aparece
            msg.From = new MailAddress(datos.ReturnDatosMinMa("correo", 1), datos.ReturnDatos("correo", 1));

            msg.Subject = "FACTURA - " + datos.ReturnDatos("connombre", 1);
            msg.Body = "Estimado cliente, se adjunta el xml y pdf de su factura valida ante el sat.\n\n" + datos.ReturnDatos("connombre", 1) + "\nDIRECCION: " + datos.ReturnDatos("dfcalle", 1) + "\nCORREO ELECTRONICO: " + datos.ReturnDatos("correo", 1) + "\n\n\nESTE ES UN CORREO AUTOMATICO, NO ES NECESARIO QUE LO RESPONDA\nSOFTWARE Y MAS: " + datos.ReturnDatos("web", 1);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            foreach (var item in lista)
            {
                msg.Attachments.Add(new Attachment(item));
            }

            msg.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(datos.ReturnDatosMinMa("correo", 1), datos.ReturnDatosMinMa("password", 1));

            client.Port = Convert.ToInt32(datos.ReturnDatosMinMa("port", 1));

            client.Host = datos.ReturnDatosMinMa("host", 1);

            client.EnableSsl = true;

            try
            {
                client.Send(msg);
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                NotifyIcon notificacion = new NotifyIcon();
                notificacion.Icon = SystemIcons.Information;
                notificacion.BalloonTipTitle = datos.ReturnDatos("connombre", 1);
                notificacion.BalloonTipText = "Reporte enviado";
                notificacion.BalloonTipIcon = ToolTipIcon.Info;
                notificacion.Visible = true;
                notificacion.ShowBalloonTip(30000);
                Thread.Sleep(30000);
                notificacion.Dispose();
            }
            catch (Exception)
            {
                msg.Dispose();
                client.Dispose();
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                NotifyIcon notificacion = new NotifyIcon();
                notificacion.Icon = SystemIcons.Error;
                notificacion.BalloonTipTitle = datos.ReturnDatos("connombre", 1);
                notificacion.BalloonTipText = "No se pudo enviar el reporte.";
                notificacion.BalloonTipIcon = ToolTipIcon.Error;
                notificacion.Visible = true;
                notificacion.ShowBalloonTip(30000);
                Thread.Sleep(30000);
                notificacion.Dispose();
            }
            finally
            {
                msg.Dispose();
                client.Dispose();
            }

        }
        private static string msgg, titlee;

        private void abrirFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(datos.ReturnDatos("urlsavefact", 1));
        }

        private void regenerarDirectorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDirectoryFacturas();
        }

        private void emitirFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewFactura form = new NewFactura();
            form.Show();
        }

        private static int CodeIconG;
        public void Notificacion(string msg, int CodeIcon)
        {
            BackgroundWorker proceso = new BackgroundWorker();
            msgg = msg;
            CodeIconG = CodeIcon;
            proceso.DoWork += NoticiacionProces;
            proceso.RunWorkerAsync();
        }

        private void NoticiacionProces(object sender, DoWorkEventArgs e)
        {
            NotifyIcon notificacion = new NotifyIcon();
            if (CodeIconG == 1)
            {
                notificacion.Icon = SystemIcons.Information;
                notificacion.BalloonTipIcon = ToolTipIcon.Info;
            }
            else if (CodeIconG == 2)
            {
                notificacion.Icon = SystemIcons.Warning;
                notificacion.BalloonTipIcon = ToolTipIcon.Warning;
            }
            else if (CodeIconG == 3)
            {
                notificacion.Icon = SystemIcons.Error;
                notificacion.BalloonTipIcon = ToolTipIcon.Error;
            }

            notificacion.BalloonTipTitle = datos.ReturnDatos("connombre", 1);
            notificacion.BalloonTipText = msgg;
            notificacion.Visible = true;
            notificacion.ShowBalloonTip(30000);
            Thread.Sleep(30000);
            notificacion.Dispose();
        }
        public void NotificacionGBL(string title, string msg, int CodeIcon)
        {
            BackgroundWorker proceso = new BackgroundWorker();
            msgg = msg;
            titlee = title;
            CodeIconG = CodeIcon;
            proceso.DoWork += NoticiacionProcesGBL;
            proceso.RunWorkerAsync();
        }

        private void NoticiacionProcesGBL(object sender, DoWorkEventArgs e)
        {
            NotifyIcon notificacion = new NotifyIcon();
            if (CodeIconG == 1)
            {
                notificacion.Icon = SystemIcons.Information;
                notificacion.BalloonTipIcon = ToolTipIcon.Info;
            }
            else if (CodeIconG == 2)
            {
                notificacion.Icon = SystemIcons.Warning;
                notificacion.BalloonTipIcon = ToolTipIcon.Warning;
            }
            else if (CodeIconG == 3)
            {
                notificacion.Icon = SystemIcons.Error;
                notificacion.BalloonTipIcon = ToolTipIcon.Error;
            }

            notificacion.BalloonTipTitle = titlee;
            notificacion.BalloonTipText = msgg;
            notificacion.Visible = true;
            notificacion.ShowBalloonTip(30000);
            Thread.Sleep(30000);
            notificacion.Dispose();
        }
    }
}
