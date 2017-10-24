using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Windows.Forms;

namespace web
{
    public partial class Formulario_web6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Supervisor")
            {
                Response.Redirect("Home.aspx");
            }


            if (!IsPostBack)
            {

                ServiceReference1.wsa1SoapClient memito = new ServiceReference1.wsa1SoapClient();


                BLL.capacitacionDTO cap = new capacitacionDTO();


                capacitacionDTO editable = cap.showCapacitacion(Int32.Parse(Session["id_capacitacion"].ToString()));

                string cadenaCapital = cap.toCapital(editable.Area.ToLower());






                //Comboarea.Items.FindByText(editable.Area).Selected=true;
                //Comboemp.Items.FindByValue(editable.Rut_empresa).Selected=true;
                //Combotipocap.DataValueField = editable.Tipo_cap;
                Comboemp.DataBind();
                if (Comboemp.Items.FindByValue(editable.Rut_empresa) != null)
                    Comboemp.Items.FindByValue(editable.Rut_empresa).Selected = true;

                Comboarea.DataBind();
                if (Comboarea.Items.FindByValue(cadenaCapital) != null)
                    Comboarea.Items.FindByValue(cadenaCapital).Selected = true;

                Combotipocap.DataBind();
                if (Combotipocap.Items.FindByValue(editable.Tipo_cap) != null)
                    Combotipocap.Items.FindByValue(editable.Tipo_cap).Selected = true;



                txtExpositor.Text = editable.Expositor;
                Txttema.Text = editable.Tema;
                TxtAsistencia.Text = editable.Asistencia.ToString();
                Calendar1.SelectedDate = Convert.ToDateTime(editable.Fecha);
         
            

            }


            

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

 
           
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.capacitacionDTO cap = new capacitacionDTO();
            if(cap.editarCapacitacion(Int32.Parse(Session["id_capacitacion"].ToString()),Comboarea.Text, Calendar1.SelectedDate, Txttema.Text, txtExpositor.Text, Int32.Parse(TxtAsistencia.Text), Comboemp.Text, Int32.Parse(Combotipocap.Text)))
            {
                //MessageBox.Show("Logrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeSI.Visible = true;

            }
            else
            {
                //MessageBox.Show("No logrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mensajeNO.Visible = true;
            }
        }
    }
}