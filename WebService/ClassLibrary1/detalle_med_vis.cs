using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class detalle_med_vis
    {
        private int id_visita;
        private string rut_medico;
        private string estado;
        private string fecha;

        public int Id_visita
        {
            get { return id_visita; }
            set { id_visita = value; }


        }
        public string Rut_medico
        {
            get { return rut_medico; }
            set { rut_medico = value; }

        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }

        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }

        }

        public detalle_med_vis() { }
    }
}