using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Formulario_web113 : System.Web.UI.Page
    {

        string rut = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Cliente")
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
                DescargarPDF(int.Parse(contact));
                //Pasa a la pagina de modificacion
                //  Response.Redirect("SupercapEdit.aspx");
                //Response.Redirect("SuperVisList.aspx");
                //MessageBox.Show(contact, "asdasd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public void DescargarPDF(int id)
        {
            DataTable dt = new DataTable();
            string nombreEm = "";
            string fecha = "";
            string obsTecnico = "";
            string obsingeniero = "";
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Item"), new DataColumn("Respuesta") });

            foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
            {

                if (item.Id == id)
                {
                    string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                    string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                    fecha = item.Fecha.ToString().Substring(0,11);
                    nombreEm = nombre;
                    obsTecnico = item.Obstec;
                    obsingeniero = item.Obsing;
                    dt.Merge(GetData2(item.Id_tipo, item.Id));
                   

                }

            }





           
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C:\\GrupoSafe\\portafolio1\\web\\NewFolder1\\Logo_SAFE.png");
            image.ScalePercent(40f);
            image.Alignment = Element.ALIGN_LEFT;
            document.Add(image);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(nombreEm.ToUpper()));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, BaseColor.GRAY);
          
            prgAuthor.Add(new Chunk("\nFecha de la evaluación : " + fecha));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            Paragraph pa = new Paragraph();
            pa.Alignment = Element.ALIGN_CENTER;
            pa.Add(new Chunk("Evaluación"));
            document.Add(pa);


            //Add line break
            document.Add(new Chunk("\n"));
            //Write the table
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.TotalWidth = 400f;
            float[] widths = new float[] {140f, 30f};
            table.SetWidths(widths);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                cell.AddElement(new Chunk(dt.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }


            document.Add(table);

            document.Add(p);

            Paragraph pa2 = new Paragraph();
            pa2.Alignment = Element.ALIGN_CENTER;
            pa2.Add(new Chunk("Observaciones del Técnico"));
            document.Add(pa2);

            Paragraph prfTecnico = new Paragraph();
            //prfTecnico.Alignment = Element.ALIGN_CENTER;
            prfTecnico.Alignment = Element.ALIGN_JUSTIFIED;
            prfTecnico.Add(new Chunk(obsTecnico));
            document.Add(prfTecnico);

            document.Add(p);

            Paragraph pa3 = new Paragraph();
            pa3.Alignment = Element.ALIGN_CENTER;
            pa3.Add(new Chunk("Recomendaciones del Ingeniero"));
            document.Add(pa3);

            Paragraph prfI = new Paragraph();
            //prfTecnico.Alignment = Element.ALIGN_CENTER;
            prfI.Alignment = Element.ALIGN_JUSTIFIED;
            prfI.Add(new Chunk(obsingeniero));
            document.Add(prfI);

            document.Add(p);

            document.Add(new Chunk("\n"));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("\n"));

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\GrupoSafe\\portafolio1\\web\\NewFolder1\\firma.png");
            imagen.ScalePercent(40f);
            imagen.Alignment = Element.ALIGN_RIGHT;
            document.Add(imagen);


            Response.ContentType = "application/pdf";

            Response.Write(document);
            document.Close();
            writer.Close();


             Response.AddHeader("content-disposition", "attachment;filename=Evaluacion empresa: " + nombreEm + ".pdf");
            Response.End();

        }

        public DataTable GetData2(int id, int idE)
        {
            DataTable dt = new DataTable();



            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Item"), new DataColumn("Respuesta") });







            foreach (var item in BLL.DetallePreguntaDTO.ListarDetalle(idE))
            {


                foreach (var item2 in BLL.CategoriaDTO.ListarXtipo(id))
                {
                    foreach (var item3 in BLL.PreguntasDTO.ListarXcategoria(item2.Id))
                    {

                        if (item.Id_pregunta == item3.Id)
                        {
                            dt.Rows.Add( item3.Pregunta1, item.Pregunta);
                            // pdf.Rows.Add(item.Id_pregunta, item3.Pregunta1, item.Pregunta);
                            //pdf.Merge(dt);

                        }
                    }
                }



                // dt.Rows.Add(item.Id_pregunta,);

            }

            return dt;

        }


        public DataTable GetData()
        {
            DataTable dt = new DataTable();


            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"), new DataColumn("Empresa"), new DataColumn("Fecha"), new DataColumn("TipoEvaluacion"), new DataColumn("Estado") });


            foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
            {

                string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                if (item.Estado.Equals("Revisado") && item.Id_empresa.Contains(rut))
                {
                    dt.Rows.Add(item.Id, nombre, item.Fecha.ToString().Substring(0, 11), nombreE, item.Estado);

                }

            }
            return dt;

        }

    }
}