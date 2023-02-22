using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.IO;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;

namespace Vistas
{
    public partial class bmlAlumnos : System.Web.UI.Page
    {
        AlumnoNegocio negocioAlu;
        Alumno alum;
        CuatrimestreNegocio negocioCuatri;

        InscriptosNegocio negocioInsc;
        Inscriptos insc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDLInsc();
            }
            Page.Title = "Alumnos - PS";
        }


        //si tiene al menos una letra...

        //(Hay que bloquear el ingreso de caracteres especiales)
        protected bool verificarTexto(string cadena)
        {

            string[] letras = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","x","y","z",
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","X","Y","Z"};

            int i;
            for (i = 0; i < 52; i++)
            {
                if (cadena.Contains(letras[i]))
                {
                    return true;
                }
            }
            return false;
        }

        protected void grdAlumnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                AlumnoNegocio neg = new AlumnoNegocio();
                alum = new Alumno();
                alum.Legajo = ((Label)grdAlumnos.Rows[e.RowIndex].FindControl("lbl_legajo")).Text.ToString();
                alum.Nombre = ((TextBox)grdAlumnos.Rows[e.RowIndex].FindControl("txtNombreEdit")).Text.ToString();
                alum.Apellido = ((TextBox)grdAlumnos.Rows[e.RowIndex].FindControl("txtApellidoEdit")).Text.ToString();
                alum.Mail = ((TextBox)grdAlumnos.Rows[e.RowIndex].FindControl("txtMailEdit")).Text.ToString();

                if (verificarTexto(alum.Nombre) && verificarTexto(alum.Apellido) && verificarTexto(alum.Mail))
                {
                    neg.editarAlumno(alum);
                    grdAlumnos.EditIndex = -1;
                }
                cargarGrd();
                Session.Remove("editando");
            }

            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                alum = new Alumno();
                negocioAlu = new AlumnoNegocio();

                alum.Legajo = ((Label)grdAlumnos.Rows[e.RowIndex].FindControl("lblLegajo")).Text;
                negocioAlu.eliminarAlumno(alum);

                cargarGrd();

                Session.Remove("editando");
            }

            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void grdAlumnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session.Add("editando", true);
                grdAlumnos.EditIndex = e.NewEditIndex;
                cargarGrd();
            }

            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdAlumnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdAlumnos.EditIndex = -1;
                cargarGrd();
                Session.Remove("editando");
            }
            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        private void cargarGrd()
        {
            try
            {
                negocioAlu = new AlumnoNegocio();

                if (negocioAlu.IsConex())
                {
                    grdAlumnos.DataSource = negocioAlu.cargarTodosLosAlumnos();
                    grdAlumnos.DataBind();
                    if (grdAlumnos.Rows.Count > 0)
                    {
                        grdAlumnos.UseAccessibleHeader = true;
                        grdAlumnos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    lbl_res.Text = "CONECTADO";
                }
                else
                    lbl_res.Text = "NO CONECTADO";
            }
            catch (Exception)
            {

                lbl_res.Text = "NO CONECTADO";
            }

        }

        private void cargarDDLInsc()
        {
            try
            {
                negocioAlu = new AlumnoNegocio();
                if (negocioAlu.IsConex())
                {


                    ddlAlumnos.DataSource = negocioAlu.cargarTodosLosAlumnosApenom();
                    ddlAlumnos.DataValueField = "legajo_alumnos";
                    ddlAlumnos.DataTextField = "apenom";
                    ddlAlumnos.DataBind();

                    negocioCuatri = new CuatrimestreNegocio();
                    ddlCuatrimestre.DataSource = negocioCuatri.cargarLosCuatriDDL();
                    ddlCuatrimestre.DataValueField = "id_cuatrimestres";
                    ddlCuatrimestre.DataTextField = "ddl";
                    ddlCuatrimestre.DataBind();

                    lbl_res.Text = "CONECTADO";
                }
                else
                    lbl_res.Text = "NO CONECTADO";
            }



                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }




        protected void btn_add_Click(object sender, EventArgs e)
        {
            lbl_res.Text = "";
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void btn_mod_Click(object sender, EventArgs e)
        {
            lbl_res.Text = "";
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel2.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            cargarGrd();
        }
        protected void btn_add_alumno_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbx_legajo.Text.ToString() != "" && txtbx_nombre.Text.ToString() != "" && txtbx_email.Text.ToString() != "" && txtbx_apellido.Text.ToString() != "")
                {
                    alum = new Alumno();
                    negocioAlu = new AlumnoNegocio();
                    alum.Legajo = txtbx_legajo.Text.ToString();
                    alum.Nombre = txtbx_nombre.Text.ToString();
                    alum.Apellido = txtbx_apellido.Text.ToString();
                    alum.Mail = txtbx_email.Text.ToString();
                    lbl_res.Text = negocioAlu.agregarAlumno(alum);
                    txtbx_legajo.Text = null;
                    txtbx_nombre.Text = null;
                    txtbx_apellido.Text = null;
                    txtbx_email.Text = null;
                }
            }

            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

            AlumnoNegocio alumnoExcel = new AlumnoNegocio();
            int cantAlumno = 0;
            char separador = char.Parse(txtDelimitar.Text);
            String fullpath = "";


            int encabezado = 0;
            try
            {
                encabezado = int.Parse(DropDownList1.SelectedValue);
            }
            catch (Exception)
            {
                encabezado = 0;
            }
            try
            {
                //El archivo seleccionado se guarda temporalmente en la carpeta Archivos
                fullpath = System.AppDomain.CurrentDomain.BaseDirectory + "\\Archivos\\" + fExaminar.FileName;
                fExaminar.SaveAs(fullpath);
                var registros = File.ReadAllLines(fullpath);
                //Se lee cada linea, se convierte a string y se lo divide en 4
                foreach (var line in File.ReadLines(fullpath, Encoding.Default).Skip(encabezado))
                {
                    try
                    {

                        var linea = line.Split(separador);
                        Alumno al = new Alumno(linea[0], linea[1], linea[2], linea[3]);
                        //Se agrega el alumno
                        if (alumnoExcel.agregarAlumno(al) == "Alumno Agregado correctamente")
                            cantAlumno++;
                    }
                    catch (Exception)
                    {

                        File.Delete(fullpath);
                        break;
                    }
                }
                File.Delete(fullpath);
            }
            catch (Exception)
            {
                File.Delete(fullpath);
            }

            lblRuta.Text = cantAlumno.ToString() + " registros agregados";


        }


        protected void btn_CMasiva_Click(object sender, EventArgs e)
        {
            lbl_res.Text = "";
            Panel3.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }


        protected void btn_inscribir_Click(object sender, EventArgs e)        /*btn panel*/
        {
            try
            {
                lbl_res.Text = "";
                ///VERIFICAR SI HAY NEGOCIO INSCRIPTO
                CuatrimestreNegocio neg = new CuatrimestreNegocio();
                if (neg.cargarLosCuatri() != null)
                    if (neg.cargarLosCuatri().Rows.Count > 0)
                    {
                        Panel3.Visible = false;
                        Panel2.Visible = false;
                        Panel1.Visible = false;
                        Panel4.Visible = true;
                        Panel5.Visible = false;

                    }
                    else
                        lbl_res.Text = "No hay Cuatrimestres cargados";
            }


                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_add_inscripto_Click(object sender, EventArgs e)         /*btn form inscripto*/
        {
            try
            {
                if ((ddlCuatrimestre.SelectedValue != null || ddlCuatrimestre.SelectedValue != "")
               && ddlAlumnos.SelectedValue != null || ddlAlumnos.SelectedValue != "")
                {
                    insc = new Inscriptos();
                    negocioInsc = new InscriptosNegocio();
                    insc.Alum = new Alumno();
                    negocioAlu = new AlumnoNegocio();
                    insc.IdCuatrimestre = int.Parse(ddlCuatrimestre.SelectedValue);
                    insc.Alum.Legajo = ddlAlumnos.SelectedValue;
                    //insc.Estado = "True";
                    lbl_res.Text = negocioInsc.agregarInscripto(insc);
                    ddlAlumnos.DataSource = negocioAlu.cargarTodosLosAlumnosApenom();
                    ddlAlumnos.DataValueField = "legajo_alumnos";
                    ddlAlumnos.DataTextField = "apenom";
                    ddlAlumnos.DataBind();

                }

            }
            catch (Exception)
            {
                lbl_res.Text = "No se pudo inscribir";
            }


        }

        protected void btn_edit_inscriptos_Click(object sender, EventArgs e)
        {
            lbl_res.Text = "";
            Panel3.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            cargarGrdInscriptos();
        }




        /*GRD INSCRIPTOS*/
        protected void grdInscriptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                insc = new Inscriptos();
                negocioInsc = new InscriptosNegocio();
                insc.Alum = new Alumno();
                insc.Alum.Legajo = ((Label)grdInscriptos.Rows[e.RowIndex].FindControl("lblLegajoInsc2")).Text;
                insc.Estado = "Eliminado";
                negocioInsc.eliminarInsc(insc);

                cargarGrdInscriptos();

                Session.Remove("editando");
            }




                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdInscriptos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                InscriptosNegocio neg = new InscriptosNegocio();
                //insc.IdCuatrimestre = int.Parse(((DropDownList)grdAlumnos.Rows[e.RowIndex].FindControl("id_cuatrimestre_inscriptos")).SelectedValue);
                insc = new Inscriptos();
                insc.Alum = new Alumno();
                insc.Alum.Legajo = ((Label)grdInscriptos.Rows[e.RowIndex].FindControl("lblLegajoInsc1")).Text;
                insc.Encuesta = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblEncuestaInsc1")).Text;
                insc.Observaciones = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblObservacionesInsc1")).Text.ToString();
                insc.Discord = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblDiscordInsc1")).Text.ToString();

                string grupo = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblGrupoInsc1")).Text;
                if (grupo != "")
                    insc.Grupo = int.Parse(((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblGrupoInsc1")).Text);
                else {
                    insc.Grupo = -1;
                }
                insc.Proyecto = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblProyectoInsc1")).Text.ToString();
                insc.Condicion = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblCondicionInsc1")).Text.ToString();
                insc.Documentacion = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblDocumentacionInsc1")).Text.ToString();
                insc.Estado = ((TextBox)grdInscriptos.Rows[e.RowIndex].FindControl("lblEstadoInsc1")).Text;


                neg.editarInscripto(insc);
                grdInscriptos.EditIndex = -1;

                cargarGrdInscriptos();
                Session.Remove("editando");
            }


            catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdInscriptos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdInscriptos.EditIndex = -1;
                cargarGrd();

                Session.Remove("editando");
            }


                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void grdInscriptos_RowEditing(object sender, GridViewEditEventArgs e)
        {

            try
            {
                Session.Add("editando", true);
                grdInscriptos.EditIndex = e.NewEditIndex;
                cargarGrd();
            }



                        catch (Exception i)
            {
                Session.Add("error", i.ToString());
                Response.Redirect("Error.aspx");
            }

        }


        private void cargarGrdInscriptos()
        {
            try
            {
                negocioInsc = new InscriptosNegocio();
                grdInscriptos.DataSource = negocioInsc.cargarTodosInscriptos();
                grdInscriptos.DataBind();
                if (negocioInsc.IsConex())
                {
                    lbl_res.Text = "CONECTADO";

                    if (grdInscriptos.Rows.Count > 0)
                    {

                        grdInscriptos.UseAccessibleHeader = true;
                        grdInscriptos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                }
                else
                    lbl_res.Text = "NO CONECTADO";
            }
            catch (Exception)
            {

                lbl_res.Text = "NO SE PUDO CARGAR LOS ALUMNOS INSCRIPTOS";
            }

        }
    }
}