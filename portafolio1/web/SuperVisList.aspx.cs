using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Formulario_web120 : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Supervisor")
            {
                Response.Redirect("Home.aspx");
            }



            id = int.Parse(Session["Id_evaluacion"].ToString());
            mensajeSI.Visible = false;
            if (!IsPostBack)
            {
                foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
                {


                    if (item.Id == id)
                    {
                        string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                        string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                        Empresa.Text = nombre;
                        lbl_Rut.Text = item.Id_empresa;
                        lbl_tipo.Text = nombreE;
                        lblfecha.Text = item.Fecha.ToString().Substring(0, 11);

                        GridView1.DataSource = GetData(item.Id_tipo, item.Id);
                        GridView1.DataBind();

                        TextBox1.Text = item.Obstec;
                        TextBox2.Text = item.Obsing;

                    }





                }

            }



        }

        public DataTable GetData(int id, int idE)
        {
            DataTable dt = new DataTable();


            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Pregunta"), new DataColumn("Respuesta") });

            foreach (var item in BLL.DetallePreguntaDTO.ListarDetalle(idE))
            {


                foreach (var item2 in BLL.CategoriaDTO.ListarXtipo(id))
                {
                    foreach (var item3 in BLL.PreguntasDTO.ListarXcategoria(item2.Id))
                    {

                        if (item.Id_pregunta == item3.Id)
                        {
                            dt.Rows.Add(item.Id_pregunta, item3.Pregunta1, item.Pregunta);
                        }
                    }
                }



                // dt.Rows.Add(item.Id_pregunta,);

            }

            return dt;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {


            Response.Redirect("SupervListIn.aspx");


        }
    }
}