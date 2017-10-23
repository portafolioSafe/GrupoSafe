﻿using System;
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

            if (!IsPostBack)
            {
                BLL.TipoEvaluacionDTO t = new BLL.TipoEvaluacionDTO();


                foreach (var item in t.listadodealgo())
                {
                    ListItem item2 = new ListItem(item.Nombre, item.Id.ToString());
                    DropDownList1.Items.Add(item2);
                }



                GridView1.DataBind();
            }

        }



       



        protected void Button1_Click(object sender, EventArgs e)
        {

            string categoria = TextBox1.Text;
            int id = int.Parse(DropDownList1.SelectedItem.Value);
           

            BLL.CategoriaDTO cat = new BLL.CategoriaDTO();
            cat.AgregarCategoria(id,categoria);
            
            GridView1.DataBind();





        }
    }
}