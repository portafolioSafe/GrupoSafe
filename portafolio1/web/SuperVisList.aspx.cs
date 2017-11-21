using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Text;

namespace web
{
    public partial class Formulario_web120 : System.Web.UI.Page
    {

        int id = 0;
        DataTable pdf = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Supervisor")
            {
                Response.Redirect("Home.aspx");
            }



            id = int.Parse(Session["Id_evaluacion"].ToString());
            mensajeSI.Visible = false;
            if (!IsPostBack)
            {
                foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
                {


                    if (item.Id == id)
                    {
                        string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                        string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                        Empresa.Text = nombre;
                        lbl_Rut.Text = item.Id_empresa;
                        lbl_tipo.Text = nombreE;
                        lblfecha.Text = item.Fecha.ToString().Substring(0, 11);
                       
                        GridView1.DataSource = GetData(item.Id_tipo, item.Id);
                        GridView1.DataBind();
                        TextBox1.Text = item.Obstec;
                        TextBox2.Text = item.Obsing;

                    }





                }

            }



        }

        public DataTable GetData(int id, int idE)
        {
            DataTable dt = new DataTable();


            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Pregunta"), new DataColumn("Respuesta") });

            foreach (var item in BLL.DetallePreguntaDTO.ListarDetalle(idE))
            {


                foreach (var item2 in BLL.CategoriaDTO.ListarXtipo(id))
                {
                    foreach (var item3 in BLL.PreguntasDTO.ListarXcategoria(item2.Id))
                    {

                        if (item.Id_pregunta == item3.Id)
                        {
                            dt.Rows.Add(item.Id_pregunta, item3.Pregunta1, item.Pregunta);
                            // pdf.Rows.Add(item.Id_pregunta, item3.Pregunta1, item.Pregunta);
                            pdf.Merge(dt);

                        }
                    }
                }



                // dt.Rows.Add(item.Id_pregunta,);

            }

            return dt;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Pregunta"), new DataColumn("Respuesta") });
            
          

            foreach (var item in BLL.EvaluacionDTO.ListarTodoIng())
            {

                if (item.Id == id)
                {
                    string nombre = BLL.EmpresaDTO.NombreEpresa(item.Id_empresa);
                    string nombreE = BLL.TipoEvaluacionDTO.nombreEvaluaciones(item.Id_tipo);
                    Empresa.Text = nombre;
                    lbl_Rut.Text = item.Id_empresa;
                    lbl_tipo.Text = nombreE;
                    lblfecha.Text = item.Fecha.ToString().Substring(0, 11);

                    dt.Merge(GetData(item.Id_tipo, item.Id));
                    TextBox1.Text = item.Obstec;
                    TextBox2.Text = item.Obsing;

                }

            }

            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));



           // System.IO.FileStream fs = new FileStream("C:\\Users\\oscar\\Downloads", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk("dsdsd".ToUpper()));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Author : Dotnet Mob", fntAuthor));
            prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString()));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n"));

            //Write the table
            PdfPTable table = new PdfPTable(dt.Columns.Count);
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
            Response.ContentType = "application/pdf";

            document.Add(table);
            Response.Write(document);
            document.Close();
            writer.Close();
            // fs.Close();
          //  Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + Empresa.Text + ".pdf");

            Response.End();

            //DataTable dtbl = dt;
            //ExportDataTableToPdf(dtbl, @"E:\test.pdf", "Friend List");
          

            //using (StringWriter sw = new StringWriter())
            //{
            //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //    {
            //        StringBuilder sb = new StringBuilder();

            //        //Generate Invoice (Bill) Header.
            //        sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            //        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
            //        sb.Append("<tr><td colspan = '2'></td></tr>");
            //        sb.Append("<tr><td><b>Order No: </b>");
            //        sb.Append(Empresa.Text);
            //        sb.Append("</td><td align = 'right'><b>Date: </b>");
            //        string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
            //        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C:\\GrupoSafe\\portafolio1\\web\\NewFolder1\\Logo_SAFE.png");
            //        image.ScalePercent(40f);

            //        sb.Append(" </td></tr>");
            //        sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
            //        sb.Append(lbl_tipo.Text);
            //        sb.Append("</td></tr>");
            //        sb.Append("</table>");
            //        sb.Append("<br />");

            //        //Generate Invoice (Bill) Items Grid.
            //        sb.Append("<table border = '1'>");
            //        sb.Append("<tr>");

            //        foreach (DataColumn column in dt.Columns )
            //        {
            //            sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff;width:1px;white-space:nowrap; table-layout:fixed;' >");
            //            sb.Append(column.ColumnName);
            //            sb.Append("</th>");
            //        }
            //        sb.Append("</tr>");
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            sb.Append("<tr>");

            //            foreach (DataColumn column in dt.Columns)
            //            {
            //                sb.Append("<td>");

            //                sb.Append(row[column]);
            //                sb.Append("</td>");
            //            }
            //            sb.Append("</tr>");
            //        }
            //        sb.Append("<tr><td align = 'right' colspan = '");
            //        sb.Append(dt.Columns.Count - 1);
            //        sb.Append("'>Total</td>");
            //        sb.Append("<td>");
            //        //sb.Append(pdf.Compute("sum(Total)", ""));
            //        sb.Append("</td>");
            //        sb.Append("</tr></table>");

            //        //Export HTML String as PDF.
            //        StringReader sr = new StringReader(sb.ToString());
            //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //        pdfDoc.Open();
            //        pdfDoc.Add(image);
            //        htmlparser.Parse(sr);
            //        pdfDoc.Close();
            //        Response.ContentType = "application/pdf";
            //        Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + Empresa.Text + ".pdf");
            //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //        Response.Write(pdfDoc);
            //        Response.End();
            //    }
            //}




            // Response.Redirect("SupervListIn.aspx");


        }
    }
}