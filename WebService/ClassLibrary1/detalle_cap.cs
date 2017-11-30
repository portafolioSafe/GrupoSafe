using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class detalle_cap
    {
        private int nota;

        public int Nota
        {
            get { return nota; }
            set { nota = value; }
        }
        private int asistencia;

        public int Asistencia
        {
            get { return asistencia; }
            set { asistencia = value; }
        }
        private int id_cap;

        public int Id_cap
        {
            get { return id_cap; }
            set { id_cap = value; }
        }
        private string area_cap;

        public string Area_cap
        {
            get { return area_cap; }
            set { area_cap = value; }
        }
        private string expositor;

        public string Expositor
        {
            get { return expositor; }
            set { expositor = value; }
        }
        private string tema;

        public string Tema
        {
            get { return tema; }
            set { tema = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string rut_usuario;

        public string Rut_usuario
        {
            get { return rut_usuario; }
            set { rut_usuario = value; }
        }

    }
}
