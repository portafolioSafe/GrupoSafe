using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Evaluacion
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string obstec;

        public string Obstec
        {
            get { return obstec; }
            set { obstec = value; }
        }
        private string obsing;

        public string Obsing
        {
            get { return obsing; }
            set { obsing = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int id_tipo;

        public int Id_tipo
        {
            get { return id_tipo; }
            set { id_tipo = value; }
        }
        private string id_empresa;

        public string Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }
        private string id_usuario;

        public string Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public Evaluacion()
        {

        }

        public Evaluacion(int id, DateTime fecha, string obstec, string obsing, string estado, int id_tipo, string id_empresa, string id_usuario)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Obstec = obstec;
            this.Obsing = obsing;
            this.Estado = estado;
            this.Id_tipo = id_tipo;
            this.Id_empresa = id_empresa;
            this.Id_usuario = id_usuario;
        }


    }
}
