using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class bmlUsuarios : System.Web.UI.Page
    {
        UsuarioNegocio negocioUsu;
        Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrd();
            }
            //txtFechaAlta.Text = "02/07/2020";
            Page.Title = "Usuarios - PS";
        }
        private void cargarGrd()
        {
            negocioUsu = new UsuarioNegocio();
            grdUsuario.DataSource = negocioUsu.cargarLosUsu();
            grdUsuario.DataBind();
            try
            {
                grdUsuario.UseAccessibleHeader = true;
                grdUsuario.HeaderRow.TableSection = TableRowSection.TableHeader;

                if (negocioUsu.IsConex())
                {
                    lbl_res.Text = "CONECTADO";
                }
                else
                    lbl_res.Text = "NO CONECTADO";
            }
            catch (Exception)
            {

                lbl_res.Text = "error al cargar los usuarios";
            }
           
        }


        protected void grdUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                UsuarioNegocio neg = new UsuarioNegocio();
                usu = new Usuario();
                usu.User = ((Label)grdUsuario.Rows[e.RowIndex].FindControl("lblUsu")).Text.ToString();
                usu.Apellido = ((TextBox)grdUsuario.Rows[e.RowIndex].FindControl("txtApellidoEdit")).Text.ToString();
                usu.Nombre = ((TextBox)grdUsuario.Rows[e.RowIndex].FindControl("txtNombreEdit")).Text.ToString();
                usu.Mail = ((TextBox)grdUsuario.Rows[e.RowIndex].FindControl("txtMailEdit")).Text.ToString();
                usu.Password = ((TextBox)grdUsuario.Rows[e.RowIndex].FindControl("txtContraEdit")).Text.ToString();

                //VALIDAR QUE EL LEGAJO NO ESTE VACIO
                if (usu.User != "")
                {
                    neg.editarUsu(usu);
                    grdUsuario.EditIndex = -1;
                }
                cargarGrd();
            }
            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }




        }

        protected void grdUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                usu = new Usuario();
                negocioUsu = new UsuarioNegocio();

                usu.User = ((Label)grdUsuario.Rows[e.RowIndex].FindControl("lblUsu")).Text;
                negocioUsu.eliminarUsu(usu);

                cargarGrd();
            }
            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdUsuario.EditIndex = e.NewEditIndex;
                cargarGrd();
            }

                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdUsuario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdUsuario.EditIndex = -1;
                cargarGrd();
            }
            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }


 

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                usu = new Usuario();
                negocioUsu = new UsuarioNegocio();
                usu.User = txtUsuario.Text.ToString();
                usu.Apellido = txtApellido.Text.ToString();
                usu.Nombre = txtNombre.Text.ToString();
                usu.Mail = txtMail.Text.ToString();
                usu.Password = txtContra.Text.ToString();
                usu.Estado = true;

                if (!txtUsuario.Text.Equals("") &&
                    !txtApellido.Text.Equals("") &&
                    !txtMail.Text.Equals("") &&
                    !txtContra.Text.Equals("")
                    )
                {
                    lbl_res.Text = negocioUsu.agregarUsu(usu);
                    txtUsuario.Text = null;
                    txtApellido.Text = null;
                    txtNombre.Text = null;
                    txtMail.Text = null;
                    txtContra.Text = null;

                }
                else
                    lbl_res.Text = "Faltan datos por agregar";
            }

            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void btn_mod_Click(object sender, EventArgs e)
        {

            Panel1.Visible = false;
            Panel2.Visible = true;
            cargarGrd();
        }
    }
}
