using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            var url = "http://localhost:52669/wsa1.asmx";

            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                   //Debug.Write(string.Format("{0} Disponible", url));
                }
                else
                {
                    Response.Redirect("Log_in.aspx");
                    //Debug.Write(string.Format("{0} Status: {1}", url, response.StatusDescription));
                }
            }
            catch (Exception ex)
            {
                Session["server"] = "malo";
                Response.Redirect("Log_in.aspx");
                
                // Debug.Write(string.Format("{0} No Disponible: {1}", url, ex.Message));
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            menuTecnico.Visible = false;
            menuTrabajador.Visible = false;
            menuIngeniero.Visible = false;
            menuSupervisor.Visible = false;
            menuMedico.Visible = false;
            menuCliente.Visible = false;
            try
            {



               

            string user = Session["login"].ToString();
            if (Session["login"]==null)
            {
                Response.Redirect("Log_in.aspx");
            }
            else { 
                 string rol = Session["tipo"].ToString();
                 switch (rol)
                 {
                     case "Tecnico":
                         menuTecnico.Visible = true;
                         break;
                     case "Trabajador":
                         menuTrabajador.Visible = true;
                         break;
                     case "Supervisor":
                         menuSupervisor.Visible = true;
                         break;
                     case "Médico":
                         menuMedico.Visible = true;
                         break;
                     case "Ingeniero":
                         menuIngeniero.Visible = true;
                         break;
                     case "Cliente":
                         menuCliente.Visible = true;
                         break;



                 }
                
            
            }


            Label1.Text = Session["tipo"].ToString();
            Label2.Text = Session["login"].ToString();
            }
            catch (Exception)
            {

                Response.Redirect("Log_in.aspx");
            }

        }



        protected void Cerrar_sesion(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["tipo"] = "";
            Response.Redirect("Log_in.aspx");
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["server"] = null;
        }
    }
}