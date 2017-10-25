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
        string rut = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Tecnico")
            {
                Response.Redirect("Home.aspx");
            }
           rut = Session["Rut"].ToString();

            if (!IsPostBack)
            {
                GridView1.DataSource = GetData();
                GridView1.DataBind();

            }
        }


        public DataTable GetData()
        {
            DataTable dt = new DataTable();


            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("Empresa"), new DataColumn("Fecha"), new DataColumn("TipoEvaluacion") });

            foreach (var item in BLL.EvaluacionDTO.ListarEvaluacionTecnico(rut))
            {

                    string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);

                    dt.Rows.Add(item.Id, nombre, item.Fecha.ToString().Substring(0,11) ,nombreE);
                
            }

            return dt;

        }


    }
}