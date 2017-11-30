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
        public static bool GuardarVisita(string lugar, DateTime fecha, DateTime hora,string empresa, int tipoexamen)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())


                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("visita_medica.INSERTAR_VISITA", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    DateTime meme = DateTime.Today;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 

                    cmd.Parameters.Add("ESTAD", "varchar2").Value = "Pendiente";
                    // cmd.Parameters.Add("FECHA", System.Data.SqlDbType.DateTime) = fecha;
                    cmd.Parameters.Add("LUGA", "varchar2").Value = lugar;
                    cmd.Parameters.Add("FECH", "date").Value = fecha.ToShortDateString();
                    cmd.Parameters.Add("HOR", "date").Value = fecha.ToShortDateString();
                    cmd.Parameters.Add("EMPRES", "varchar2").Value = empresa;

                    cmd.Parameters.Add("TIPO_EX", "number").Value = tipoexamen;
                    

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
        }//


        public static List<examen_tipo> listarTipoExamen()
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<examen_tipo> listado = new List<examen_tipo>();
           
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listarexa", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PROCEDIMIENTOS_EXAMEN.listarExamen";
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
                        if (dr["ESTADO"].ToString() == "Activo")
                        {


                            examen_tipo nueva = new examen_tipo();
                            nueva.Id = int.Parse(dr["ID_TIPO_EX"].ToString());
                            nueva.Nombre = dr["NOMBRE_EX"].ToString();
                            listado.Add(nueva);
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
        }
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

        public static bool editarVisita(int id_edit, string lugar, DateTime fecha, DateTime hora, string empresa, int tipoexamen)
        {

            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("visita_medica.MODIFICAR_VISITA", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();

                    DateTime fecha1 = DateTime.Now.Date;
         

                    cmd.Parameters.Add("ID_", "number").Value = id_edit;
                    cmd.Parameters.Add("ESTAD", "varchar2").Value = "Pendiente";
                    // cmd.Parameters.Add("FECHA", System.Data.SqlDbType.DateTime) = fecha;
                    cmd.Parameters.Add("LUGA", "varchar2").Value = lugar;
                    cmd.Parameters.Add("FECH", "date").Value = fecha.ToShortDateString();
                    cmd.Parameters.Add("HOR", "date").Value = fecha.ToShortDateString();
                    cmd.Parameters.Add("EMPRES", "varchar2").Value = empresa;

                    cmd.Parameters.Add("TIPO_EX", "number").Value = tipoexamen;


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

        }//




    }
}
