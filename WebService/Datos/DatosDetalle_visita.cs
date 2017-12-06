using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosDetalle_visita
    {
        public static string AsignarMedico(int id_visita, string USUARIO_RUT)
        {



            string mensaje = "";
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("CONFIRMAR_VISITA.INSERTER_CONFIRMACION", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("ID_FI", "number").Value = id_visita;
                cmd.Parameters.Add("ID_MEDI", "number").Value = USUARIO_RUT;
                cmd.Parameters.Add("ESTAD", "varchar2").Value = "Asignado";
                cmd.Parameters.Add("FECH", "date").Value = DateTime.Today.ToShortDateString();

                mensaje = "AGREGADO";


             

                try
                {

                    conn.Open();


                    cmd.ExecuteNonQuery();
                    conn.Close();


                    return mensaje;


                }
                catch (Exception ex)
                {
                   
                    throw ex;
                }

            }


            }
        }


    }

