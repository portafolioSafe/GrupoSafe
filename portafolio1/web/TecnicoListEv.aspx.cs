using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace web
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Tecnico")
            {
                Response.Redirect("Home.aspx");
            }
            string rut = Session["Rut"].ToString();
        }


        //public DataTable GetData()
        //{
        //    DataTable dt = new DataTable();


        //    dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Pregunta") });



        //}


    }
}