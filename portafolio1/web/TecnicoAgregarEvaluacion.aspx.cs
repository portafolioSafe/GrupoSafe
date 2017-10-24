using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class TecnicoAgregarEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BLL.TipoEvaluacionDTO t = new BLL.TipoEvaluacionDTO();

                //foreach (var item in t.listadodeEvaluaciones())
                //{
                //    ListItem item2 = new ListItem(item.Nombre,item.Id.ToString());
                //    DropDownList2.Items.Add(item2);
                //}


             
            }


         
        }


        protected void rb_Yes_Click(object sender, EventArgs e)
        {
            RadioButton rb_Yes = (RadioButton)sender;
            GridViewRow grid_row = (GridViewRow)rb_Yes.NamingContainer;
            if (((RadioButton)grid_row.FindControl("rb_Yes")).Checked == true)
            {
              //  System.Windows.Forms.MessageBox.Show("Pregunta Guardada con exito" + grid_row.Cells[1].Text, "escogio si", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                
            }
        }

        protected void rb_No_Click(object sender, EventArgs e)
        {
            RadioButton rb_No = (RadioButton)sender;
            GridViewRow grid_row = (GridViewRow)rb_No.NamingContainer;
            if (((RadioButton)grid_row.FindControl("rb_No")).Checked == true)
            {
                System.Windows.Forms.MessageBox.Show("Pregunta Guardada con exito" + grid_row.Cells[1].Text, "escogio no", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
        }

        public DataTable GetData(int idtipo)
        {
            DataTable dt = new DataTable();


           dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Pregunta") });


            foreach (var item in BLL.CategoriaDTO.ListarXtipo(idtipo))
            {
                foreach (var item2 in BLL.PreguntasDTO.ListarXcategoria(item.Id))
                {
                    dt.Rows.Add(item2.Id,item2.Pregunta1);
                }
            }


            return dt;
        }









        protected void Button1_Click(object sender, EventArgs e)
        {




        }
    }
}