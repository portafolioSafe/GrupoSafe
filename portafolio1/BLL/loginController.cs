using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class loginController
    {
        private string username;
        private string pass;

        public string devuelveNombre(string us, string pw, string tipo) {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            
            return ws.Validar(us, pw, tipo);
        
        }


        public string devuelvetipo(string us, string tipo)
        {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

            return ws.DevuelveTipo(us, tipo);

        }
    }
}
