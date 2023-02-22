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
    public class DaoInscriptos
    {

        AccesoDatos ad = new AccesoDatos();

        public DataTable getTablaInscriptos()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.inscriptos", "SELECT * FROM inscriptos");
            return tabla;
        }

        public int getCantidad()
        {
            int x = 0;
            DataTable tabla = (ad.ObtenerTabla("inscriptos", "SELECT COUNT(legajoalumno_inscriptos) FROM inscriptos"));
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
        public bool ExisteInscripto(Inscriptos insc)
        {
            return ad.Existe("SELECT * FROM inscriptos WHERE legajoalumno_inscriptos ='" + insc.Alum.Legajo + "'");
        }


        public int EliminarInscripto(Inscriptos insc)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = insc.Alum.Legajo;
            parametro = cmd.Parameters.Add("@estado", NpgsqlDbType.Varchar);
            parametro.Value = insc.Estado;
            return ad.EjecutarProcAlmacenado(cmd, "sp_eliminar_inscripto2");
        }

        public int AgregarInscripto(Inscriptos insc)
        {
            string nulo = "";
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();

            parametro = cmd.Parameters.Add("@idcuatrimestre", NpgsqlDbType.Integer);
            parametro.Value = insc.IdCuatrimestre;
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = insc.Alum.Legajo;
            //parametro = cmd.Parameters.Add("@estado", NpgsqlDbType.Boolean);
            //parametro.Value = insc.Estado;

            /*
            parametro = cmd.Parameters.Add("@condicion", NpgsqlDbType.Varchar);
            if (insc.Condicion == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Condicion;
            }


            parametro = cmd.Parameters.Add("@encuesta", NpgsqlDbType.Varchar);
            if (insc.Encuesta == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Encuesta;
            }


            parametro = cmd.Parameters.Add("@grupo", NpgsqlDbType.Integer);
            parametro.Value = insc.Grupo;


            parametro = cmd.Parameters.Add("@discord", NpgsqlDbType.Varchar);
            if (insc.Discord == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Discord;
            }


            parametro = cmd.Parameters.Add("@documentacion", NpgsqlDbType.Varchar);

            if (insc.Documentacion == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Documentacion;
            }


            parametro = cmd.Parameters.Add("@proyecto", NpgsqlDbType.Varchar);
            parametro.Value = insc.Proyecto;
            if (insc.Proyecto == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Proyecto;
            }


            parametro = cmd.Parameters.Add("@observaciones", NpgsqlDbType.Varchar);
            parametro.Value = insc.Observaciones;
            if (insc.Observaciones == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Observaciones;
            }


            parametro = cmd.Parameters.Add("@estado", NpgsqlDbType.Varchar);
            parametro.Value = insc.Estado;
            if (insc.Estado == null)
            {
                parametro.Value = nulo;
            }
            else
            {
                parametro.Value = insc.Estado;
            }

            */
            return ad.EjecutarProcAlmacenado(cmd, "sp_insertar_inscriptos2");



        }

        public int ActualizarInscripto(Inscriptos insc)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = insc.Alum.Legajo;
            parametro = cmd.Parameters.Add("@encuesta", NpgsqlDbType.Varchar);
            parametro.Value = insc.Encuesta;
            parametro = cmd.Parameters.Add("@observaciones", NpgsqlDbType.Varchar);
            parametro.Value = insc.Observaciones;
            parametro = cmd.Parameters.Add("@discord", NpgsqlDbType.Varchar);
            parametro.Value = insc.Discord;
            parametro = cmd.Parameters.Add("@grupo", NpgsqlDbType.Integer);
            parametro.Value = insc.Grupo;
            parametro = cmd.Parameters.Add("@proyecto", NpgsqlDbType.Varchar);
            parametro.Value = insc.Proyecto;
            parametro = cmd.Parameters.Add("@condicion", NpgsqlDbType.Varchar);
            parametro.Value = insc.Condicion;
            parametro = cmd.Parameters.Add("@documentacion", NpgsqlDbType.Varchar);
            parametro.Value = insc.Documentacion;
            parametro = cmd.Parameters.Add("@estado", NpgsqlDbType.Varchar);
            parametro.Value = insc.Estado;
            return ad.EjecutarProcAlmacenado(cmd, "sp_actualizar_inscripto");
        }

        public Boolean isConex()
        {
            return ad.IsConex();
        }
    }
}
