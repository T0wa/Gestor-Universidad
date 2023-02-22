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
    public class CuatrimestreNegocio
    {
        DaoCuatrimestre daoCuatri = new DaoCuatrimestre();
        public void eliminarCuatri(Cuatrimestre cuatri)
        {
            daoCuatri.EliminarCuatri(cuatri);
        }

        public DataTable cargarLosCuatri()
        {
            return daoCuatri.getTablaCuatri();
        }

        public DataTable cargarLosCuatriDDL()
        {
            return daoCuatri.getTablaCuatriDDL();
        }
        public void editarCuatri(Cuatrimestre cuatri)
        {
            daoCuatri.ActualizarCuatri(cuatri);
        }
        public Boolean IsConex()
        {
            return daoCuatri.isConex();
        }

        public String agregarCuatri(Cuatrimestre cuatri)
        {
            int cantFilas = 0;

            if (!daoCuatri.ExisteCuatri(cuatri))
            {
                cantFilas = daoCuatri.getCantidad();
                daoCuatri.AgregarCuatri(cuatri);
                if (cantFilas < daoCuatri.getCantidad())
                    return "Cuatrimestre agregado";
                else
                    return "El Cuatrimestre no se pudo agregar correctamente";
            }
            else
                return "Existe el id";
        }
    }
}
