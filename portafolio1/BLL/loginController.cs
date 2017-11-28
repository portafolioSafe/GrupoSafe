using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class loginController
    {
        public string username;
        public string pass;

        //public string devuelveNombre(string us, string pw, string tipo) {

        //    ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            
        //    return ws.Validar(us, pw, tipo);
        
        //}



        public static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }


        public string validaUsuario(string rut, string pass) {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

            return ws.ValidarUsuario(rut, pass);

        }

        public string validaEmpresa(string rut, string pass)
        {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

            return ws.ValidarEmpresa(rut, pass);

        }

        public string validaMedico(string rut, string pass)
        {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

            return ws.ValidarMedico(rut, pass);

        }

        public string devuelveTipo(string rut, string tipo)
        {

            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

            return ws.DevuelveTipo(rut, tipo);

        }

        public static string devuelveNombreEmpresa(string rut_usuario) {
            string meme = "";

            ServiceReference1.wsa1SoapClient memito = new ServiceReference1.wsa1SoapClient();
            meme= memito.devuelveEmpresa(rut_usuario);

            return meme;
        
        }
    }
}
