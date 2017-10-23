using ClassLibrary1;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{

        public  class DatosCapacitaciones
    {
       public static List<capacitacion> ListadoCapacitacion()
       {
           
           DatosConexion c = new DatosConexion();
           using (OracleConnection conn = c.Connect())
           {
               List<capacitacion> listado = new List<capacitacion>();
               OracleCommand oracmd = new OracleCommand();
               oracmd.Parameters.Add("listarE", OracleDbType.RefCursor, ParameterDirection.Output);
               oracmd.CommandText = "PKG_EVALUACION.ListarEMP";
               oracmd.CommandType = CommandType.StoredProcedure;
               oracmd.Connection = conn;
               OracleDataAdapter da = new OracleDataAdapter(oracmd);
               DataSet ds = new DataSet();
               try
               {
                   conn.Open();
                   da.Fill(ds);
                   OracleDataReader dr = oracmd.ExecuteReader();
                   while (dr.Read())
                   {
                       capacitacion ev = new capacitacion();
                     
                       listado.Add(ev);
                   }
                   conn.Close();
                   return listado;

               }
               catch (Exception ex)
               {

                   throw ex;
               }
           }
       }


    }
}
