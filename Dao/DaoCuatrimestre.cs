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
    public class DaoCuatrimestre
    {
        AccesoDatos ad = new AccesoDatos();
        public Cuatrimestre getCuatrimestre(Cuatrimestre cuatri)
        {
            DataTable tabla = ad.ObtenerTabla("cuatrimestres", "SELECT id_cuatrimestres, descripcion_cuatrimestres, año_cuatrimestres, cuatrimestre_cuatrimestres FROM cuatrimestres WHERE id_cuatrimestres = ' " + cuatri.Id + "' AND estado='true'");

            cuatri.Id = (int)tabla.Rows[0][0];
            cuatri.Descripcion = tabla.Rows[0][1].ToString();
            cuatri.Anio = (int)tabla.Rows[0][2];
            cuatri.NumCuatrimestre = (int)tabla.Rows[0][3];
            return cuatri;
        }
        public DataTable getTablaCuatri()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.cuatrimestres", "SELECT * FROM cuatrimestres WHERE estado='true'");
            return tabla;
        }
        public DataTable getTablaCuatriDDL()
        {
            DataTable tabla = ad.ObtenerTabla("practica_supervisada.cuatrimestres", "select id_cuatrimestres, ('C° ' || cuatrimestre_cuatrimestres || ' - Año: ' || año_cuatrimestres) as ddl from cuatrimestres WHERE estado='true'");
            return tabla;
        }


        public DataTable getConsulta(string n)
        {
            DataTable tabla = ad.ObtenerTabla("cuatrimestres", "SELECT * FROM cuatrimestres WHERE id_cuatrimestres LIKE '" + n + "%' ");
            return tabla;
        }

        public int getCantidad()
        {
            int x = 0;
            DataTable tabla = (ad.ObtenerTabla("cuatrimestres", "SELECT COUNT(ID_Cuatrimestres) FROM cuatrimestres"));
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

        public DataTable setOrden(String orden)
        {
            DataTable tabla = ad.ObtenerTabla("cuatrimestres", "SELECT * FROM cuatrimestres AND estado='true' ORDER BY " + orden + "");
            return tabla;
        }

        public bool ExisteCuatri(Cuatrimestre cuatri)
        {
            return ad.Existe("SELECT * FROM cuatrimestres WHERE id_cuatrimestres ='" + cuatri.Id + "'");
        }

        public int EliminarCuatri(Cuatrimestre cuatri)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
            parametro.Value = cuatri.Id;
            return ad.EjecutarProcAlmacenado(cmd, "sp_eliminar_cuatrimestre");
        }

        public int AgregarCuatri(Cuatrimestre cuatri)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@cuatrimestre", NpgsqlDbType.Varchar);
            parametro.Value = cuatri.Descripcion;
            parametro = cmd.Parameters.Add("@año", NpgsqlDbType.Integer);
            parametro.Value = cuatri.Anio;
            parametro = cmd.Parameters.Add("@numerocua", NpgsqlDbType.Integer);
            parametro.Value = cuatri.NumCuatrimestre;
            return ad.EjecutarProcAlmacenado(cmd, "sp_insertar_cuatrimestre");
        }
        public int ActualizarCuatri(Cuatrimestre cuatri)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlParameter parametro = new NpgsqlParameter();
            parametro = cmd.Parameters.Add("@descripcion", NpgsqlDbType.Varchar);
            parametro.Value = cuatri.Descripcion;
            parametro = cmd.Parameters.Add("@año", NpgsqlDbType.Integer);
            parametro.Value = cuatri.Anio;
            parametro = cmd.Parameters.Add("@numero", NpgsqlDbType.Integer);
            parametro.Value = cuatri.NumCuatrimestre;
            parametro = cmd.Parameters.Add("@id", NpgsqlDbType.Integer);
            parametro.Value = cuatri.Id;
            return ad.EjecutarProcAlmacenado(cmd, "update_cuatrimestres");
        }

        public DataTable filtrarCuatri(string filtro)
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
