using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Detalle_evaluacion
    {
        private string pregunta;
        private int id_evaluacion;
        private int id_pregunta;

        public int Id_pregunta
        {
            get { return id_pregunta; }
            set { id_pregunta = value; }
        }
        public int Id_evaluacion
        {
            get { return id_evaluacion; }
            set { id_evaluacion = value; }
        }
        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }



        public Detalle_evaluacion()
        {

        }
        public Detalle_evaluacion(string pregunta, int id_evaluacion, int id_pregunta)
        {
            this.pregunta = pregunta;
            Id_evaluacion = id_evaluacion;
            Id_pregunta = id_pregunta;
        }


    }
}
