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
    public class InscriptosNegocio
    {
        DaoInscriptos daoInsc = new DaoInscriptos();
        public void eliminarInsc(Inscriptos insc)
        {
            daoInsc.EliminarInscripto(insc);
        }

        public DataTable cargarTodosInscriptos()
        {
            return daoInsc.getTablaInscriptos();
        }

        public void editarInscripto(Inscriptos insc)
        {
            daoInsc.ActualizarInscripto(insc);
        }
        public Boolean IsConex()
        {
            return daoInsc.isConex();
        }

        public String agregarInscripto(Inscriptos insc)
        {
            int cantFilas = 0;

            if (!daoInsc.ExisteInscripto(insc))
            {
                cantFilas = daoInsc.getCantidad();
                daoInsc.AgregarInscripto(insc);
                if (cantFilas < daoInsc.getCantidad())
                    return "Inscripcion exitosa";
                else
                    return "La inscripcion no se pudo agregar correctamente";
            }
            else
                return "Existe el id";
        }

    }
}

