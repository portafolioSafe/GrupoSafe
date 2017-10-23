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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pregunta;

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int id_cat;

        public int Id_cat
        {
            get { return id_cat; }
            set { id_cat = value; }
        }

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



        //public bool AgregarPregunta()
        //{

        //}



    }
}
