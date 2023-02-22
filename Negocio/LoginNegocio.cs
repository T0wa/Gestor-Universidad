using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Dao;
using System.Text.RegularExpressions;

namespace Negocio
{
   public class LoginNegocio
    {
        DaoLogin daoLog = new DaoLogin();
        static string LimpiarCadena(string str)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(str, @"[^\w\.@-_]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public Usuario IsLogged(Usuario usr)
        {
            usr.User = LimpiarCadena(usr.User);
            usr.Password = LimpiarCadena(usr.Password);
            if(usr.User.Trim() != null || usr.Password.Trim() != null)
                return daoLog.Existe(usr);
            return null;
        }
       
    }                           
}
