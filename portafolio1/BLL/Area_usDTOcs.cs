using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Area_usDTO
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



        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.area> listarArea()
        {
            ServiceReference1.area cat = new ServiceReference1.area();
            return ws.listarArea();
        }
    }
}