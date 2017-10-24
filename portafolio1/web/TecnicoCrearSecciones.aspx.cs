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

            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string pregunta = TextBox1.Text;
            int id = int.Parse(DropDownList1.SelectedItem.Value);
            bool resp = BLL.PreguntasDTO.AgregarPregunta(id,pregunta);
            GridView1.DataBind();
            if (resp)
            {

                MessageBox.Show("Pregunta Guardada con exito", "Preguntas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar", "Preguntas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}