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
    public class DatosDetalleCap
    {

        public static string AsistirCapcitacion(int ID_CAPACITACION, string USUARIO_RUT)
        {



            string mensaje = "";
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("PKG_DETALLE_CAP.INSERTAR_DETALLE_CAP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<detalle_cap> listadetalle = listarDetalleCap();

                foreach (detalle_cap item in listadetalle)
                {

                    if (item.Rut_usuario == USUARIO_RUT && item.Id_cap == ID_CAPACITACION)
                    {
                        mensaje = "YA EXISTE";

                    }
                }
                if (mensaje != "YA EXISTE")
                {
                    cmd.Parameters.Add("NOTITA", "number").Value = 0;
                    cmd.Parameters.Add("ASISTE", "number").Value = 0;
                    cmd.Parameters.Add("ID_CAPACITACION", "number").Value = ID_CAPACITACION;
                    cmd.Parameters.Add("USUARIO_RUT", OracleDbType.Varchar2).Value = USUARIO_RUT;

                    mensaje = "AGREGADO";
                }
                else
                {
                    return mensaje;

                }

                try
                {
                    if (mensaje == "AGREGADO")
                    {
                        conn.Open();


                        cmd.ExecuteNonQuery();
                        conn.Close();


                        return mensaje;
                    }
                    else
                    { return mensaje; }

                }
                catch (Exception ex)
                {
                    return mensaje;
                    throw ex;
                }




            }
        }
        public static List<ClassLibrary1.detalle_cap> listarDetalleCap()
        {


            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<ClassLibrary1.detalle_cap> listado = new List<ClassLibrary1.detalle_cap>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listar", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PKG_DETALLE_CAP.LISTAR_DETALLE_CAP";
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

                        ClassLibrary1.detalle_cap cap = new ClassLibrary1.detalle_cap();
                        cap.Nota = int.Parse(dr["NOTA"].ToString());
                        cap.Asistencia = int.Parse(dr["ASISTENCIA"].ToString());

                        cap.Id_cap = int.Parse(dr["CAPACITACION_ID_CAP"].ToString());
                        cap.Area_cap = dr["AREA_CAPACITACION"].ToString();
                        cap.Expositor = dr["EXPOSITOR"].ToString();
                        cap.Tema = dr["TEMA"].ToString();
                        cap.Tipo = dr["TIPO"].ToString();
                        cap.Rut_usuario = dr["USUARIO_RUT_USUARIO"].ToString();

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



        public static List<ClassLibrary1.detalle_cap> listarDetalleCapxUsuario(string rut_usuario)
        {


            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<ClassLibrary1.detalle_cap> listado = new List<ClassLibrary1.detalle_cap>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("listar", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PKG_DETALLE_CAP.LISTAR_DETALLE_CAP";
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
                        if (dr["USUARIO_RUT_USUARIO"].ToString() == rut_usuario)
                        {


                            ClassLibrary1.detalle_cap cap = new ClassLibrary1.detalle_cap();
                            cap.Nota = int.Parse(dr["NOTA"].ToString());
                            cap.Asistencia = int.Parse(dr["ASISTENCIA"].ToString());

                            cap.Id_cap = int.Parse(dr["CAPACITACION_ID_CAP"].ToString());
                            cap.Area_cap = dr["AREA_CAPACITACION"].ToString();
                            cap.Expositor = dr["EXPOSITOR"].ToString();
                            cap.Tema = dr["TEMA"].ToString();
                            cap.Tipo = dr["TIPO"].ToString();
                            cap.Rut_usuario = dr["USUARIO_RUT_USUARIO"].ToString();

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
    }
}
