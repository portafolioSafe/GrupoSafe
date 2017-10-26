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

        public int validarRut(string rut)
        {


            rut = rut.ToUpper();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));


            return rutAux;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string rutfinal = validarRut(txtRut.Text).ToString();
            string passfinal = BLL.loginController.Hash(txtPassconfirm.Text);


            if (BLL.MedicoDTO.guardaelMedico(rutfinal,txtNombre.Text,txtApellido.Text,txtEspecialidad.Text,txtCorreo.Text, passfinal))
            {
                mensajeSI.Visible = true;
                mensajeNO.Visible = false;
                MensajeFound.Visible = false;
                MensajeNotFound.Visible = false;
                BLL.MedicoDTO.envioCorreo(txtCorreo.Text, txtNombre.Text, txtApellido.Text);
            }
            else
            {
                mensajeNO.Visible = true;

            }

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


                string rut = validarRut(txtRut.Text).ToString();
                HttpResponseMessage response = client.GetAsync("http://xsknet.dyndns.org:8080/doctor?rut=" + rut).Result;
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

                        txtRut.Enabled = false;
                        txtNombre.Enabled = true;
                       

                        txtRut.Enabled = false;
                        txtNombre.Enabled = true;
                       

                        txtApellido.Enabled = true;
                        txtCorreo.Enabled = true;
                        txtPass.Enabled = true;
                        txtPassconfirm.Enabled = true;
                        txtEspecialidad.Enabled = true;

                        

                        //txtEspecialidad.Text = result.Spec;
                       


                        //Console.WriteLine("ReturnCode: {0}", result.Returncode);
                        //Console.WriteLine("Message: {0}", result.Message);
                        //Console.WriteLine("Token: {0}", result.Token);

                        Button1.Enabled = true;
                        Button2.Enabled = false;
                        MensajeFound.Visible = true;
                        MensajeNotFound.Visible = false; 
   

                    }
                    else
                    {
                        MensajeNotFound.Visible = true;
      
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Token: {0}", ex.Message);
                }


            }

       
        }
    }
}