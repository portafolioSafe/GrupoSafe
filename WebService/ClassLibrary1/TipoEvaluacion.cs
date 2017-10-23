using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TipoEvaluacion
    {
        private int id;
        private string nombre;
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }




        public TipoEvaluacion()
        {

        }

        public TipoEvaluacion(int id, string nombre, string estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = estado;
        }


    }
}
