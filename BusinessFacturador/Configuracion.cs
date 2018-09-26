using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HostelSystem
{
    public partial class Configuracion : Form
    {
        Datos datos = new Datos();

        Conexion coneccion = new Conexion();

        public Configuracion()
        {
            InitializeComponent();
            this.CenterToScreen();
            LoadValues();
            TxtSerie.Text = Properties.Settings.Default.serie;
        }

        private void LoadValues()
        {
            TxtMail.Text = datos.ReturnDatosMinMa("correo", 1);
            Txtpass.Text = datos.ReturnDatosMinMa("password", 1);
            TxtPort.Text = datos.ReturnDatosMinMa("port", 1);
            TxtHost.Text = datos.ReturnDatosMinMa("host", 1);
            TxtMailR.Text = datos.ReturnDatosMinMa("mailr", 1);


            //Config fact
            UrlFacAll.Text = datos.ReturnDatos("urlsavefact", 1);
            UrlLogoFact.Text = datos.ReturnDatos("urllogofact", 1);
            Txtcer.Text = datos.ReturnDatos("urlcer", 1);
            Txtkey.Text = datos.ReturnDatos("urlkey", 1);
            TxtPassFact.Text = datos.ReturnDatosMinMa("passfact", 1);

            if (datos.ReturnDatos("ivainclu", 1).ToLower() == "true")
            {
                IvaInclu.Checked = true;
            }
            else
            {
                IvaInclu.Checked = false;
            }
            
            lexpedicion.Text = datos.ReturnDatos("lexpedicion", 1);
            regimenfiscal.Text = datos.ReturnDatos("regimenfiscal", 1);
            conrfc.Text = datos.ReturnDatos("conrfc", 1);
            connombre.Text = datos.ReturnDatos("connombre", 1);

            //Form de inicio
            if (datos.ReturnDatos("inifactura", 1).ToLower() == "true")
            {
                inifactura.Checked = true;
            }
            else if (datos.ReturnDatos("ininomina", 1).ToLower() == "true")
            {
                ininomina.Checked = true;
            }
            else if (datos.ReturnDatos("inifaemisiones", 1).ToLower() == "true")
            {
                inifaemisiones.Checked = true;
            }
            else if (datos.ReturnDatos("inifaclientes", 1).ToLower() == "true")
            {
                inifaclientes.Checked = true;
            }
            else if (datos.ReturnDatos("inifaconceptos", 1).ToLower() == "true")
            {
                inifaconceptos.Checked = true;
            }
            else if (datos.ReturnDatos("ininoemision", 1).ToLower() == "true")
            {
                ininoemision.Checked = true;
            }
            else if (datos.ReturnDatos("ininoempleados", 1).ToLower() == "true")
            {
                ininoempleados.Checked = true;
            }
        }

        private void OpnDialog(TextBox Txt)
        {
            FolderBrowserDialog dirVir = new FolderBrowserDialog();
            dirVir.Description = "Seleccione el Directorio";

            DialogResult dirSelected = dirVir.ShowDialog(this);

            if (dirSelected == DialogResult.OK)
            {
                Txt.Text = dirVir.SelectedPath;
                Txt.Text += @"\";
            }
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo jpg/png (*.jpg)|*.jpg";
            open.FilterIndex = 4;
            if (open.ShowDialog() != DialogResult.OK)
                return;
            UrlLogoFact.Text = open.FileName;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpnDialog(UrlFacAll);
        }

        
        private void button4_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dirVir = new FolderBrowserDialog();
            dirVir.Description = "Seleccione el Directorio";

            DialogResult dirSelected = dirVir.ShowDialog(this);

            if (dirSelected == DialogResult.OK)
            {
                UrlFacAll.Text = dirVir.SelectedPath;
                UrlFacAll.Text += @"\";
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo imagen .jpg (*.jpg)|*.jpg";
            open.FilterIndex = 4;
            if (open.ShowDialog() != DialogResult.OK)
                return;
            UrlLogoFact.Text = open.FileName;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo certificado .cer (*.cer)|*.cer";
            open.FilterIndex = 4;
            if (open.ShowDialog() != DialogResult.OK)
                return;
            Txtcer.Text = open.FileName;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivo key .key (*.key)|*.key";
            open.FilterIndex = 4;
            if (open.ShowDialog() != DialogResult.OK)
                return;
            Txtkey.Text = open.FileName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CbMailPersonalizado.Checked == true)
            {
                if(MessageBox.Show("ATENCION\nPara configurar un correo personalizado debe tener los conocimientos necesarios de lo contrario los correos no se enviaran correctamente, le recomendamos que utilice la configuracion preestablecida para evitar posibles errores, si no tiene conocimientos de servidores smtp le recomendamos solo configurar el MAIL R que es el correo a donde llegaran los reportes del sistema.\n\nESTA SEGURO DE CONFIGURAR SU CORREO PERSONALIZADO?", "ALTO, ESTA SEGURO DE LO QUE HACE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    TxtMail.Enabled = true;
                    Txtpass.Enabled = true;
                    TxtPort.Enabled = true;
                    TxtHost.Enabled = true;
                }else
                {
                    CbMailPersonalizado.Checked = false;
                }
            }else
            {
                TxtMail.Text = datos.ReturnDatosMinMa("correo", 1);
                Txtpass.Text = datos.ReturnDatosMinMa("password", 1);
                TxtPort.Text = datos.ReturnDatosMinMa("port", 1);
                TxtHost.Text = datos.ReturnDatosMinMa("host", 1);
                TxtMail.Enabled = false;
                Txtpass.Enabled = false;
                TxtPort.Enabled = false;
                TxtHost.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                coneccion.cnn.Close();

                string ivainclutmp = "", inifacturatmp = "", ininominatmp = "", inifaemisionestmp = "", inifaclientestmp = "", inifaconceptostmp = "", ininoemisiontmp = "", ininoempleadostmp = "";

                if (IvaInclu.Checked == true)
                {
                    ivainclutmp = "1";
                }else
                {
                    ivainclutmp = "0";
                }

                // inicio
                if (inifactura.Checked == true)
                {
                    inifacturatmp = "1";
                }else
                {
                    inifacturatmp = "0";
                }

                if (ininomina.Checked == true)
                {
                    ininominatmp = "1";
                }
                else
                {
                    ininominatmp = "0";
                }

                if (inifaemisiones.Checked == true)
                {
                    inifaemisionestmp = "1";
                }
                else
                {
                    inifaemisionestmp = "0";
                }

                if (inifaclientes.Checked == true)
                {
                    inifaclientestmp = "1";
                }
                else
                {
                    inifaclientestmp = "0";
                }

                if (inifaconceptos.Checked == true)
                {
                    inifaconceptostmp = "1";
                }
                else
                {
                    inifaconceptostmp = "0";
                }

                if (ininoemision.Checked == true)
                {
                    ininoemisiontmp = "1";
                }
                else
                {
                    ininoemisiontmp = "0";
                }

                if (ininoempleados.Checked == true)
                {
                    ininoempleadostmp = "1";
                }
                else
                {
                    ininoempleadostmp = "0";
                }

                coneccion.sql = "update configuracion set correo = '"+ TxtMail.Text + "', password = '" + Txtpass.Text + "', port = '" + TxtPort.Text + "', host = '" + TxtHost.Text + "', mailr = '" + TxtMailR.Text + "', urlsavefact = '" + UrlFacAll.Text + "', urllogofact = '" + UrlLogoFact.Text + "', urlcer = '" + Txtcer.Text + "', urlkey = '" + Txtkey.Text + "', passfact = '" + TxtPassFact.Text + "', ivainclu  = '" + ivainclutmp + "', lexpedicion = '" + lexpedicion.Text + "', regimenfiscal = '" + regimenfiscal.Text + "', conrfc = '" + conrfc.Text + "', connombre = '" + connombre.Text + "', inifactura = '"+ inifacturatmp + "', ininomina = '" + ininominatmp + "', inifaemisiones = '" + inifaemisionestmp + "', inifaclientes = '" + inifaclientestmp + "', inifaconceptos = '" + inifaconceptostmp + "', ininoemision = '" + ininoemisiontmp + "', ininoempleados = '" + ininoempleadostmp + "'  where id = '1' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                coneccion.comandosql.ExecuteReader();
                coneccion.cnn.Close();
                Properties.Settings.Default.serie = TxtSerie.Text.ToUpper();
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuracion actualizada.", "ACTUALIZADO",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
    }
}
