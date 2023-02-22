using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Npgsql;
using NpgsqlTypes;

namespace Dao
{
    public class DaoAlumno
    {
        AccesoDatos ad = new AccesoDatos();
        public Alumno getAlumno(Alumno al)
        {
            DataTable tabla = ad.ObtenerTabla("alumnos", "SELECT legajo_alumnos, nombre_alumnos, apellido_alumnos, mail_alumnos FROM alumnos WHERE legajo_alumnos = ' " + al.Legajo + "' AND estado='true'");

            al.Legajo = tabla.Rows[0][0].ToString();
            al.Nombre = tabla.Rows[0][1].ToString();
            al.Apellido = tabla.Rows[0][2].ToString();
            al.Mail = tabla.Rows[0][3].ToString();
            return al;
        }
        public DataTable getTablaAlumno()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.alumnos", "SELECT * FROM alumnos order by estado desc");
            return tabla;
        }

        public DataTable getTablaAlumnoApenom()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.alumnos", "select legajo_alumnos, upper(apellido_alumnos || ', ' || nombre_alumnos) as apenom from alumnos as a WHERE NOT EXISTS (SELECT legajoalumno_inscriptos FROM inscriptos as i WHERE i.legajoalumno_inscriptos = a.legajo_alumnos)");   
            return tabla;
        }

        public DataTable getConsulta(string n)
        {
            DataTable tabla = ad.ObtenerTabla("alumnos", "SELECT * FROM alumnos WHERE legajo_alumnos LIKE '" + n + "%'");
            return tabla;
        }
        public int getCantidad()
        {
            int x = 0;
            DataTable tabla = (ad.ObtenerTabla("alumnos", "SELECT COUNT(legajo_alumnos) FROM alumnos WHERE estado='true'"));
            try
            {
                x = Int32.Parse(tabla.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                x = -1;
            }
            return x;
        }
        public DataTable setOrden(String orden)
        {
            DataTable tabla = ad.ObtenerTabla("alumnos", "SELECT * FROM alumnos ORDER BY " + orden + "");
            return tabla;
        }
        public bool ExisteAlumno(Alumno al)
        {
            return ad.Existe("SELECT * FROM alumnos WHERE legajo_alumnos ='" + al.Legajo + "'");
        }
        public bool ExisteEmail(Alumno al)
        {
            return ad.Existe("SELECT * FROM alumnos WHERE mail_alumnos ='" + al.Mail + "'");
        }
        public int EliminarAlumno(Alumno al)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = al.Legajo;
            return ad.EjecutarProcAlmacenado(cmd, "sp_eliminar_alumno");
        }

        public int AgregarAlumno(Alumno al)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = al.Legajo;
            parametro = cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar);
            parametro.Value = al.Nombre;
            parametro = cmd.Parameters.Add("@apellido", NpgsqlDbType.Varchar);
            parametro.Value = al.Apellido;
            parametro = cmd.Parameters.Add("@mail", NpgsqlDbType.Varchar);
            parametro.Value = al.Mail;
            return ad.EjecutarProcAlmacenado(cmd, "sp_agregar_alumno");
        }
        public int ActualizarAlumno(Alumno al)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar);
            parametro.Value = al.Nombre;
            parametro = cmd.Parameters.Add("@apellido", NpgsqlDbType.Varchar);
            parametro.Value = al.Apellido;
            parametro = cmd.Parameters.Add("@mail", NpgsqlDbType.Varchar);
            parametro.Value = al.Mail;
            parametro = cmd.Parameters.Add("@legajo", NpgsqlDbType.Varchar);
            parametro.Value = al.Legajo;
            return ad.EjecutarProcAlmacenado(cmd, "sp_actualizar_alumno");
        }

        public DataTable filtrarAlumno(string filtro)
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.alumnos", filtro);
            return tabla;
        }

        public Boolean isConex()
        {
            return ad.IsConex();
        }

    }
}
