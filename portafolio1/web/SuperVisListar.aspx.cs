﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Formulario_web121 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (Session["tipo"].ToString() != "Supervisor")
            {
                Response.Redirect("Home.aspx");
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
                Session["id_visita"] = contact;
                //Pasa a la pagina de modificacion
                Response.Redirect("SuperVisEdit.aspx");
            }
        }
        }
    }
