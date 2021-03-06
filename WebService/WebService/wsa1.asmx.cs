﻿using ClassLibrary1;
using Datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Descripción breve de wsa1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsa1 : System.Web.Services.WebService
    {
//METODOS DE AUTENTICACION

        [WebMethod]
        public string ValidarUsuario(string rut, string pass)
        {
            string us = "";

            //string meme = "DATA SOURCE = 190.161.202.171:1521 / DBORACLE; USER ID = GRUPOSAFE;Password = portafolio;";
            //OracleConnection conn = new OracleConnection(meme);
            Datos.DatosConexion c = new Datos.DatosConexion();
            OracleConnection conn = new OracleConnection();
            using (conn = c.Connect())
            {
                try
                {

                    conn.Open();

                    OracleParameter param = new OracleParameter();
                    param.OracleDbType = OracleDbType.Decimal;

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.Add(param);
                    // estado para empresa y usuario
                    cmd.CommandText = "SELECT  RUT_USUARIO , NOMBRE, ESTADO FROM USUARIO WHERE RUT_USUARIO = '" + rut + "' AND CONTRASEÑA ='" + pass + "'";
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        OracleDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.GetString(2) == "inactivo")
                        {
                            us = "malo";

                        }
                        else
                        {
                            us = dr.GetString(1);

                        }


                    }
                    catch (Exception)
                    {

                        us = "nulo";

                    }


                }
                catch (Exception)
                {
                    us = "server";

                }

                
                conn.Close();
                return us;


            }


        }

        [WebMethod]
        public string ValidarEmpresa(string rut, string pass)
        {
            string us = "";

            string meme = "DATA SOURCE = 190.161.202.171:1521 / DBORACLE; USER ID = GRUPOSAFE;Password = portafolio;";
            OracleConnection conn = new OracleConnection(meme);

            try
            {

                conn.Open();

                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Decimal;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add(param);
                // estado para empresa y usuario
                cmd.CommandText = "SELECT  RUT_EMPRESA , NOMBRE, ESTADO FROM EMPRESA WHERE RUT_EMPRESA = '" + rut + "' AND CONTRASEÑA ='" + pass + "'";
                cmd.CommandType = CommandType.Text;

                try
                {
                    cmd.ExecuteNonQuery();
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.GetString(2) == "inactivo")
                    {
                        us = "malo";

                    }
                    else
                    {
                        us = dr.GetString(1);

                    }


                }
                catch (Exception)
                {

                    us = "nulo";

                }


            }
            catch (Exception)
            {
                us = "server";
            }
            conn.Close();
            return us;
        }

        [WebMethod]
        public string ValidarMedico(string rut, string pass)
        {
            string us = "";

            string meme = "DATA SOURCE = 190.161.202.171:1521 / DBORACLE; USER ID = GRUPOSAFE;Password = portafolio;";
            OracleConnection conn = new OracleConnection(meme);

            try
            {

                conn.Open();

                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Decimal;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add(param);
                // estado para empresa y usuario
                cmd.CommandText = "SELECT  RUT_MEDICO , NOMBRE FROM MEDICO WHERE RUT_MEDICO = '" + rut + "' AND CONTRASENA ='" + pass + "'";
                cmd.CommandType = CommandType.Text;

                try
                {
                    cmd.ExecuteNonQuery();
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();





                    us = dr.GetString(1);

                    


                }
                catch (Exception)
                {

                    us = "nulo";

                }


            }
            catch (Exception)
            {
                us = "server";
            }
            conn.Close();
            return us;
        }

        [WebMethod]
        public string devuelveEmpresa(string trabajador )
        {
            string us = "";

            string meme = "DATA SOURCE = 190.161.202.171:1521 / DBORACLE; USER ID = GRUPOSAFE;Password = portafolio;";
            OracleConnection conn = new OracleConnection(meme);

            try
            {

                conn.Open();

                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Decimal;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add(param);
                // estado para empresa y usuario
                cmd.CommandText = "Select e.NOMBRE from USUARIO u join EMPRESA e on u.EMPRESA_RUT_EMPRESA= e.RUT_EMPRESA WHERE u.RUT_USUARIO='"+trabajador+"'";
                cmd.CommandType = CommandType.Text;

                try
                {
                    cmd.ExecuteNonQuery();
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();





                    us = dr.GetString(0);




                }
                catch (Exception)
                {

                    us = "nulo";

                }


            }
            catch (Exception)
            {
                us = "server";
            }
            conn.Close();
            return us;
        }

        [WebMethod]
        public string Validar(string rut, string pass, string tipo)
        {
            string us = "";
            string rut_login = "";
            if (tipo == "Empresa")
            {
                rut_login = "RUT_EMPRESA";
            }
            else if(tipo == "Medico")
            {
                rut_login = "RUT_MEDICO";
            }
            else {
                rut_login = "RUT_USUARIO";
            }
            string meme = "DATA SOURCE = 190.161.202.171:1521 / DBORACLE; USER ID = GRUPOSAFE;Password = portafolio;";
            OracleConnection conn = new OracleConnection(meme);
            try
            {

                conn.Open();

                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Decimal;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add(param);
                // estado para empresa y usuario
                cmd.CommandText = "SELECT " + rut_login + " , NOMBRE FROM " + tipo + " WHERE " + rut_login + " = '" + rut + "' AND CONTRASENA ='" + pass + "'";
                cmd.CommandType = CommandType.Text;



                try
                {
                    cmd.ExecuteNonQuery();
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.GetString(2) == "inactivo")
                    {
                        us = "malo";
                       
                    }
                    else
                    {
                        us = dr.GetString(1);
                  
                    }



                }
                catch (Exception)
                {

                    us = "nulo";
                
                }

            }
            catch (Exception)
            {
                us = "server";
               
            }
            conn.Close();
            return us;




        }

        [WebMethod]
        public string DevuelveTipo(string rut, string tipo)
        {
            DatosConexion c = new DatosConexion();
            OracleConnection conn = new OracleConnection();
            using (conn = c.Connect())
            {
                string us = "";
                if (tipo == "Medico")
                {
                    us = "Médico";
                }
                if (tipo == "Usuario")
                {




                    try
                    {

                        conn.Open();

                        //se escoge el pakete y despues el procedimiento 
                        OracleCommand oracmd = new OracleCommand();

                        oracmd.CommandText = "PROCEDIMIENTO_USUARIO.SELECT_TIPO";
                        oracmd.CommandType = CommandType.StoredProcedure;
                        oracmd.Connection = conn;

                        //Se colocan las variables del procedimiento el tipo y despues la variable con el dato
                        oracmd.Parameters.Add("RUT", "varchar2").Value = rut;
                        oracmd.Parameters.Add("listarsalida", OracleDbType.RefCursor, ParameterDirection.Output);
                        oracmd.ExecuteNonQuery();
                        OracleDataReader reader;
                        try
                        {
                            reader = oracmd.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader.GetString(0) == "Administrador")
                                {
                                    us = "nope";
                                    //conn.Close();
                                }
                                else
                                {
                                    us = reader.GetString(0);
                                    //conn.Close();
                                }
                            }
                        }

                        catch (Exception)
                        {
                            us = "tipo_nulo";

                        }



                    }
                    catch (Exception)
                    {

                        us = "server";

                    }

                }
                else if (tipo == "Empresa")
                {
                    us = "Cliente";

                }

                conn.Close();

                return us;


            }




        }




        //FIN AUTENTICACION

        //METODOS LISTAR PARA COMBOBOX
        [WebMethod]
          public List<empresa> GetlistarEmpresaList()
          {
              return Datos.DatosEmpresa.ListadoEmpresas();
          }
        [WebMethod]
        public List<empresa> listarEmpresaActivas()
        {
            return Datos.DatosEmpresa.ListadoEmpresasACTIVOS();
        }

        [WebMethod]
          public List<cap_tipo> GetListarTipoCap()
          {
              return Datos.DatosCapacitaciones.GetListarTipoCap();  
          }

         [WebMethod]
          public List<area> listarArea()
          {

            Datos.DatosConexion c = new Datos.DatosConexion();
            OracleConnection conn = new OracleConnection();
            using (conn = c.Connect())
            {
                conn.Open();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("LISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = "CARGO_TIPO_US.LISTAR_AREA";
                oracmd.CommandType = CommandType.StoredProcedure;
                oracmd.Connection = conn;
                OracleDataAdapter da = new OracleDataAdapter(oracmd);
                DataSet ds = new DataSet();
                List<area> milista = new List<area>();
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    area nueva = new area();
                    nueva.Id = Int32.Parse(row[0].ToString());
                    nueva.Nombre_area = row[1].ToString();
                    milista.Add(nueva);
                    //milista.Add(string.Format("{0}" + " " + "{1}", row["RUT_EMPRESA"], row["NOMBRE"]));
                }
                conn.Close();
                return milista;

            }


               
              

          }
    
//FIN LISTAR

//METODOS DE CAPACITACION
         [WebMethod]
         public bool GuardarCapacitacion(string area, DateTime fecha, string tema, string expo, int asisten, string empresa, int tipocap)
         {
             return Datos.DatosCapacitaciones.GuardarCapacitacion(area,fecha,tema,expo,asisten,empresa,tipocap);
         }

        [WebMethod]
        public List<capacitacion> ListarCapacitaciones()
        {

            return Datos.DatosCapacitaciones.ListadoCapacitacion();
        }

        [WebMethod]
        public capacitacion ShowCapacitacion(int id_cap_edit)
        {
            return Datos.DatosCapacitaciones.ShowCapacitacion(id_cap_edit);
        }

        [WebMethod]
        public bool editarCApacitacion(int id_edit, string area, DateTime fecha, string tema, string expo, int asisten, string empresa, int tipocap)
        {

            if (Datos.DatosCapacitaciones.editarCapacitacion(id_edit, area, fecha, tema, expo, asisten, empresa, tipocap))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public List<capacitacion> ListarCapacitacionesxfecha(string empresaNombre)
        {

            return Datos.DatosCapacitaciones.ListadoCapacitacionXfecha(empresaNombre);
        }

        [WebMethod]
        public List<capacitacion> ListarCapacitacionesxempresa(string empresaNombre)
        {

            return Datos.DatosCapacitaciones.ListadoCapacitacionXempresa(empresaNombre);
        }
        [WebMethod]
        public List<capacitacion> ListadoCapacitacionXaño(string empresa, int year)
        {

            return Datos.DatosCapacitaciones.ListadoCapacitacionXaño(empresa, year);
        }


        [WebMethod]
        public string AsistirCapcitacion(int ID_CAPACITACION, string USUARIO_RUT)
        {
            return Datos.DatosDetalleCap.AsistirCapcitacion(ID_CAPACITACION, USUARIO_RUT);


        }
        [WebMethod]
        public List<detalle_cap> listarDetalleCap()
        {

            return Datos.DatosDetalleCap.listarDetalleCap();
        }
        [WebMethod]
        public List<detalle_cap>  listarDetalleCapxUsuario(string rut_usuario)
        {

            return Datos.DatosDetalleCap.listarDetalleCapxUsuario(rut_usuario);
        }
   



        //FIN CAPACITACION

        //METODOS MEDICO
        [WebMethod]
        public bool M_guardarMedico(string rut, string nombre, string apellido, string especialidad, string correo, string pass)
        {
            if (Datos.DatosMedico.guardarMedico(rut, nombre, apellido, especialidad, correo, pass))
            {
                return true;
            }
            else {
                return false;
            }
           
        }
        [WebMethod]
        public string AsignarMedico(int id_visita, string rut_medico) {

            return Datos.DatosDetalle_visita.AsignarMedico(id_visita,rut_medico);
        }

 //FIN MEDICO

        //**************************************************************************************
        //*****************Ws Modulo evaluaciones
        //ws Categoria
        [WebMethod]
        public bool E_guardarCategoria(string cat, int id)
        {
            return Datos.DatosCategoria.GuardarCategoria(cat, id);
        }


        [WebMethod]
        public List<categoria> E_listadoCategoria()
        {
            return Datos.DatosCategoria.ListarCategoria();
        }

        [WebMethod]
        public List<categoria> E_listarCategoriasXtipo(int id)
        {
            return Datos.DatosCategoria.listarCategoriaXtipo(id);
        }

        //WS pregunta
        [WebMethod]
        public bool E_agregarPregunta(int id, string p)
        {
            return Datos.DatosPregunta.AgregarPregunta(id, p);
        }

        //detalle pregunta
        [WebMethod]
        public bool E_agregarDetallePregunta(string p , int idP, int idE)
        {
            return Datos.DatosDetalle_evaluacion.Agregar_detalle(idE,idP,p);
        }
        [WebMethod]
        public List<Pregunta> E_listarPreguntaXcategoria(int id)
        {
            return Datos.DatosPregunta.ListadoPreguntasXcat(id);
        }

        //wsEmpresa
        [WebMethod]
        public List<empresa> E_listarempresa()
        {
            return Datos.DatosEmpresa.ListadoEmpresas();
        }
       


        [WebMethod]
        public List<ClassLibrary1.TipoEvaluaciones> listadodeevaluaciones()
        {
            return Datos.DatosTipoEvaluacion.ListarTipo();
        }
        //evaluacion
        [WebMethod]
        public bool E_agregarEvaluacion(DateTime fecha, string obsTec, string recIng, string estado, int idT, string idE, string rut)
        {
            return Datos.DatosEvaluaciones.AgregarEvaluaciones(fecha,obsTec,recIng,estado,idT,idE,rut);
        }

        [WebMethod]
        public bool E_modificarEvaluacion(int id, string p, string estado)
        {
            return Datos.DatosEvaluaciones.ModificacionIngeniero(id,p,estado);
        }

        [WebMethod]
        public List<ClassLibrary1.Evaluacion> listadoUltimaEvaluacion(string rut)
        {
            return Datos.DatosEvaluaciones.idultimaEvaluacion(rut);
        }

        //Lisatar evaluaciones por tecnico 
        [WebMethod]
        public List<ClassLibrary1.Evaluacion> E_listadoPorTecnico(string rut)
        {
            return Datos.DatosEvaluaciones.ListarEvaluacion(rut);

        }

        //Listar todas las evaluaciones para el ingeniero
        [WebMethod]
        public List<ClassLibrary1.Evaluacion> E_ListadoIngeniero()
        {
            return Datos.DatosEvaluaciones.ListarTodo();
        }
        //Listar el detalle de las evaluaciones por evaluacion 
        [WebMethod]
        public List<ClassLibrary1.Detalle_evaluacion> E_listadoDetalle(int evaluacion)
        {
            return Datos.DatosDetalle_evaluacion.LisarDetalle(evaluacion);
        }
        
        [WebMethod]
        public bool ModificarCategoria(int id, string cat, string estado)
        {
            return Datos.DatosCategoria.ModificarCategoria(id,cat,estado);
        }
        [WebMethod]
        public bool ModificarPregunta(int id, string pregunta, string estado)
        {
            return Datos.DatosPregunta.ModificarPregunta(id,pregunta,estado);
        }

        //-----------VISITAS MEDICAS--------------

       
        [WebMethod]
        public bool GuardarVisita(string lugar, DateTime fecha, DateTime hora,string empresa, int tipoexamen)
        {
            return Datos.DatosVisitasMedicas.GuardarVisita(lugar,fecha,hora,empresa,tipoexamen);

        }
        //LISTAR TIPO EXAMEN
     
        [WebMethod]
        public List<examen_tipo> listarTipoExamen1()
        {
            return Datos.DatosVisitasMedicas.listarTipoExamen();

        }
        //LISTAR VISITAS MEDICAS
        [WebMethod]
        public List<visitasMedicas> listarVisitas() {
            return Datos.DatosVisitasMedicas.listadoVisitas();

        }
        //LISTAR VISITAS SEGUN LA EMPRESA
        [WebMethod]
        public List<visitasMedicas> listarVisitasxempresa(string empresa)
        {
            return Datos.DatosVisitasMedicas.listadoVisitasxEmpresa(empresa);

        }
        //BUSQUEDA DE VISITA POR ID
        [WebMethod]
        public visitasMedicas MostrarVisita(int id)
        {
            return Datos.DatosVisitasMedicas.ShowVisita(id);

        }
    }





}
