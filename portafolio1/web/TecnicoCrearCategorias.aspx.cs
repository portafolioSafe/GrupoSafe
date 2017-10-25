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

                    }
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
    }
}