using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoEvaluacionDTO
    {


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public TipoEvaluacionDTO()
        {

        }

       

        public TipoEvaluacionDTO(int id, string nombre, string estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = estado;
        }

       

        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.TipoEvaluaciones> listadodeEvaluaciones()
        {
            return ws.listadodeevaluaciones();
        }

        public List<ServiceReference1.Evaluacion> lis(string rut)
        {
            return ws.listadoUltimaEvaluacion(rut);
        }

    }
}
