using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Timers;
using System.Net.Mail;

namespace HostelSystem
{
    public partial class Control : Form
    {
        Datos datos = new Datos();

        Conexion coneccion = new Conexion();

        public static string BodyMail;
        string nivel = "";
        int usersystem;

        public Control(string level, int usersystemtmp)
        {
            InitializeComponent();
            this.CenterToScreen();
            nivel = level;
            usersystem = usersystemtmp;
            this.Text = "BUSINESS FACTURADOR - CONTRIBUYENTE: " + datos.ReturnDatos("conrfc", 1) + ", " + datos.ReturnDatos("connombre", 1);
            ShowFacturas();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTE SISTEMA ES DESARROLLADO E IMPLEMENTADO POR:\nISC: FRANCISCO EDUARDO ASCENCIO DOMINGUEZ\nPARA: " + datos.ReturnDatos("connombre", 1) + "\nWEB: " + datos.ReturnDatos("web", 1), "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            Exit();
        }

        private void configurarToolStripMeanuItem_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Exit()
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar el programa ?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void CleanPanel()
        {
            Panel.Controls.Clear();
        }

       private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            
        }

        private void ShowNewFacture()
        {
            CleanPanel();
            Panel.AutoScroll = false;
            NewFactura form = new NewFactura();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel.Controls.Add(form);
            form.Show();
        }

        private void ShowFacturas()
        {
            CleanPanel();
            Panel.AutoScroll = false;
            facturacion form = new facturacion();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel.Controls.Add(form);
            form.Show();
        }

        private void ShowClientes()
        {
            CleanPanel();
            Panel.AutoScroll = false;
            clientes form = new clientes();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel.Controls.Add(form);
            form.Show();
        }

        private void ShowConceptos()
        {
            CleanPanel();
            Panel.AutoScroll = false;
            conceptos form = new conceptos();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel.Controls.Add(form);
            form.Show();
        }
        public string ReturnDateHabitacion(string Habitacion, string campo)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "select * from habitaciones where id = '" + Habitacion + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg["" + campo + ""].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return valor;
        }

        public string ReturnTotal(string Habitacion)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();

                coneccion.sql = "select total from habitaciones where id = '" + Habitacion + "'";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg[0].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return valor;
        }

        
        
        private string CompareHabitacionesVencidas()
        {
            string i = "";
                try
                {
                    coneccion.cnn.Close();
                    coneccion.sql = "select * from habitaciones where status = 'ocupada'";
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    SqlDataReader Reg = null;
                    Reg = coneccion.comandosql.ExecuteReader();

                    if (Reg.Read())
                    {
                        if (DateTime.Compare(Convert.ToDateTime(Reg["fechasalida"].ToString()).AddMinutes(- Convert.ToInt32(datos.ReturnDatos("checkoutminutosbefore", 1) )), DateTime.Now) <= 0)
                        {
                            i += Reg["id"].ToString();
                        }
                    }
                    coneccion.cnn.Close();
                }
                catch (Exception ex)
                {
                    coneccion.cnn.Close();
                    MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            return i;
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            string i = CompareHabitacionesVencidas();
            
            if (i != "" )
            {
                Timer.Stop();
                MessageBox.Show("Tiene habitaciones vencidas o por vencerse. [ " + i + " ]",datos.ReturnDatos("nombre",1),MessageBoxButtons.OK,MessageBoxIcon.Warning);
                /*Timer.Stop();
                if (MessageBox.Show("Tiempo finalizado habitacion: [" + CompareHabitacionesVencidas().ToString() + " ].\n¿Realizar proceso de finalizacion ahora?", datos.ReturnDatos("nombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (CheckAdeudo(i) == true)
                    {
                        this.Dispose();
                        Timer.Stop();
                        Adeudo adeudo = new Adeudo(i, nivel, IdUsuarioSystem);
                        adeudo.Show();
                    }
                    else
                    {
                        Timer.Stop();
                        ChangeStatus(i, "mantenimiento");
                        Button boton = new Button();
                        boton.Name = i.ToString();
                        boton.Image = Properties.Resources.setup1;
                        string diaorhora = "";
                        string precioHabitacion = "";
                        int stadia = Convert.ToInt32(ReturnDateHabitacion(i, "stadia"));

                        if (ReturnDateHabitacion(i, "diaorhora") == "dia")
                        {
                            diaorhora = "DIA/S";
                            precioHabitacion = ReturnDateHabitacion(i, "precioxdia");
                        }
                        else
                        {
                            diaorhora = "HORA/S";
                            precioHabitacion = ReturnDateHabitacion(i, "precioxhora");
                        }

                        AddVenta("RENTA DE HABITACION POR " + ReturnDateHabitacion(i, "stadia") + " " + diaorhora.ToString().ToUpper(), (Convert.ToDouble(precioHabitacion) * stadia).ToString(), stadia, DateTime.Now, Convert.ToInt32(ReturnDateHabitacion(i, "id_huesped")), i, "", IdUsuarioSystem);
                        ClearHabitacion(i, "mantenimiento");
                        BtnControl.PerformClick();
                        Timer.Start();
                    }
                }
                else
                {
                    Timer.Start();
                }*/
            }
        }

       

        
        

        public void CleanTableDb(String sql,string tableDB)
        {
            if (MessageBox.Show("Sera eliminado todo el contenido de la tabla [ " + tableDB.ToUpper()+" ]",datos.ReturnDatos("nombre",1),MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    coneccion.cnn.Close();
                    coneccion.sql = sql;
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    MessageBox.Show("La tabla a sido vaciada",datos.ReturnDatos("nombre",1),MessageBoxButtons.OK,MessageBoxIcon.Information);
                    coneccion.cnn.Close();
                }
                catch (Exception e)
                {
                    coneccion.cnn.Close();
                    MessageBox.Show(e.ToString(),"Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public void CleanTableDbAll(String sql)
        {
            if (MessageBox.Show("ALTO PIENSALO 2 VECES ! - \n\nAl aceptar esta accion se borrara todo ! es decir el sistema quedara en blanco, no abra habitacions,huespdes, folios, etc.\n\n¿ESTA SEGURO?", datos.ReturnDatos("nombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    coneccion.cnn.Close();
                    coneccion.sql = sql;
                    coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                    coneccion.cnn.Open();
                    coneccion.comandosql.ExecuteReader();
                    MessageBox.Show("El sistema ah sido borrado completamente.", datos.ReturnDatos("nombre", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    coneccion.cnn.Close();
                }
                catch (Exception e)
                {
                    coneccion.cnn.Close();
                    MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public void CleanTableDbCorteZ(String sql, string tableDB)
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
                    MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        

        
        private void AddFinanazeGbl(string concepto, string monto, DateTime fecha)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "insert into financegbl (concepto,monto,fecha) values ('"+concepto+"', '"+monto+"', '"+fecha+"')";
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

        

        

        

        private string StatusDiaOrHora(string HabitacionTmp)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select diaorhora from habitaciones where id = '" + HabitacionTmp + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg["diaorhora"].ToString();
                }
            }
            catch (Exception)
            {
                valor = "Error";
            }
            return valor;
        }

        

        public bool AddCorteUserSystem(string concepto, string monto, DateTime fecha, int id_usuario)
        {
            bool var = false;

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "insert into corteusersystem (concepto, monto, fecha, id_usuario) values ('"+concepto+"', '"+monto+"', '"+fecha+"', '"+id_usuario+"')";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                var = true;
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString());
                var = false;
            }

            return var;
        }

        

        

        
        private double ReturnAbonoHabitacion(string habitacion)
        {
            double valor = 0;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select abono from habitaciones where id = '"+habitacion+"' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg["abono"] != null || Reg["abono"].ToString() != "")
                    {
                        valor = Convert.ToDouble(Reg["abono"].ToString());
                    }
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }

        private int ReturnHuespedMasHabitacion(string habitacion)
        {
            int valor = 0;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select numeroacthuespds from habitaciones where id = '" + habitacion + "' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (!string.IsNullOrEmpty(Reg["numeroacthuespds"].ToString()))
                    {
                        valor = Convert.ToInt32(Reg["numeroacthuespds"].ToString());
                    }
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }
        public string ReturnHuespedName(int huesped)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select nombre from huespedes where id = '" + huesped + "' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg[0].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }
        private string ReturnModeDiaOrHora(string habitacion)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select diaorhora from habitaciones where id = '" + habitacion + "' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg[0].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }
        private DateTime ReturnFechaEntrada(string habitacion)
        {
            DateTime valor = DateTime.Now;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select fechaentrada from habitaciones where id = '" + habitacion + "' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = DateTime.Parse(Reg[0].ToString());
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }

        

        

        

        

        public void DeleteReporteCortexz(string concepto, string monto, DateTime fecha)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from finanzacortexz order by id desc ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                while (Reg.Read())
                {
                    if (Reg["concepto"].ToString().Replace(" ","").ToLower() == concepto && Reg["precio"].ToString().Replace(" ","") == monto && Convert.ToDateTime(Reg["fecha"].ToString()) == fecha )
                    {
                        int i = Convert.ToInt32(Reg["id"].ToString());
                        DeleteIdReporteCorteGbl(i);
                        break;
                    }    
                }
                coneccion.cnn.Close();
            }
            catch (Exception)
            {
                coneccion.cnn.Close();
            }
        }

        public void DeleteReporteVenta(string concepto, string monto, DateTime fecha)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select * from Ventas order by id desc ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                while (Reg.Read())
                {
                    if (Reg["concepto"].ToString().Replace(" ", "").ToLower() == concepto && Reg["precio"].ToString().Replace(" ", "") == monto && Convert.ToDateTime(Reg["fecha"].ToString()) == fecha)
                    {
                        DeleteIdReporteVenta(Convert.ToInt32(Reg["id"].ToString()));
                        break;
                    }
                }
                coneccion.cnn.Close();
            }
            catch (Exception)
            {
                coneccion.cnn.Close();
            }
        }

        public bool DeleteIdReporteCorteUser(int id)
        {
            bool var = false;
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "delete from corteusersystem where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                var = true;
                coneccion.cnn.Close();
            }
            catch (Exception)
            {
                coneccion.cnn.Close();
                var = false;
            }
            return var;
        }
        private void DeleteIdReporteCorteGbl(int id)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "delete from finanzacortexz where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception)
            {
                coneccion.cnn.Close();
            }
        }

        private void DeleteIdReporteVenta(int id)
        {
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "delete from ventas where id = '" + id + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
            }
            catch (Exception)
            {
                coneccion.cnn.Close();
            }
        }

        
        private void ViewLastFolio(string id)
        {
            string informe = "";

            try
            {
                coneccion.sql = "select habitacion.folio_registro, habitacion.id, habitacion.descripcion, habitacion.precioxdia, habitacion.precioxhora, habitacion.diaorhora, habitacion.fechaentrada, habitacion.fechasalida, habitacion.stadia, habitacion.total, habitacion.abono, huesped.nombre, huesped.apellidos, huesped.telefono, huesped.empresa, huesped.rfc, huesped.email from habitaciones habitacion, huespedes huesped where habitacion.id = '" + id + "' and habitacion.id_huesped = huesped.id";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    informe += "NUMERO DE HABITACION : " + Reg["id"].ToString();
                    informe += "\n\nDESCRIPCION : " + Reg["descripcion"].ToString();
                    informe += "\n\nPRECIO POR DIA $ " + Reg["precioxdia"].ToString();
                    informe += "\nPRECIO POR HORA $ " + Reg["precioxhora"].ToString();
                    informe += "\n\nHUESPED : " + Reg["nombre"].ToString() + " " + Reg["apellidos"].ToString();
                    informe += "\nEMPRESA : " + Reg["empresa"].ToString();
                    informe += "\nRFC : " + Reg["rfc"].ToString();
                    informe += "\nTELEFONO : " + Reg["telefono"].ToString();
                    informe += "\nE-MAIL : " + Reg["email"].ToString();
                    informe += "\n\nFOLIO : " + Reg["folio_registro"].ToString();
                }
                coneccion.cnn.Close();
                MessageBox.Show(informe, datos.ReturnDatos("nombre", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public bool IsNumeric(object Expression)

        {

            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), out retNum);

            return isNum;

        }

        

        public bool IsInt(object Expression)

        {

            bool isNum;

            int retNum;

            isNum = int.TryParse(Convert.ToString(Expression), out retNum);

            return isNum;

        }

        

        public string ReturnNameUserSystem (int id)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select nombre, apellidos from usuarios where id = '"+id+"' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg[0].ToString() + " " + Reg[1].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }
        public string ReturnDescuentoHabitacion(string Habitacion)
        {
            string valor = "";
            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "select descuento from habitaciones where id = '" + Habitacion + "' ";

                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    valor = Reg[0].ToString();
                }
                coneccion.cnn.Close();
            }
            catch (Exception ex)
            {
                coneccion.cnn.Close();
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return valor;
        }
        public void SendMail(string body)
        {
            if (datos.ReturnDatos("sendmail", 1) == "TRUE")
            {
                BackgroundWorker process = new BackgroundWorker();
                BodyMail = body;
                process.DoWork += SendMailStart;
                process.RunWorkerAsync();
            }
        }

        

        
        public static void SendMailStart(object o, DoWorkEventArgs e)
        {
            Datos datos = new Datos();

            MailMessage msg = new MailMessage();

            //Email a quien se le envia
            msg.To.Add(datos.ReturnDatosMinMa("mailr", 1));

            //Email que quieras que aparezca de quien envia y nombre de quien aparece
            msg.From = new MailAddress(datos.ReturnDatosMinMa("correo", 1), datos.ReturnDatos("correo", 1));

            msg.Subject = datos.ReturnDatos("nombre", 1);

            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = BodyMail + "\n\n" + datos.ReturnDatos("nombre", 1) + ", " + datos.ReturnDatos("direccion", 1) + "\nEste es un correo automatico, no es necesario responder.";


            msg.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(datos.ReturnDatosMinMa("correo", 1), datos.ReturnDatosMinMa("password", 1));

            /*
             * Cliente SMTP
             * Gmail:  smtp.gmail.com  puerto:587
             * Hotmail: smtp.liva.com  puerto:25
             */

            client.Port = Convert.ToInt32(datos.ReturnDatosMinMa("port", 1));

            client.Host = datos.ReturnDatosMinMa("host", 1);

            client.EnableSsl = true;

            try
            {
                client.Send(msg);
                NotifyIcon notificacion = new NotifyIcon();
                notificacion.Icon = SystemIcons.Information;
                notificacion.BalloonTipTitle = datos.ReturnDatos("nombre",1);
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
                NotifyIcon notificacion = new NotifyIcon();
                notificacion.Icon = SystemIcons.Error;
                notificacion.BalloonTipTitle = datos.ReturnDatos("nombre", 1);
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

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivel == "administrador")
            {
                Configuracion form = new Configuracion();
                form.Show();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewFacture();
        }
        
        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login form = new login();
            form.Show();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFacturas();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClientes();
        }

        private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivel == "administrador")
            {
                ShowConceptos();
            }
            else
            {
                MessageBox.Show("Acceso no autorizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void vaciarReferenciasDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivel == "administrador")
            {
                if (MessageBox.Show("Sera eliminado todas las referencias de las facturas.\nESTA SEGURO ?, ESTE PROCESO ES IRREVERSIBLE", datos.ReturnDatos("connombre", 1), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    try
                    {
                        coneccion.cnn.Close();
                        coneccion.sql = "delete from facturas";
                        coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                        coneccion.cnn.Open();
                        coneccion.comandosql.ExecuteReader();
                        MessageBox.Show("La tabla a sido vaciada", datos.ReturnDatos("connombre", 1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        coneccion.cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        coneccion.cnn.Close();
                        MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                MessageBox.Show("Acceso no autorizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void bloquearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login form = new login();
            form.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivel == "administrador")
            {
                ShowUsuarios();
            }
            else
            {
                Timer.Start();
                MessageBox.Show("Acceso no autorizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void ShowUsuarios()
        {
            CleanPanel();
            Panel.AutoScroll = false;
            usuarios form = new usuarios();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel.Controls.Add(form);
            form.Show();
        }

        private void abrirDirecrotioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(datos.ReturnDatos("urlsavefact", 1));
        }
    }
}