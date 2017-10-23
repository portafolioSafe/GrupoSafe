using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class PreguntasDTO
    {
        private int id;
        private string pregunta;
        private string estado;
        private int id_cat;

        public PreguntasDTO()
        {

        }

        public PreguntasDTO(int id, string pregunta, string estado, int id_cat)
        {
            this.Id = id;
            this.Pregunta = pregunta;
            this.Estado = estado;
            this.Id_cat = id_cat;
        }

        public int Id { get => id; set => id = value; }
        public string Pregunta { get => pregunta; set => pregunta = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Id_cat { get => id_cat; set => id_cat = value; }



        //public bool AgregarPregunta()
        //{

        //}



    }
}
