using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoUsuario
    {

        AccesoDatos ad = new AccesoDatos();
        public Usuario getUsuario(Usuario user)
        {
            DataTable tabla = ad.ObtenerTabla("usuarios", "SELECT  user_usuarios, apellido_usuarios, nombre_usuarios, mail_usuarios, password_usuarios,estado FROM practica_supervisada.usuarios WHERE id_usuarios = ' " + user.User + "' AND estado='true' ");

            
            user.User = tabla.Rows[0][0].ToString();
            user.Apellido = tabla.Rows[0][3].ToString();
            user.Nombre = tabla.Rows[0][3].ToString();
            user.Mail = tabla.Rows[0][2].ToString();
            user.Password = tabla.Rows[0][1].ToString();

            user.Estado = Boolean.Parse(tabla.Rows[0][4].ToString());
            return user;
        }

        public DataTable getTablaUsu()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.usuarios", "SELECT * FROM usuarios WHERE estado='true'");
            return tabla;
        }

        public Usuario getUserXMail(Usuario user)
        {
            DataTable tabla = ad.ObtenerTabla("usuarios", "SELECT  user_usuarios, apellido_usuarios, nombre_usuarios, mail_usuarios, password_usuarios,estado FROM practica_supervisada.usuarios WHERE nombre_usuarios = ' " + user.Mail + "'");

            
            user.User = tabla.Rows[0][1].ToString();
            user.Password = tabla.Rows[0][2].ToString();
            user.Mail = tabla.Rows[0][3].ToString();
            user.Apellido = tabla.Rows[0][4].ToString();
            user.Estado = Boolean.Parse(tabla.Rows[0][5].ToString());
         

            return user;
        }
   

        public DataTable getConsulta(string n)
        {
            DataTable tabla = ad.ObtenerTabla("usuarios", "SELECT * FROM practica_supervisada.usuarios WHERE user_usuarios LIKE '" + n + "%' AND estado='true'");
            return tabla;
        }
        public DataTable setOrden(String orden)
        {
            DataTable tabla = ad.ObtenerTabla("usuarios", "SELECT * FROM practica_supervisada.usuarios ORDER BY " + orden + "");
            return tabla;
        }
        public int getCantidad()
        {
            int x = 0;
            DataTable tabla = (ad.ObtenerTabla("usuarios", "SELECT COUNT(user_usuarios) FROM usuarios"));
            try
            {
                x = Int32.Parse(tabla.Rows[0][0].ToString());
            }
            catch (FormatException)
            {
                x = -1;
            }
            return x;
        }
        public bool ExisteUsu(Usuario user)
        {
            return ad.Existe("SELECT * FROM usuarios WHERE user_usuarios ='" + user.User + "'");
        }

        public bool ExisteMail(String mail)
        {
            return ad.Existe("SELECT * FROM practica_supervisada.usuarios WHERE mail_usuarios ='" + mail + "'");
        }

        public bool CoincideContraseña(String mail, String pass)
        {
            return ad.Existe("SELECT * FROM practica_supervisada.usuarios  WHERE mail_usuarios ='" + mail + "' AND password_usuarios = '" + pass + "'");
        }

        public int EliminarUsuaario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@id_user", NpgsqlDbType.Varchar);
            parametro.Value = user.User;
            return ad.EjecutarProcAlmacenado(cmd, "sp_eliminar_usuario");
        }

        public int AgregarUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@user_usuarios", NpgsqlDbType.Varchar);
            parametro.Value = user.User;
            parametro = cmd.Parameters.Add("@nombre_usuarios", NpgsqlDbType.Varchar);
            parametro.Value = user.Nombre;
            parametro = cmd.Parameters.Add("@apellido_usuarios", NpgsqlDbType.Varchar);
            parametro.Value = user.Apellido;
            parametro = cmd.Parameters.Add("@mail_usuarios", NpgsqlDbType.Varchar);
            parametro.Value = user.Mail;
            parametro = cmd.Parameters.Add("@password_usuarios", NpgsqlDbType.Varchar);
            parametro.Value = user.Password;
            return ad.EjecutarProcAlmacenado(cmd, "sp_agregar_usuario");
        }

        public int ActualizarUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@usuario", NpgsqlDbType.Varchar);
            parametro.Value = user.User;
            parametro = cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar);
            parametro.Value = user.Nombre;
            parametro = cmd.Parameters.Add("@apellido", NpgsqlDbType.Varchar);
            parametro.Value = user.Apellido;
            parametro = cmd.Parameters.Add("@mail", NpgsqlDbType.Varchar);
            parametro.Value = user.Mail;
            parametro = cmd.Parameters.Add("@pass", NpgsqlDbType.Varchar);
            parametro.Value = user.Password;
            return ad.EjecutarProcAlmacenado(cmd, "sp_actualizar_usuarios");
        }

        public DataTable filtrarUsuario(string filtro)
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.usuarios", filtro);
            return tabla;
        }

        public Boolean isConex()
        {
            return ad.IsConex();
        }
    }
}
