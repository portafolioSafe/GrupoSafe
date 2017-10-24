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

             rut = Session["Rut"].ToString();


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
                int iDe = 0;
                foreach (var item in BLL.EvaluacionDTO.ultimaEvaluacionXtecnico(rut))
                {
                   iDe = item.Id+1;
                }

                if (listado.Count == 0)
                {
                    de.IdEvaluacion = iDe;
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
                            de.IdEvaluacion = iDe;
                            de.Respuesta = "si";


                            listado.Add(de);
                            break;
                        }
                        else
                        {
                            de.IdEvaluacion = iDe;
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
                    de.IdEvaluacion = iDe;
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
                            de.IdEvaluacion = iDe;
                            de.Respuesta = "No";

                            listado.Add(de);
                            break;

                        }
                        else
                        {
                            de.IdEvaluacion = iDe;
                            de.IdPregunta = idPregunta;
                            de.Respuesta = "No";
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



            foreach (var item in listado)
            {
                System.Windows.Forms.MessageBox.Show("Pregunta y respuesta" + item.IdPregunta + "Respuesta : "+ item.Respuesta , "escogio si", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }

            listado.Clear();



        }
    }
}