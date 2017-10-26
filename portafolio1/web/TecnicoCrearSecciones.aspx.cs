using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace web
{
    public partial class TecnicoCrearSecciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Tecnico")
            {
                Response.Redirect("Home.aspx");
            }
            mensajeSI.Visible = false;
            mensajeNO.Visible = false;
            mensajeNa.Visible = false;
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string pregunta = TextBox1.Text;

            if (int.Parse(DropDownList1.SelectedItem.Value) !=0 )
            {
                int id = int.Parse(DropDownList1.SelectedItem.Value);
                if (pregunta != "")
                {
                     BLL.PreguntasDTO.AgregarPregunta(id, pregunta);
                    GridView1.DataBind();
                    TextBox1.Text = " ";
                    mensajeSI.Visible = true;
                }
                else
                {
                    mensajeNa.Visible = true;
                }
            }
            else
            {
                mensajeNO.Visible = true;
            }
            
            
           

        }
    }
}