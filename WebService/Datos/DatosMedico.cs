using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosMedico
    {

        public static bool guardarMedico(string rut, string nombre, string apellido, string especialidad, string correo, string pass) { 
        
         DatosConexion c = new DatosConexion();
         using (OracleConnection oraconn = c.Connect())
         {
             try{
              oraconn.Open();
              OracleCommand cmd = new OracleCommand("PROCEDIMIENTO_MEDICO.AGREGAR_MEDICO", oraconn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               
             
          
                cmd.Parameters.Add("RUT", "varchar2").Value = rut;
                cmd.Parameters.Add("NOMBRE_", "varchar2").Value = nombre;
                cmd.Parameters.Add("APELLIDO_", "varchar2").Value = apellido;
                cmd.Parameters.Add("ESPECIALIDAD_", "varchar2").Value = especialidad;
                cmd.Parameters.Add("CORREO_", "varchar2").Value = correo;
                cmd.Parameters.Add("CONTRASENA_", "varchar2").Value = pass;
                
      

                //falta estado?

                cmd.ExecuteNonQuery();
                oraconn.Close();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
         
         
         }
        }
    }
}
