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
            mensajeSiM.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            DropDownList3.Visible = false;
            Button1.Visible = true;
            GridView1.DataBind();

            if (!IsPostBack)
            {

                BLL.CategoriaDTO t = new BLL.CategoriaDTO();


                foreach (var item in t.listarCategoriaD())
                {
                    ListItem item2 = new ListItem(item.Nombre, item.Id.ToString());
                    //DropDownList2.Items.Add(item2);
                    DropDownList1.Items.Add(item2);
                }



                GridView1.DataBind();
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string pregunta = TextBox1.Text;

            if (int.Parse(DropDownList1.SelectedItem.Value) != 0)
            {
                int id = int.Parse(DropDownList1.SelectedItem.Value);
                if (pregunta != "")
                {
                    BLL.PreguntasDTO.AgregarPregunta(id, HttpUtility.HtmlEncode(pregunta));
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Select")
            {
                Button1.Visible = false;
                Button2.Visible = true;
                Button3.Visible = true;
                DropDownList3.Visible = true;
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                TableCell contact2 = selectedRow.Cells[1];
                string contact = contactName.Text;
                TextBox1.Text = HttpUtility.HtmlDecode(contact2.Text);
                // Captura el id de la capacitacion mostrada en la tabla en una variable de sesion
                Session["idCategoria"] = contact;
                //Pasa a la pagina de modificacion
                // Response.Redirect("TecnicoCrearCategorias.aspx");
                //Response.Redirect("TecnicoDetalleEvaluacion.aspx");
                //MessageBox.Show(contact, "asdasd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int idcat = int.Parse(Session["idCategoria"].ToString());
            string nuevapregunta = TextBox1.Text;
            string estado = DropDownList3.SelectedItem.Text;
            if (TextBox1.Text != "")
            {
                if (BLL.PreguntasDTO.ModificarPregunta(idcat, nuevapregunta, estado))
                {

                    TextBox1.Text = "";
                    mensajeSiM.Visible = true;
                    Button1.Visible = true;
                    Button2.Visible = false;
                    Button3.Visible = false;
                    DropDownList3.Visible = false;
                    GridView1.DataBind();
                }
            }
            else
            {
                Button2.Visible = true;
                Button3.Visible = true;
                mensajeNa.Visible = true;
            }
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("TecnicoCrearSecciones.aspx");
        }
    }
}