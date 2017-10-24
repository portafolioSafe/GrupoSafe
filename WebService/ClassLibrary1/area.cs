using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class area
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre_area;

        public string Nombre_area
        {
            get { return nombre_area; }
            set { nombre_area = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public area() { }
    }
}
