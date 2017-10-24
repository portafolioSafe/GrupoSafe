using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpresaDTO
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

            
          ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
           
          public List<ServiceReference1.empresa> GetlistarEmpresaList()
        {
            ServiceReference1.empresa cat = new ServiceReference1.empresa();
            return ws.GetlistarEmpresaList();
        } 
        
        public EmpresaDTO()
        { 
        
        
        }



    }
}
