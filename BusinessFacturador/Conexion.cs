using System.Data.SqlClient;

namespace HostelSystem
{
    public class Conexion
    {
        public string cadenaconexion;
        public string sql;
        public int resultado;
        public SqlConnection cnn;
        public SqlCommand comandosql;
        public string mensaje;


        public Conexion()
        {
            this.cadenaconexion = (@"Data Source=(LocalDB)\bussinessfacturador;AttachDbFilename="+ReturnLocalData()+@"db\hostelsystem.mdf;Integrated Security=True;Connect Timeout=30");
            this.cnn = new SqlConnection(this.cadenaconexion);
        }

        public string ReturnLocalData()
        {
            string line = "";
            string url = "";
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\databusinessfacturador.txt");

            while ((line = file.ReadLine()) != null)
            {
                url = line;
            }

            file.Close();
            return url;
        }
    }
}
