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
using System.Text.RegularExpressions;

namespace Dao
{
    public class DaoLogin
    {

        AccesoDatos ad = new AccesoDatos();

        public Usuario Existe(Usuario user)
        {
            DataTable dt;
            dt = ad.ObtenerTabla("practica_supervisada.usuarios", "SELECT nombre_usuarios,apellido_usuarios,user_usuarios FROM usuarios WHERE user_usuarios ='" + user.User + "' AND password_usuarios ='" +user.Password+ "' AND Estado='true' FETCH FIRST 1 ROWS ONLY") ;
                try
                {
                    user.Nombre = dt.Rows[0][0].ToString();
                    user.Apellido = dt.Rows[0][1].ToString();
                    user.User = dt.Rows[0][2].ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            return user;
        }
    }
}
