using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["session"] == null && !HttpContext.Current.Request.Url.AbsolutePath.Equals("/login.aspx"))
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}