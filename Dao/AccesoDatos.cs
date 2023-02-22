using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Dao
{
   public class AccesoDatos
    {
       
        static private string server = "localhost";
        static private string db = "practica_supervisada";
        static private string user = "postgres";
        static private string pass = "root";
        static private string port = "5432";
        static private string ruta = "server=" + server + ";port=" + port + ";user id=" + user + ";password=" + pass + ";database=" + db + ";";
        public AccesoDatos() { }

        private NpgsqlConnection ObtenerConexion()
        {
            NpgsqlConnection cn = new NpgsqlConnection();
            cn.ConnectionString = ruta;
            try
            {
                cn.Open();
                return cn;
            }
            catch (NpgsqlException)
            {
                return null;
            }
        }
        public Boolean IsConex()
        {

            NpgsqlConnection cn = ObtenerConexion();
            if (cn != null)
            {
                return true;
            }
            return false;
        }

        private NpgsqlDataAdapter ObtenerAdaptador(string consulta, NpgsqlConnection cn)
        {
            NpgsqlDataAdapter adapter;
            try
            {
                adapter = new NpgsqlDataAdapter(consulta, cn);
                return adapter;
            }
            catch (NpgsqlException)
            {
                return null;
            }
        }
        public DataTable ObtenerTabla(string nombre, string consulta)
        {
            NpgsqlConnection cn = ObtenerConexion();
            if (cn!=null)
            {
                try
                {
                    NpgsqlDataAdapter adapter = ObtenerAdaptador(consulta, cn);
                    DataSet ds = new DataSet();
                    cn.Close();
                    adapter.Fill(ds, nombre);
                    return ds.Tables[nombre];
                }
                catch (NpgsqlException)
                {

                    return null;
                }
            }
            return null;
        }
        public int EjecutarProcAlmacenado(NpgsqlCommand command, string nombre)
        {
            NpgsqlConnection cn = ObtenerConexion();
            if (cn != null)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd = command;
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = nombre;
                    int cambios = cmd.ExecuteNonQuery();
                    cn.Close();
                    return cambios;
                }
                catch (Exception)
                {

                    return -1;
                }
            }
            return -1;
        }

        public Boolean Existe(string consulta)
        {
            NpgsqlConnection cn = ObtenerConexion();
            if (cn != null)
            {
                NpgsqlCommand cmd = new NpgsqlCommand(consulta, cn);
                try
                {
                    NpgsqlDataReader dato = cmd.ExecuteReader();
                    Boolean existe = false;
                    if (dato.Read()) existe = true;

                    return existe;
                }
                catch (PostgresException)
                {
                    
                    return false;
                }
            }
            return false;
        }

        public NpgsqlDataReader ejecutarTransaccion(String consulta)
        {
            NpgsqlConnection cn = ObtenerConexion();
            if (cn != null)
            {
            NpgsqlCommand cmd = new NpgsqlCommand(consulta, cn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            return dr;
            }
            return null;
        }
        
    }
}
