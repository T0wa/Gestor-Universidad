using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///verifica que se envie un parametro de nombre logout y setea la aplication en nula
                var logout = Request.QueryString["logout"];
                if(logout!= null)
                {
                    Application["session"] = null;
                }
                /// verifica si la aplication no esta nula y si es asi es que se inicio session asique ira al abmALumnos
                if (Application["session"]!=null)
                {
                    Response.Redirect("bmlAlumnos.aspx");
                }
            }
            Page.Title = "Login - PS";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

                Usuario usr = new Usuario();
                LoginNegocio n = new LoginNegocio();
                usr.Password = txtbx_pass.Text.ToString().Trim();
                usr.User = txtbx_user.Text.ToString().Trim();
                Application["session"] = n.IsLogged(usr);
                if (Application["session"] != null)
                {
                    Response.Redirect("bmlAlumnos.aspx");
                }
            


        }
    }
}