using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;




namespace BLL
{
    public class MedicoDTO
    {

      private string rut_medico;

        public string name { get; set; }
        public string degree { get; set; }
        public string univ { get; set; }
        public string spec { get; set; }

        public string Rut_medico
        {
            get { return rut_medico; }
            set { rut_medico = value; }
        }

   
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string especialidad;

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public MedicoDTO() { }




        public static bool guardaelMedico(string rut, string nombre, string apellido, string especialidad, string correo, string pass)
        {
            ServiceReference1.wsa1SoapClient meme = new ServiceReference1.wsa1SoapClient();
            return meme.M_guardarMedico(rut, nombre, apellido, especialidad, correo, pass);

        }

        public static void envioCorreo(string correo,string nombre, string apellido) {

            //MailMessage mail = new MailMessage("safesystemduoc@gmail.com", correo);
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new System.Net.NetworkCredential("safesystemduoc", "safeportafolio");
            //client.EnableSsl = true;
           
            //client.Host = "smtp.google.com";
            //mail.Subject = "Bienvenido a SAFE";
            //mail.Body = "Estimado/a "+nombre+" "+apellido+". Junto con saludarle, en nombre del equipo de SAFE, queremos darle la bienvenida. PD:no responda a este correo ";
            //client.Send(mail);


        
                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //mail.From = new MailAddress("safesystemduoc@gmail.com");
                //mail.To.Add("cfhidalgo.rain@gmail.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";

                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("safesystemduoc@gmail.com", "safeportafolio");
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);

                var fromAddress = new MailAddress("safesystemduoc@gmail.com", "SAFE");
                var toAddress = new MailAddress(correo, "Nuevo médico");
                const string fromPassword = "safeportafolio";

            //constant por si falla
                 string subject = "Bienvenido a SAFE, "+nombre+".";
                 string body = "Estimado/a " + nombre + " " + apellido + ". Junto con saludarle, en nombre del equipo de SAFE, queremos darle la bienvenida. PD:no responda a este correo.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

               
       
        }
    }
    
 


}
