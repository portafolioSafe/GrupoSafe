using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class visitasMedicas
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string lugar;

        public string Lugar
        {
            get { return lugar; }
            set { lugar = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private string rut_empresa;

        public string Rut_empresa
        {
            get { return rut_empresa; }
            set { rut_empresa = value; }
        }
        private int tipo_examen;

        

        public int Tipo_examen
        {
            get { return tipo_examen; }
            set { tipo_examen = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public visitasMedicas() { }
   
       
    }
}
