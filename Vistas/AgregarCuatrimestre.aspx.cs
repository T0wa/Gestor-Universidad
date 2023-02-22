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
    public partial class AgregarCuatrimestre : System.Web.UI.Page
    {
        CuatrimestreNegocio negocioCuatri;
        Cuatrimestre cuatri;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrd();
            }

            Page.Title = "Cuatrimestre - PS";
        }
        private void cargarGrd()
        {
            try
            {
                negocioCuatri = new CuatrimestreNegocio();

                if (negocioCuatri.IsConex())
                {
                    lbl_res.Text = "CONECTADO";
                    grdCuatrimestre.DataSource = negocioCuatri.cargarLosCuatri();
                    grdCuatrimestre.DataBind();

                    if (grdCuatrimestre.Rows.Count > 0)
                    {
                        grdCuatrimestre.UseAccessibleHeader = true;
                        grdCuatrimestre.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                    lbl_res.Text = "NO CONECTADO";
            }
            catch (Exception e)
            {
                Session.Add("error", e.ToString());
                Response.Redirect("Error.aspx");
            }
        }


        protected void grdCuatrimestre_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                if (((TextBox)grdCuatrimestre.Rows[e.RowIndex].FindControl("txtAnioEdit")).Text.ToString() != ""
                && ((TextBox)grdCuatrimestre.Rows[e.RowIndex].FindControl("txtNumEdit")).Text.ToString() != "")
                {
                    CuatrimestreNegocio neg = new CuatrimestreNegocio();
                    cuatri = new Cuatrimestre();
                    cuatri.Id = Int32.Parse(((Label)grdCuatrimestre.Rows[e.RowIndex].FindControl("lbl_id")).Text.ToString());
                    cuatri.Descripcion = ((TextBox)grdCuatrimestre.Rows[e.RowIndex].FindControl("txtDescEdit")).Text.ToString();
                    cuatri.Anio = Int32.Parse(((TextBox)grdCuatrimestre.Rows[e.RowIndex].FindControl("txtAnioEdit")).Text.ToString());
                    cuatri.NumCuatrimestre = Int32.Parse(((TextBox)grdCuatrimestre.Rows[e.RowIndex].FindControl("txtNumEdit")).Text.ToString());



                    if (cuatri.Anio >= 0 && cuatri.NumCuatrimestre >= 0)
                    {
                        neg.editarCuatri(cuatri);
                        grdCuatrimestre.EditIndex = -1;

                    }
                }
                cargarGrd();
            }

            catch (Exception a)
            {
                Session.Add("error", a.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdCuatrimestre_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                cuatri = new Cuatrimestre();
                negocioCuatri = new CuatrimestreNegocio();

                cuatri.Id = Int32.Parse(((Label)grdCuatrimestre.Rows[e.RowIndex].FindControl("lblId")).Text);
                negocioCuatri.eliminarCuatri(cuatri);

                cargarGrd();
            }
            catch(Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void grdCuatrimestre_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdCuatrimestre.EditIndex = e.NewEditIndex;
                cargarGrd();
            }

                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdCuatrimestre_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCuatrimestre.EditIndex = -1;
                cargarGrd();
            }

                                    catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarCuatri_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnio.Text != "" && txtNumero.Text != "")
                {
                    cuatri = new Cuatrimestre();
                    negocioCuatri = new CuatrimestreNegocio();
                    cuatri.Descripcion = txtDescripcion.Text.ToString();
                    cuatri.Anio = int.Parse(txtAnio.Text);
                    cuatri.NumCuatrimestre = int.Parse(txtNumero.Text.ToString());


                    if (cuatri.Anio >= 0 && cuatri.NumCuatrimestre >= 0)
                    {
                        lbl_res.Text = negocioCuatri.agregarCuatri(cuatri);
                        txtDescripcion.Text = null;
                        txtAnio.Text = null;
                        txtNumero.Text = null;
                    }
                }
            }
            catch (Exception)
            {
                lbl_res.Text = "Revise los datos ingresados";
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