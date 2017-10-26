using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class medico
    {
        private string rut_medico;

        public string Rut_medico
        {
            get { return rut_medico; }
            set { rut_medico = value; }
        }

   
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string especialidad;

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public medico() { }
    }
}
