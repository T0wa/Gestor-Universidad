using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Dao;

namespace Negocio
{
    public class AlumnoNegocio
    {
        DaoAlumno daoAlu = new DaoAlumno();
        public void eliminarAlumno(Alumno alum)
        {
            daoAlu.EliminarAlumno(alum);
        }

        public DataTable cargarTodosLosAlumnos()
        {
            return daoAlu.getTablaAlumno();
        }

        public DataTable cargarTodosLosAlumnosApenom()
        {
            return daoAlu.getTablaAlumnoApenom();
        }

        public void editarAlumno(Alumno alu)
        {
            daoAlu.ActualizarAlumno(alu);
        }
        public Boolean IsConex()
        {
            return daoAlu.isConex();
        }

        public String agregarAlumno(Alumno alu)
        {
                    daoAlu.AgregarAlumno(alu);
                        return "Alumno Agregado correctamente";
            }
        }
    
}
