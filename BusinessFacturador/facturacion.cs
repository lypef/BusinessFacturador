using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Multifacturas.SDK;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net.Mail;
using System.IO;

namespace HostelSystem
{
    public partial class facturacion : Form
    {
        Datos datos = new Datos();
        Conexion coneccion = new Conexion();
        private string rutaxml, rutasave, rutalogo, mailfact, production, rutasdk;
        private int idfacturadb;

        public facturacion()
        {
            InitializeComponent();
            this.CenterToScreen();
            if (datos.ReturnDatos("demo", 1).ToLower() == "true")
            {
                production = "NO";
            }
            else
            {
                production = "SI";
            }
            rutasdk = @"C:\multifacturas_sdk\";
            UpdateDTV();
        }

        public int FactAction(List <Concepto> Conceptos, int IdHuesped, string metododepago, string TipoComprobante)
        {
            int status = 0;
            string nombre_doc = ReturnIdFactura().ToString();

            PAC pac;
            Conf conf;

            if (production.ToLower() == "si")
            {
                pac = new PAC(datos.ReturnDatos("conrfc", 1), datos.ReturnDatosMinMa("passfact", 1), production);

                conf = new Conf(datos.ReturnDatosMinMa("urlcer", 1), datos.ReturnDatosMinMa("urlkey", 1), datos.ReturnDatosMinMa("passfact", 1));
            }
            else
            {
                pac = new PAC("DEMO700101XXX", "DEMO700101XXX", production);
                
                conf = new Conf(coneccion.ReturnLocalData()+@"SELLO_DIGITAL\CSD01_AAA010101AAA.cer", coneccion.ReturnLocalData() + @"SELLO_DIGITAL\CSD01_AAA010101AAA.key", "12345678a");
            }
            
            
            // Se crea un objeto SDKConfig con el PAC, CONF y la ruta del SDK
            // NOTA: La ruta del SDK debe terminar con la diagonal invertida
            SDKConfig sdkConf = new SDKConfig(pac, conf, rutasdk);


            // Se crea el objeto SDK
            SDK sdk = new SDK(sdkConf);


            // Se inicializa el SDK
            sdk = new SDK(sdkConf);

            CFDI factura = new CFDI();

            factura.Serie = "A";
            factura.Folio = nombre_doc;
            factura.FechaDeExpedicion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            factura.MetodoDePago = metododepago.ToLower(); //efectivo
            factura.FormaDePago = "PAGO EN UNA SOLA EXHIBICION";
            factura.TipoDeComprobante = TipoComprobante.ToLower(); //ingreso
            factura.TipoDeCambio = "1.0";
            if (production.ToLower() == "si")
            {
                factura.LugarDeExpedicion = datos.ReturnDatos("lexpedicion", 1);
            }else
            {
                factura.LugarDeExpedicion = "LUGAR DEMO";
            }
                
            factura.RegimenFiscal = datos.ReturnDatos("regimenfiscal", 1);


            Emisor emisor = new Emisor();
            if (production.ToLower() == "si")
            {
                emisor.RFC = datos.ReturnDatos("conrfc", 1);
            }
            else
            {
                emisor.RFC = "aaa010101aaa".ToUpper();
            }
            
            emisor.Nombre = datos.ReturnDatos("connombre", 1);

            DomicilioFiscal DomFis = new DomicilioFiscal();
            DomFis.Calle = datos.ReturnDatos("dfcalle", 1);
            DomFis.NoExterior = datos.ReturnDatos("dfnoext", 1);
            DomFis.Colonia = datos.ReturnDatos("dfcolonia", 1);
            DomFis.Localidad = datos.ReturnDatos("dflocalidad", 1);
            DomFis.Municipio = datos.ReturnDatos("dfmunicipio", 1);
            DomFis.Estado = datos.ReturnDatos("dfestado", 1);
            DomFis.Pais = datos.ReturnDatos("dfpais", 1);
            DomFis.CodigoPostal = datos.ReturnDatos("dfcp", 1);

            ExpedidoEn expedido = new ExpedidoEn(datos.ReturnDatos("expcalle", 1), datos.ReturnDatos("expmunicipio", 1), datos.ReturnDatos("expestado", 1), datos.ReturnDatos("expais", 1), datos.ReturnDatos("expcp", 1));
            expedido.Localidad = datos.ReturnDatos("explocalidad", 1);
            expedido.NoExterior = datos.ReturnDatos("expnoext", 1);
            expedido.Colonia = datos.ReturnDatos("expcolonia", 1);

            emisor.Domicilio = DomFis;
            emisor.ExpedidoEn = expedido;
            factura.Emisor = emisor;

            Receptor receptor = new Receptor();
            receptor.RFC = ReturnDatosHuesped("rfc", IdHuesped).ToUpper();
            receptor.Nombre = ReturnDatosHuesped("razonsocial", IdHuesped);

            Domicilio domRceptor = new Domicilio();
            domRceptor.Calle = ReturnDatosHuesped("calle", IdHuesped);
            domRceptor.NoExterior = ReturnDatosHuesped("noext", IdHuesped);
            domRceptor.NoInterior = ReturnDatosHuesped("noint", IdHuesped);
            domRceptor.Colonia = ReturnDatosHuesped("colonia", IdHuesped);
            domRceptor.Localidad = ReturnDatosHuesped("loc", IdHuesped);
            domRceptor.Municipio = ReturnDatosHuesped("municipio", IdHuesped);
            domRceptor.Estado = ReturnDatosHuesped("estado", IdHuesped);
            domRceptor.Pais = ReturnDatosHuesped("pais", IdHuesped);
            domRceptor.CodigoPostal = ReturnDatosHuesped("cp", IdHuesped);

            receptor.Domicilio = domRceptor;
            factura.Receptor = receptor;


            double iva = 0, total = 0;

            foreach (var a in Conceptos)
            {
                total += double.Parse(a.Importe);
            }

            factura.SubTotal = (total / 1.16).ToString();
            iva = double.Parse(factura.SubTotal) * .16;
            factura.Descuento = "0";
            factura.Total = total.ToString();
            factura.Conceptos = Conceptos;

            Impuestos impuestos = new Impuestos();
            Translado traslado = new Translado();

            traslado.Impuesto = "IVA";
            traslado.Tasa = "16";
            traslado.Importe = iva.ToString();

            impuestos.AgregaTraslado(traslado);
            factura.Impuestos = impuestos;

            
            sdk.CreaINI(factura, datos.ReturnDatos("urlsavefact", 1) + nombre_doc +".ini");

            SDKRespuesta respuesta = sdk.Timbrar(factura, datos.ReturnDatos("urlsavefact", 1),nombre_doc);
            
            if (respuesta.Codigo_MF_Numero == "0")
            {
                if (production.ToLower() == "no")
                {
                    Notificacion("Factura timbrada correctamente en modo demo, la factura no es valida ante el sat.", 2);
                }
                else
                {
                    Notificacion("Factura timbrada correctamente", 1);
                }                
                AddFactureDB(nombre_doc + ".xml",IdHuesped,"VALIDA");
                GeneratePdfFactura(datos.ReturnDatos("urlsavefact", 1) + nombre_doc + ".xml", datos.ReturnDatos("urlsavefact", 1) + nombre_doc + ".pdf", datos.ReturnDatos("urllogofact", 1), ReturnDatosHuesped("mail", IdHuesped) );
            }
            else if(respuesta.Codigo_MF_Numero == "1")
            {
                status = 1;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "2")
            {
                status = 2;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "3")
            {
                status = 3;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "4")
            {
                status = 4;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "5")
            {
                status = 5;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "6")
            {
                status = 6;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "7")
            {
                status = 7;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            else if (respuesta.Codigo_MF_Numero == "8")
            {
                status = 8;
                Notificacion(respuesta.Codigo_MF_Texto, 3);
            }
            return status;
        }

        private void AddFactureDB(string nombre, int idHuesped, string ststus)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "INSERT INTO facturas(id, nombre, id_huesped, status) VALUES('" + nombre.Replace(".xml","") + "', '" + nombre  + "', '" + idHuesped + "', 'VALIDA')";
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
                    
                coneccion.sql = "update facturas set status = '"+status+"' where id = '"+id+"'";
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
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return i + 1;
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
            LoadFacturas(DtvFacturas, "select fa.id, fa.nombre, fa.status, fa.id_huesped, cli.nombre from facturas fa, clientes cli where fa.id_huesped = cli.id and fa.nombre like '%" + valor + "%' or fa.id_huesped = cli.id and cli.nombre like '%" + valor + "%' order by id desc");
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
                    this.ContextMenuStrip = this.MenuDGV;
                }
                catch(Exception)
                {}
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
                    pictureBox1.Load(coneccion.ReturnLocalData()+@"resources\spin.gif");
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox3.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                    CancellFactura(Convert.ToInt32(rowtmp.Cells["id"].Value),datos.ReturnDatos("urlsavefact", 1) + rowtmp.Cells["nombre"].Value.ToString());
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        public void GeneratePdfFactura(string rutaxmltmp, string rutasavetmp, string rutalogotmp, string mailtmp)
        {
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

            DocumentoPDF.CreaPDF crearPDF = new DocumentoPDF.CreaPDF(rutaxml, rutasave, Image.FromFile(rutalogo) );
            List<string> list = new List<string>();
            list.Add(rutaxml);
            list.Add(rutaxml.Replace(".xml",".pdf"));

            SendMail(list,mailfact);

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
            }catch(Exception ee)
            {
                MessageBox.Show(ee.ToString(),"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        public void CancellFactura(int id,string rutaxmltmp)
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
            PAC pac;
            Conf conf;

            if (production.ToLower() == "si")
            {
                pac = new PAC(datos.ReturnDatos("conrfc", 1), datos.ReturnDatosMinMa("passfact", 1), production);

                conf = new Conf(datos.ReturnDatosMinMa("urlcer", 1), datos.ReturnDatosMinMa("urlkey", 1), datos.ReturnDatosMinMa("passfact", 1));
            }
            else
            {
                pac = new PAC("DEMO700101XXX", "DEMO700101XXX", production);

                conf = new Conf(coneccion.ReturnLocalData()+@"SELLO_DIGITAL\CSD01_AAA010101AAA.cer", coneccion.ReturnLocalData() + @"SELLO_DIGITAL\CSD01_AAA010101AAA.key", "12345678a");
            }

            SDKConfig sdkConf = new SDKConfig(pac, conf, rutasdk);

            SDK sdk = new SDK(sdkConf);
            sdk = new SDK(sdkConf);

            // Se cancela el CFDI

            SDKRespuesta respuesta = sdk.CancelarConAcuse(rutaxml);
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
                { coneccion.cnn.Close();}
                UpdateDTV();
                MessageBox.Show(respuesta.Codigo_MF_Texto + "\n\nConsulte su acuse de cancelacion en : " + rutaxml.Replace(".xml", "_acuse.xml"), "ACUSE CANCELACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (respuesta.Codigo_MF_Numero == "1")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "SALDO INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "2")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "ERROR AL TIMBRAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "3")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "TIEMPO EXCEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "4")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "USUARIO O CONTRASEÑA INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "5")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "USUARIO O CONTRASEÑA INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "6")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "ERROR PAC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "7")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "ERROR INTERNO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (respuesta.Codigo_MF_Numero == "8")
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto, "ERROR TICKET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                
                if (MessageBox.Show("Se intentara generar nuevamente el pdf de la factura : " + row.Cells["nombre"].Value.ToString() + ", en caso de existir un pdf con el mismo nombre este se reemplazara.", "REGENERACION FACTURA PDF- " + datos.ReturnDatos("nombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pictureBox1.Load(coneccion.ReturnLocalData() +@"resources\spin.gif");
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox2.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox3.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

                    if (row.Cells["status"].Value.ToString().ToLower() == "valida")
                    {
                        ReGeneratePdfFactura(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString(), datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", ".pdf"), datos.ReturnDatos("urllogofact", 1));
                    }
                    else if (row.Cells["status"].Value.ToString().ToLower() == "cancelada")
                    {
                        GeneratePdfAcuse(datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml","_acuse.xml"), datos.ReturnDatos("urlsavefact", 1) + row.Cells["nombre"].Value.ToString().Replace(".xml", "_acuse.pdf"));
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

        private void regenerarDirectorioToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void abrirDirectorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDirectorio();
        }

        private void ShowDirectorio()
        {
            System.Diagnostics.Process.Start(datos.ReturnDatos("urlsavefact", 1));
        }

        public string ReturnDatosHuesped(string dato, int huesped)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT "+ dato +" FROM clientes WHERE id= " + huesped + "";
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
            return valor;
        }

        private string correofact = "";
        private List<string> lista = new List<string>();

        public void SendMail(List<string>list, string mail)
        {
            BackgroundWorker process = new BackgroundWorker();
            lista = list;
            correofact = mail;
            process.DoWork += SendMailStart;
            process.RunWorkerAsync();    
        }

        public void SendMailStart(object o, DoWorkEventArgs e)
        {
            pictureBox1.Load(coneccion.ReturnLocalData()+@"resources\spin.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Load(coneccion.ReturnLocalData() + @"resources\spin.gif");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

            MailMessage msg = new MailMessage();

            //Email a quien se le envia
            if (correofact.Replace(" ","") != "")
            {
                msg.To.Add(correofact);
            }else
            {
                msg.To.Add(datos.ReturnDatos("mailr",1));
            }
            
            //Email que quieras que aparezca de quien envia y nombre de quien aparece
            msg.From = new MailAddress(datos.ReturnDatosMinMa("correo", 1), datos.ReturnDatos("correo", 1));

            msg.Subject = "FACTURA - "+ datos.ReturnDatos("connombre", 1);
            msg.Body = "Estimado cliente, se adjunta el xml y pdf de su factura valida ante el sat.\n\n" + datos.ReturnDatos("connombre", 1) + "\nDIRECCIO: " + datos.ReturnDatos("dfcalle", 1)  + "\nCORREO ELECTRONICO: " + datos.ReturnDatos("correo", 1) + "\n\n\nESTE ES UN CORREO AUTOMATICO, NO ES NECESARIO QUE LO RESPONDA\nSOFTWARE Y MAS: " + datos.ReturnDatos("web", 1);
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            foreach(var item in lista)
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
        private static string msgg;
        private static int CodeIconG;
        public void Notificacion (string msg, int CodeIcon)
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
    }
}
