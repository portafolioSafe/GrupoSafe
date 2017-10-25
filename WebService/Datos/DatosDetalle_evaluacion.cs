using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ClassLibrary1;
using System.Data;

namespace Datos
{
    public class DatosDetalle_evaluacion
    {
        public static bool Agregar_detalle(int idE, int idP, string p)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                OracleCommand cmd = new OracleCommand("PKG_EVALUACION.pro_AgregarDetalle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_respuesta", "varchar2").Value = p;
                cmd.Parameters.Add("p_id_eval", "number").Value = idE;
                cmd.Parameters.Add("p_id_pre", "number").Value = idP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        }

        public static List<Detalle_evaluacion> LisarDetalle(int  evaluacion)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<Detalle_evaluacion> listado = new List<Detalle_evaluacion>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add(new OracleParameter("ListarDetalle", evaluacion));
                oracmd.Parameters.Add("listarI", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PKG_EVALUACION.pro_listarDetalle";
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
                        ClassLibrary1.Detalle_evaluacion ev = new ClassLibrary1.Detalle_evaluacion();
                        ev.Id_evaluacion = int.Parse(dr["EVALUACION_ID_EVALUACION"].ToString());
                        ev.Id_pregunta= int.Parse(dr["PREGUNTAS_ID_PREGUNTA"].ToString());
                        ev.Pregunta = dr["RESPUESTA"].ToString();

                        listado.Add(ev);
                    }


                    conn.Close();
                    return listado;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }

        }


    }
}
