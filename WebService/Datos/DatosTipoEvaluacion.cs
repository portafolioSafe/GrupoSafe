using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Datos
{
    public class DatosTipoEvaluacion
    {
        public static List<ClassLibrary1.TipoEvaluaciones> ListarTipo()
        {

            DatosConexion c = new DatosConexion();


            using (OracleConnection conn = c.Connect())
            {
                List<ClassLibrary1.TipoEvaluaciones> listado = new List<ClassLibrary1.TipoEvaluaciones>();


                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listarEval", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PKG_EVALUACION.ListarTipoEval";
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
                        ClassLibrary1.TipoEvaluaciones ev = new ClassLibrary1.TipoEvaluaciones();
                        ev.Id = int.Parse(dr["ID_TIPO"].ToString());
                        ev.Nombre = dr["NOMBRE_TIPO"].ToString();

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
