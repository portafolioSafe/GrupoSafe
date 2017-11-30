using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Formulario_web8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Supervisor")
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.visitasDTO meme = new BLL.visitasDTO();

            if (meme.GuardarVisita(txtLugar.Text, Calendar1.SelectedDate, Calendar1.SelectedDate, Comboemp.Text, Int32.Parse(Combotipocap.Text)))
            {

                mensajeSI.Visible = true;

            }
            else
            {
                mensajeNO.Visible = true;
            }
        }
    }
}