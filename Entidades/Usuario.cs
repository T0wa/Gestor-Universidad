using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
  
        private String user;
        private String apellido;
        private String nombre;
        private String mail;
        private String password;
        private Boolean estado;
    

        public Usuario()
        { }
        public Usuario( String user, String apellido, String nombre, String mail, String password)
        {
           
            this.user = user;
            this.apellido = apellido;
            this.nombre = nombre;
            this.mail = mail;
            this.password = password;
         

        }

      
        public string User { get => user; set => user = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
