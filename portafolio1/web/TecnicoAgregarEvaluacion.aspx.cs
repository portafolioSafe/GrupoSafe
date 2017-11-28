using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class TecnicoAgregarEvaluacion : System.Web.UI.Page
    {
        static List<BLL.DetallePreguntaDTO> listado = new List<BLL.DetallePreguntaDTO>();
        static List<BLL.DetallePreguntaDTO> listado2 = new List<BLL.DetallePreguntaDTO>();
  
        static string rut = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Tecnico")
            {
                Response.Redirect("Home.aspx");
            }
            mensajeSI.Visible = false;
            mensajeNO.Visible = false;
            MensajeNa.Visible = false;

            rut = Session["Rut"].ToString();

            if (IsPostBack)
            {
                //Page.SetFocus(TextBox1);
            }
            if (!IsPostBack)
            {

                

            }



        }




        protected void rb_Yes_Click(object sender, EventArgs e)
        {

            RadioButton rb_Yes = (RadioButton)sender;
            GridViewRow grid_row = (GridViewRow)rb_Yes.NamingContainer;
            if (((RadioButton)grid_row.FindControl("rb_Yes")).Checked == true)
            {
                BLL.DetallePreguntaDTO de = new BLL.DetallePreguntaDTO();
                int idPregunta = int.Parse(grid_row.Cells[0].Text);
                
                

                if (listado.Count == 0)
                {
                    //de.IdEvaluacion = iDe;
                    de.IdPregunta = idPregunta;
                    de.Respuesta = "si";
                    listado.Add(de);

                }
                else
                {


                    for (int i = 0; i < listado.Count; i++)
                    {
                       

                        if (listado.ElementAtOrDefault(i).IdPregunta == idPregunta)
                        {
                            listado.RemoveAt(i);
                            de.IdPregunta = idPregunta;
                            //de.IdEvaluacion = iDe;
                            de.Respuesta = "si";


                            listado.Add(de);
                            break;
                        }
                        else
                        {
                           // de.IdEvaluacion = iDe;
                            de.IdPregunta = idPregunta;
                            de.Respuesta = "si";
                            listado.Add(de);
                            break;
                        }
                    }

                    
                }
                
               
                



            }
        }




        protected void rb_No_Click(object sender, EventArgs e)
        {
            RadioButton rb_No = (RadioButton)sender;
            GridViewRow grid_row = (GridViewRow)rb_No.NamingContainer;
            if (((RadioButton)grid_row.FindControl("rb_No")).Checked == true)
            {
                BLL.DetallePreguntaDTO de = new BLL.DetallePreguntaDTO();
                int idPregunta = int.Parse(grid_row.Cells[0].Text);
                int iDe = 0;
                foreach (var item in BLL.EvaluacionDTO.ultimaEvaluacionXtecnico(rut))
                {
                    iDe = item.Id + 1;
                }

               

                if (listado.Count == 0)
                {
                    //de.IdEvaluacion = iDe;
                    de.IdPregunta = idPregunta;
                    de.Respuesta = "No";
                    listado.Add(de);

                }
                else
                {
                    
                    for (int i = 0; i < listado.Count; i++)
                    {
                        
                        if (listado.ElementAtOrDefault(i).IdPregunta == idPregunta)
                        {
                            listado.RemoveAt(i);
                            de.IdPregunta = idPregunta;
                            //de.IdEvaluacion = iDe;
                            de.Respuesta = "No";

                            listado.Add(de);
                            break;

                        }
                        else
                        {
                           // de.IdEvaluacion = iDe;
                            de.IdPregunta = idPregunta;
                            de.Respuesta = "No";
                            listado.Add(de);
                            break;
                        }
                    }


                }


            }
        }

        protected void rb_Na_Click(object sender, EventArgs e)
        {

            RadioButton rb_Na = (RadioButton)sender;
            GridViewRow grid_row = (GridViewRow)rb_Na.NamingContainer;
            if (((RadioButton)grid_row.FindControl("rb_Na")).Checked == true)
            {
                BLL.DetallePreguntaDTO de = new BLL.DetallePreguntaDTO();
                int idPregunta = int.Parse(grid_row.Cells[0].Text);



                if (listado.Count == 0)
                {
                    //de.IdEvaluacion = iDe;
                    de.IdPregunta = idPregunta;
                    de.Respuesta = "Na";
                    listado.Add(de);

                }
                else
                {


                    for (int i = 0; i < listado.Count; i++)
                    {


                        if (listado.ElementAtOrDefault(i).IdPregunta == idPregunta)
                        {
                            listado.RemoveAt(i);
                            de.IdPregunta = idPregunta;
                            //de.IdEvaluacion = iDe;
                            de.Respuesta = "Na";


                            listado.Add(de);
                            break;
                        }
                        else
                        {
                            // de.IdEvaluacion = iDe;
                            de.IdPregunta = idPregunta;
                            de.Respuesta = "Na";
                            listado.Add(de);
                            break;
                        }
                    }


                }






            }
        }

        public DataTable GetData(int idtipo)
        {
            DataTable dt = new DataTable();


           dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Pregunta") });


            foreach (var item in BLL.CategoriaDTO.ListarXtipo(idtipo))
            {
                foreach (var item2 in BLL.PreguntasDTO.ListarXcategoria(item.Id))
                {
                    dt.Rows.Add(item2.Id,item2.Pregunta1);
                    

                }
            }


            return dt;
        }









        protected void Button1_Click(object sender, EventArgs e)
        {
            string empresa = DropDownList1.SelectedItem.Value;
            int tipo_evaluacion = int.Parse(DropDownList2.SelectedItem.Value);
            DateTime fecha = DateTime.Now;
            string obst = TextBox1.Text;
            string obsI = "Sin observaciones pendiente a revisar";
            string estado = "Enviado";
            DataTable a = GetData(tipo_evaluacion);
           int contador = a.Rows.Count;

            if (TextBox1.Text == "")
            {
                obst = "Sin observaciones";
            }
            if (listado.Count != 0 && listado.Count == contador)
            {
               

                bool res = BLL.EvaluacionDTO.AgregarEvaluacion(empresa, tipo_evaluacion, rut, fecha, obst, obsI, estado);
                if (res)
                {
                    int ide = 0;
                    foreach (var item in BLL.EvaluacionDTO.ultimaEvaluacionXtecnico(rut))
                    {
                        ide = item.Id;
                    }
                    BLL.DetallePreguntaDTO det = new BLL.DetallePreguntaDTO();
                    foreach (var item in listado)
                    {

                        //det.IdEvaluacion = ide;
                        //det.IdPregunta = item.IdPregunta;
                        //det.Respuesta = item.Respuesta;
                        BLL.DetallePreguntaDTO.AgregarDetalle(ide, item.IdPregunta, item.Respuesta);
                    }
                    mensajeSI.Visible = true;
                    // se muestra algo 
                    listado.Clear();
                }
                else
                {
                    mensajeSI.Visible = false;
                    // error al agregar
                    listado.Clear();
                }
            }
            else
            {
                MensajeNa.Visible = true;
            }

            listado.Clear();



        }
    }
}