using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inscriptos
    {
        private int idCuatrimestre { get; set; }
        private Alumno alum { get; set; }
        private String condicion { get; set; }
        private String encuesta { get; set; }
        private int grupo { get; set; }
        private String discord { get; set; }
        private String documentacion { get; set; }
        private String proyecto { get; set; }
        private String observaciones { get; set; }
        private String estado { get; set; }


        public Inscriptos()
        { }
        public Inscriptos(int id, Alumno alum, String condicion, String encuesta, int grupo, String discord, String documentacion, String proyecto, String observaciones, String estado)
        {
            this.idCuatrimestre = id;
            this.alum = alum;
            this.condicion = condicion;
            this.encuesta = encuesta;
            this.grupo = grupo;
            this.discord = discord;
            this.documentacion = documentacion;
            this.proyecto = proyecto;
            this.observaciones = observaciones;
            this.estado = estado;
        }

        public int IdCuatrimestre { get => idCuatrimestre; set => idCuatrimestre = value; }
        public Alumno Alum { get => alum; set => alum = value; }
        public String Condicion { get => condicion; set => condicion = value; }
        public String Encuesta { get => encuesta; set => encuesta = value; }
        public int Grupo { get => grupo; set => grupo = value; }
        public String Discord { get => discord; set => discord = value; }
        public String Documentacion { get => documentacion; set => documentacion = value; }
        public String Proyecto { get => proyecto; set => proyecto = value; }
        public String Observaciones { get => observaciones; set => observaciones = value; }
        public String Estado { get => estado; set => estado = value; }
    }
}
