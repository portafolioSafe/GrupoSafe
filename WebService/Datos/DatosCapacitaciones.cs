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

        public static List<capacitacion> ListadoCapacitacionXempresa(string empresa)
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
                        if (dr["NOMBRE"].ToString() == empresa)
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

        public static List<capacitacion> ListadoCapacitacionXfecha(string empresa) {

            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<capacitacion> listado = new List<capacitacion>();
                List<capacitacion> listadoxEmpresa = ListadoCapacitacionXempresa(empresa);

                try
                {
                    foreach (capacitacion item in listadoxEmpresa)
                    {
                            DateTime hoy = DateTime.Today;
                            string fechaSET = item.Fecha;
                            DateTime fechaIN = Convert.ToDateTime(fechaSET);
                           if  (fechaIN.DayOfYear > hoy.DayOfYear)
	                    {

                            capacitacion cap = new capacitacion();
                            cap.Id = item.Id;
                            cap.Area =item.Area;


                            cap.Fecha =item.Fecha;
                            cap.Tema = item.Tema;
                            cap.Expositor = item.Expositor;
                            cap.Asistencia = item.Asistencia;
                            cap.Rut_empresa = item.Rut_empresa;
                            cap.Tipo_cap = item.Tipo_cap;

                            listado.Add(cap);


                           }
                
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
        //fin Metodo
        public static bool AsistirCapcitacion(int ID_CAPACITACION,string USUARIO_RUT)
        {



            string mensaje = "";
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("PKG_DETALLE_CAP.INSERTAR_DETALLE_CAP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("NOTITA", "number").Value = 3;
                cmd.Parameters.Add("ASISTE", "number").Value = 3;
                cmd.Parameters.Add("ID_CAPACITACION", "number").Value = ID_CAPACITACION;
                cmd.Parameters.Add("USUARIO_RUT", OracleDbType.Varchar2).Value = USUARIO_RUT;



                try
                {
                    conn.Open();

      
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    mensaje = "true";

                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
        //fin Metodo

    }
}
