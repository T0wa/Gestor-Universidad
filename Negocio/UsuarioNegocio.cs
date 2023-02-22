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
    public class UsuarioNegocio
    {
        DaoUsuario daoUsu = new DaoUsuario();
        public void eliminarUsu(Usuario usu)
        {
            daoUsu.EliminarUsuaario(usu);
        }

        public DataTable cargarLosUsu()
        {
            return daoUsu.getTablaUsu();
        }

        public void editarUsu(Usuario usu)
        {
            daoUsu.ActualizarUsuario(usu);
        }
        public Boolean IsConex()
        {
            return daoUsu.isConex();
        }

        public String agregarUsu(Usuario usu)
        {
            int cantFilas = 0;

            if (!daoUsu.ExisteUsu(usu))
            {
                cantFilas = daoUsu.getCantidad();
                daoUsu.AgregarUsuario(usu);
                if (cantFilas < daoUsu.getCantidad())
                    return "Usuario agregado";
                else
                    return "El Usuario no se pudo agregar correctamente";
            }
            else
                return "Existe el id";
        }

    }
}

