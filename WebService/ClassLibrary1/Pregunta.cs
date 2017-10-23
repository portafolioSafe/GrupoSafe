using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Pregunta
    {
        private int id;
        private string pregunta1;
        private string estado;
        private int cat_id;

        public int Cat_id
        {
            get { return cat_id; }
            set { cat_id = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string Pregunta1
        {
            get { return pregunta1; }
            set { pregunta1 = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public Pregunta()
        {

        }

        public Pregunta(string pregunta, string estado, int cat_id)
        {
            this.Pregunta1 = pregunta;
            this.Estado = estado;
            this.Cat_id = cat_id;
        }


    }
}
