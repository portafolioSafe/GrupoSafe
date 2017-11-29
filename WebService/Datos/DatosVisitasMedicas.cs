using System;
using ClassLibrary1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Datos
{

    public class DatosVisitasMedicas
    {
        public static List<visitasMedicas> listadoVisitas(){
        
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                List<visitasMedicas> listado = new List<visitasMedicas>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("LISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "visita_medica.LISTAR_VIS";
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
                        visitasMedicas cap = new visitasMedicas();
                        cap.Id = int.Parse(dr["ID_VISITA"].ToString());
                        cap.Estado = dr["ESTADO"].ToString();
                        cap.Lugar = dr["LUGAR"].ToString();
                        cap.Fecha = dr["FECHA"].ToString().Substring(0, 11);
                        cap.Hora = dr["HORA"].ToString();
                        cap.Rut_empresa = dr["EMPRESA_RUT_EMPRESA"].ToString();
                        cap.Tipo_examen = int.Parse(dr["TIPO_EXAMEN_ID_TIPO_EX"].ToString());

                        listado.Add(cap);
                    }

                    conn.Close();
                    return listado;
                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
        
        }//

        public static List<visitasMedicas> listadoVisitasxEmpresa( string empresa)
        {

            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                List<visitasMedicas> listado = new List<visitasMedicas>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("LISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "visita_medica.LISTAR_VIS";
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
                        if (dr["EMPRESA_RUT_EMPRESA"].ToString() == empresa)
                        {
                            visitasMedicas cap = new visitasMedicas();
                            cap.Id = int.Parse(dr["ID_VISITA"].ToString());
                            cap.Estado = dr["ESTADO"].ToString();
                            cap.Lugar = dr["LUGAR"].ToString();
                            cap.Fecha = dr["FECHA"].ToString().Substring(0, 11);
                            cap.Hora = dr["HORA"].ToString();
                            cap.Rut_empresa = dr["EMPRESA_RUT_EMPRESA"].ToString();
                            cap.Tipo_examen = int.Parse(dr["TIPO_EXAMEN_ID_TIPO_EX"].ToString());

                            listado.Add(cap);
                        }
                    }

                    conn.Close();
                    return listado;
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }//

        public static visitasMedicas ShowVisita(int id_cap_edit)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("LISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "visita_medica.LISTAR_VIS";
                oracmd.CommandType = CommandType.StoredProcedure;
                oracmd.Connection = conn;
                OracleDataAdapter da = new OracleDataAdapter(oracmd);
                DataSet ds = new DataSet();

                visitasMedicas cap = new visitasMedicas();
                try
                {
                    conn.Open();
                    da.Fill(ds);
                    OracleDataReader dr = oracmd.ExecuteReader();
                    while (dr.Read())
                    {

                        if (int.Parse(dr["ID_VISITA"].ToString()) == id_cap_edit)
                        {

                            cap.Id = int.Parse(dr["ID_VISITA"].ToString());
                            cap.Estado = dr["ESTADO"].ToString();
                            cap.Lugar = dr["LUGAR"].ToString();
                            cap.Fecha = dr["FECHA"].ToString().Substring(0, 11);
                            cap.Hora = dr["HORA"].ToString();
                            cap.Rut_empresa = dr["EMPRESA_RUT_EMPRESA"].ToString();
                            cap.Tipo_examen = int.Parse(dr["TIPO_EXAMEN_ID_TIPO_EX"].ToString());

                            return cap;
                        }

                    }

                    conn.Close();
                    return cap;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }


    }
}
