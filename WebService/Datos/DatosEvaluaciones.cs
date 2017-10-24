﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Datos
{
    public class DatosEvaluaciones
    {

        public static bool AgregarEvaluaciones(DateTime fecha, string obsTec,string recIng ,string estado, int idT, string idE, string rut)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("PKG_EVALUACION.Pro_AgregarEvaluacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("p_fecha", "date").Value = fecha.ToShortDateString();
                cmd.Parameters.Add("p_obsTec", OracleDbType.Varchar2).Value = obsTec;
                cmd.Parameters.Add("p_recIng", OracleDbType.Varchar2).Value = recIng;
                cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = estado;
                cmd.Parameters.Add("p_tipoEva", "number").Value = idT;
                cmd.Parameters.Add("p_empresa", "varchar2").Value = idE;
                cmd.Parameters.Add("p_usuario", "varchar2").Value = rut;

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

        public static bool ModificacionIngeniero(int idE, string obs)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {

                OracleCommand cmd = new OracleCommand("PKG_EVALUACION.Pro_ModificarAgregarIng", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_id", "number").Value = idE;
                cmd.Parameters.Add("p_recIng", "varchar2").Value = obs;
                cmd.Parameters.Add("p_estado", "number").Value = "Aprobada";

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        public static List<Evaluacion> idultimaEvaluacion(string rut)
        {
            DatosConexion c = new DatosConexion();
            using (OracleConnection conn = c.Connect())
            {
                List<Evaluacion> listado = new List<Evaluacion>();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add(new OracleParameter("p_usuario", rut));
                oracmd.Parameters.Add("listarEV", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "PKG_EVALUACION.Pro_UltimaEvaluacione";
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
                        Evaluacion ev = new Evaluacion();
                        ev.Id = int.Parse(dr["ID_EVALUACION"].ToString());
                        

                        listado.Add(ev);
                    }

                    conn.Close();
                    return listado;
                }
                catch (Exception EX)
                {

                    throw EX;
                }
            }

        }


        //public static List<Evaluacion> ListarEvaluacion(string rut)
        //{
        //    DatosConexion c = new DatosConexion();

        //    using (OracleConnection conn = c.Connect())
        //    {
        //        List<categoria> listado = new List<categoria>();
        //        OracleCommand oracmd = new OracleCommand();
        //        oracmd.Parameters.Add("ListarCat", OracleDbType.RefCursor, ParameterDirection.Output);
        //        oracmd.CommandText = "PKG_EVALUACION.Listar_cat";
        //        oracmd.CommandType = CommandType.StoredProcedure;
        //        oracmd.Connection = conn;
        //        OracleDataAdapter da = new OracleDataAdapter(oracmd);
        //        DataSet ds = new DataSet();

        //    }

        //}

    }
}
