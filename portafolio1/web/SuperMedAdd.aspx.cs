using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
//using System.Net.Http.Formatting;
using System.Diagnostics;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace web
{
    public partial class Formulario_web119 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            using (var client = new HttpClient())
            {

                // Establecer la url que proporciona acceso al servidor que publica la API 
                client.BaseAddress = new Uri("http://rsd.webdevel.cl/");

                // Configurar encabezados para que la petición de realice en formato JSON
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Realizar la petición GET
                HttpResponseMessage response = client.GetAsync("http://xsknet.dyndns.org:8080/doctor?rut=" + txtRut.Text).Result;
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                         // Obtener el resultado como objeto dynamic 
                        //var result = response.Content.ReadAsAsync<BLL.MedicoDTO>().Result;
                        //error.Text = "";
                        //nombre.Text = "Nombre: ";
                        //titulo.Text = "Título/Habilitante Legal: ";
                        //institucion.Text = "Institución Habilitante: ";
                        //especialidad.Text = "Especialidad: ";
                        //MessageBox.Show("Rut asociado, nombre: "+result.Name+"", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
                        //txtNombre.Enabled = true;
                        //txtNombre.Text = result.Name;

                        txtApellido.Enabled = true;
                        txtCorreo.Enabled = true;
                        txtPass.Enabled = true;
                        txtPassconfirm.Enabled = true;
                        txtEspecialidad.Enabled = true;
                        

                        //txtEspecialidad.Text = result.Spec;
                       


                        //Console.WriteLine("ReturnCode: {0}", result.Returncode);
                        //Console.WriteLine("Message: {0}", result.Message);
                        //Console.WriteLine("Token: {0}", result.Token);
                    }
                    else
                    {
                        MessageBox.Show("Rut no asociado a la escula de médicos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //Debug.WriteLine("Rut no asociado a un médico");
                        //error.Text = "Rut no asociado a un médico";
                        //nombre.Text = "";
                        //titulo.Text = "";
                        //institucion.Text = "";
                        //especialidad.Text = "";
                        //name.Text = "";
                        //degree.Text = "";
                        //univ.Text = "";
                        //spec.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Token: {0}", ex.Message);
                }


            }

            /*

            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString("http://xsknet.dyndns.org:8080/doctor?rut="+ rut.Text);
                    var serializer = new JavaScriptSerializer();
                    Debug.WriteLine(json);
                    Doctor doc = serializer.Deserialize<Doctor>(json);
                    // TODO: do something with the model

                    Debug.WriteLine(doc.name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Token: {0}", ex.Message);
                }
            }

    */
        }
    }
}