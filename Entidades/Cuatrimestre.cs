using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuatrimestre
    {
        private int id;
        private String descripcion;
        private int anio;
        private int numCuatrimestre;
        private Boolean estado;
        

        public Cuatrimestre(int _id, string _descripcion, int _anio, int _numCuatrimestre)
        {
            this.id = _id;
            this.descripcion = _descripcion;
            this.anio = _anio;
            this.numCuatrimestre = _numCuatrimestre;
        }
        public Cuatrimestre() { }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Anio { get => anio; set => anio = value; }
        public int NumCuatrimestre { get => numCuatrimestre; set => numCuatrimestre = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
