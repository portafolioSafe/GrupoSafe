using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Formulario_web115 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Ingeniero")
            {
                Response.Redirect("Home.aspx");
            }


            if (!IsPostBack)
            {
                GridView1.DataSource = GetData();
                GridView1.DataBind();

            }



        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Select")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                string contact = contactName.Text;

                // Captura el id de la capacitacion mostrada en la tabla en una variable de sesion
                Session["Id_evaluacion"] = contact;
                //Pasa a la pagina de modificacion
                //  Response.Redirect("SupercapEdit.aspx");
                Response.Redirect("IngenieroInfoAdd.aspx");
                //MessageBox.Show(contact, "asdasd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public DataTable GetData()
        {
            DataTable dt = new DataTable();


            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"), new DataColumn("Empresa"), new DataColumn("Fecha"), new DataColumn("TipoEvaluacion"), new DataColumn("Estado") });


            foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
            {

                string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                if (item.Estado.Equals("Enviado"))
                {
                    dt.Rows.Add(item.Id, nombre, item.Fecha.ToString().Substring(0, 11), nombreE, item.Estado);

                }

            }
            return dt;

        }
    }
}