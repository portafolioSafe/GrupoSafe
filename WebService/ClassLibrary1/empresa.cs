using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class empresa
    {
        private string rut_empresa;

        public string Rut_empresa
        {
            get { return rut_empresa; }
            set { rut_empresa = value; }
        }
        private string nombre_empresa;

        public string Nombre_empresa
        {
            get { return nombre_empresa; }
            set { nombre_empresa = value; }
        }


        public empresa() { }


    }
}
