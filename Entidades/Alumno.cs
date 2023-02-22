using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        private String legajo;
        private String nombre;
        private String apellido;
        private String mail;
        private Boolean estado;

        public Alumno(string _legajo, string _nombre, string _apellido, string _mail)
        {
            this.legajo = _legajo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.mail = _mail;
        }

        public Alumno() { }

        public string Legajo { get => legajo; set => legajo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
