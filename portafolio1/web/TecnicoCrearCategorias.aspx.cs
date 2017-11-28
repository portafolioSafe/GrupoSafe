using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class TecnicoCrearCategorias : System.Web.UI.Page
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
            mensajeEX.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;

            GridView1.DataBind();



            if (!IsPostBack)
            {
                
                BLL.TipoEvaluacionDTO t = new BLL.TipoEvaluacionDTO();


                foreach (var item in t.listadodeEvaluaciones())
                {
                    ListItem item2 = new ListItem(item.Nombre, item.Id.ToString());
                    DropDownList2.Items.Add(item2);
                }

                

                GridView1.DataBind();
            }

        }



       



        protected void Button1_Click(object sender, EventArgs e)
        {

            BLL.CategoriaDTO cat = new BLL.CategoriaDTO();
         

            string categoria = TextBox1.Text;
            
            if (int.Parse(DropDownList2.SelectedItem.Value) !=0 )
            {
                int id = int.Parse(DropDownList2.SelectedItem.Value);
                if (categoria != "")
                {
                    foreach (var item in BLL.CategoriaDTO.listarCategoria())
                    {

                        if (categoria.ToLower() == item.Nombre.ToLower())
                        {
                           
                            mensajeEX.Visible = true;
                            categoria = "ya existe";
                            break;
                        }
                        
                        
                       
                    }
                    if (!categoria.Equals("ya existe"))
                    {
                        try
                        {
                            cat.AgregarCategoria(id, categoria);
                            GridView1.DataBind();
                            

                            mensajeSI.Visible = true;
                            TextBox1.Text = " ";
                        }
                        catch (Exception)
                        {
                            mensajeNO.Visible = true;
                            GridView1.DataBind();
                        }
                    }
                    
                }
                else
                {
                    mensajeNa.Visible = true;
                    GridView1.DataBind();

                }
            }
            else
            {
                mensajeNO.Visible = true;
                GridView1.DataBind();

            }





            GridView1.DataBind();





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
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                GridView1.DataBind();
                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[0];
                TableCell contact2 = selectedRow.Cells[1];
                string contact = contactName.Text;
                TextBox1.Text = contact2.Text;
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
            string estado = "Activo";


            if (TextBox1.Text != "")
            {
                if (BLL.CategoriaDTO.ModificarCategoria(idcat, nuevapregunta, estado))
                {
                    TextBox1.Text = "";
                    mensajeSiM.Visible = true;
                    Button1.Visible = true;
                    Button2.Visible = false;
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
            Response.Redirect("TecnicoCrearCategorias.aspx");
        }
    }
}