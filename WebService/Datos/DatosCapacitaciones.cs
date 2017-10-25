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

    public class DatosCapacitaciones
    {
        public static List<capacitacion> ListadoCapacitacion()
        {

            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<capacitacion> listado = new List<capacitacion>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listarCAP", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PROCEDIMIENTO_CAPACITACIONES.LISTAR_CAPACITACIONES";
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
                        capacitacion cap = new capacitacion();
                        cap.Id = int.Parse(dr["ID_CAP"].ToString());
                        cap.Area = dr["AREA_CAPACITACION"].ToString();


                        cap.Fecha = dr["FECHA"].ToString().Substring(0, 11);
                        cap.Tema = dr["TEMA"].ToString();
                        cap.Expositor = dr["EXPOSITOR"].ToString();
                        cap.Asistencia = int.Parse(dr["ASISTENCIA_MIN"].ToString());
                        cap.Rut_empresa = dr["NOMBRE"].ToString();
                        cap.Tipo_cap = dr["TIPO"].ToString();

                        listado.Add(cap);
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

        public static capacitacion ShowCapacitacion(int id_cap_edit)
        {

            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listarCAP", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PROCEDIMIENTO_CAPACITACIONES.LISTAR_CAPACITACIONES_SIN_JOIN";
                oracmd.CommandType = CommandType.StoredProcedure;
                oracmd.Connection = conn;
                OracleDataAdapter da = new OracleDataAdapter(oracmd);
                DataSet ds = new DataSet();
                capacitacion cap = new capacitacion();
                try
                {
                    conn.Open();
                    da.Fill(ds);
                    OracleDataReader dr = oracmd.ExecuteReader();
                    while (dr.Read())
                    {


                        if (int.Parse(dr["ID_CAP"].ToString()) == id_cap_edit)
                        {

                            cap.Id = int.Parse(dr["ID_CAP"].ToString());
                            cap.Area = dr["AREA_CAPACITACION"].ToString();


                            cap.Fecha = dr["FECHA"].ToString().Substring(0, 11);
                            cap.Tema = dr["TEMA"].ToString();
                            cap.Expositor = dr["EXPOSITOR"].ToString();
                            cap.Asistencia = int.Parse(dr["ASISTENCIA_MIN"].ToString());
                            cap.Estado = dr["ESTADO"].ToString();
                            cap.Tipo_cap = dr["TIPO_CAP_ID_TIPOC"].ToString();
                            cap.Rut_empresa = int.Parse(dr["EMPRESA_RUT_EMPRESA"].ToString()).ToString();






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

        public static bool editarCapacitacion(int id_edit, string area, DateTime fecha, string tema, string expo, int asisten, string empresa, int tipocap)
        {




            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("PROCEDIMIENTO_CAPACITACIONES.MODIFICAR_CAPACITACION", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();

                    DateTime fecha1 = DateTime.Now.Date;


                    cmd.Parameters.Add("ID_C", "number").Value = id_edit;
                    cmd.Parameters.Add("ARECAP", "varchar2").Value = area;
                    // cmd.Parameters.Add("FECHA", System.Data.SqlDbType.DateTime) = fecha;
                    cmd.Parameters.Add("FECHA", "date").Value = fecha.ToShortDateString();
                    cmd.Parameters.Add("TEMA", "varchar2").Value = tema;
                    cmd.Parameters.Add("EXPOSITOR", "varchar2").Value = expo;
                    cmd.Parameters.Add("ASISTENCIA", "number").Value = asisten;

                    cmd.Parameters.Add("EMPRESA", "varchar2").Value = empresa;
                    cmd.Parameters.Add("TIPO", "number").Value = tipocap;


                    //falta estado?

                    cmd.ExecuteNonQuery();
                    conn.Close();
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
