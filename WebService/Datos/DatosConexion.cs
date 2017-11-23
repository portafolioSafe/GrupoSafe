using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Datos
{
    public class DatosConexion
    {

        //private static volatile DatosConexion instance;
        //private static object syncRoot = new Object();
        


        private string password, user;

        public DatosConexion()
        { }
        ///
        /// Permite crear una cadena de conexión tipo Oracle
        /// </summary>
        ///

       
    


    public OracleConnection Connect()
        {
            ////////////////////////////////////////////////////////////////////////////////////
            //Referencia estática al usuario y password ingresados en el login de la aplicación/
            ////////////////////////////////////////////////////////////////////////////////////
            user = "GRUPOSAFE";
            password = "portafolio";

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                throw new Exception("El usuario y el password son datos requeridos");
            }
          
            string strConnectionString = "DATA SOURCE = 190.161.202.171:1521/DBORACLE; USER ID = GRUPOSAFE;Password = portafolio; pooling=false";

            OracleConnection conn = new OracleConnection();

            conn.ConnectionString = strConnectionString;
            return conn;
        }

    }
}
