using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class tipo_examenDTO
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


        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.examen_tipo> ListarTipoExamen()
        {
            ServiceReference1.examen_tipo tipoExamen = new ServiceReference1.examen_tipo();
            return ws.listarTipoExamen1();
        }


    }
}
