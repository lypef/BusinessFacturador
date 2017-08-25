using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelSystem
{
    class Datos
    {
        Conexion coneccion = new Conexion();
        public string EmisorLugarDeExpedicion = "lexpedicion";
        public string EmisorRegimenfiscal = "regimenfiscal";
        public string EmisorRfc = "conrfc";
        public string EmisorNombre = "connombre";
        public string EmisorCalleDF = "dfcalle";
        public string EmisorNoexteriorDF = "dfnoext";
        public string EmisorColoniaDF = "dfcolonia";
        public string EmisorLocalidadDF = "dflocalidad";
        public string EmisorMunicipioDF = "dfmunicipio";
        public string EmisorEstadoDF = "dfestado";
        public string EmisorPaisDF = "dfpais";
        public string EmisorCodigoPostalDF = "dfcp";
        public string EmisorExpedidoCalle = "expcalle";
        public string EmisorExpedidoMunicipio = "expmunicipio";
        public string EmisorExpedidoEstado = "expestado";
        public string EmisorExpedidoPais = "expais";
        public string EmisorExpedidoLocalidad = "explocalidad";
        public string EmisorExpedidoNoExt = "expnoext";
        public string EmisorExpedidoColonia = "expcolonia";
        public string EmisorExpedidoCodigoPostal = "expcp";
        public string ReceptorRfc = "rfc";
        public string ReceptorRazonSocial = "razonsocial";
        public string ReceptorCalle = "calle";
        public string ReceptorNoExterior = "noext";
        public string ReceptorNoInterior = "noint";
        public string ReceptorColonia = "colonia";
        public string ReceptorLocalidad = "loc";
        public string ReceptorMunicipio = "municipio";
        public string ReceptorEstado = "estado";
        public string ReceptorPais = "pais";
        public string ReceptorCP = "cp";

        public string ReturnDatos (string campo , int id)
        {
            string valor = "";

            try {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT "+campo+" FROM configuracion WHERE id= "+id+"";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[campo].ToString();
                    }
                }
                coneccion.cnn.Close();
            } catch (Exception e)
            {
                coneccion.cnn.Close();
                MessageBox.Show(e.ToString(),"Exception",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            coneccion.cnn.Close();

            return valor.ToUpper();
        }

        public string ReturnDatosMinMa(string campo, int id)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT " + campo + " FROM configuracion WHERE id= " + id + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[campo].ToString();
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

        public string ReturnDatosLicense(string campo)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT " + campo + " FROM license WHERE id = 1 ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[campo].ToString();
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

            return valor.ToUpper();
        }
        public string ReturnDatosCliente(int client, string campo)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT "+campo+" FROM clientes WHERE id = '"+ client +"' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[campo].ToString();
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

            return valor.ToUpper();
        }
        public string ReturnDatosPromotionsHabitaciones(string habitacion)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT promotion FROM habitaciones WHERE id = '" + habitacion + "' ";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = Reg[0].ToString();
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

            return valor.ToUpper();
        }
        public string ReturnDateStart(string habitacion)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT fechaentrada FROM habitaciones WHERE id= " + habitacion + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = DateTime.Parse(Reg[0].ToString()).ToShortDateString() +" "+ DateTime.Parse(Reg[0].ToString()).ToShortTimeString();
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
        public string ReturnDateExit(string habitacion)
        {
            string valor = "";

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT fechasalida FROM habitaciones WHERE id= " + habitacion + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (Reg[0] != null)
                    {
                        valor = DateTime.Parse(Reg[0].ToString()).ToShortDateString() + " " + DateTime.Parse(Reg[0].ToString()).ToShortTimeString();
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
        public Boolean ReturnVentaDirectaHabitacion(string habitacion)
        {
            Boolean valor = false;

            try
            {
                coneccion.cnn.Close();
                coneccion.sql = "SELECT vtdirecta FROM habitaciones WHERE id= " + habitacion + "";
                coneccion.comandosql = new SqlCommand(coneccion.sql, coneccion.cnn);
                coneccion.cnn.Open();
                SqlDataReader Reg = null;
                Reg = coneccion.comandosql.ExecuteReader();

                if (Reg.Read())
                {
                    if (String.IsNullOrEmpty(Reg[0].ToString()))
                    {
                        valor = true;
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
    }
}
