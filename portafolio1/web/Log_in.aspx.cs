﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace web
{
    public partial class Log_in : System.Web.UI.Page
    {
        string pw = "";

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
            error.Visible = false;
            error1.Visible = false;
            error2.Visible = false;
            errorserver.Visible = false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

         

            ServiceReference1.wsa1SoapClient wf = new ServiceReference1.wsa1SoapClient();
            BLL.loginController memito = new BLL.loginController();

            string radiob = "";
            string tipo = "";
            pw= validarRut(user.Value).ToString();
            string passsha1 = BLL.loginController.Hash(pass.Value);
            try
            {
                string nombre = "";
                if (Request.Form["login"] != null)
                {
                    radiob = Request.Form["login"].ToString();
                }

                switch (radiob)
	            {
                    case "Usuario":
                             nombre = memito.validaUsuario(pw, passsha1);
                            break;
                    case "Empresa":
                          nombre = memito.validaEmpresa(pw, passsha1);
                        break;
                    case "Medico":
                        nombre = memito.validaMedico(pw, passsha1);
                        break;
		            default:
                        error1.Visible=true;
                    break;
	            }

                

                    tipo = memito.devuelveTipo(pw, radiob);
                    if (tipo.Equals("nope"))
                    {
                       // Response.Redirect("Log_in.aspx");
                        error2.Visible = true;
                       
                    
                   }
                    else if (tipo.Equals("tipo_nulo"))
                    {
                        // Response.Redirect("Log_in.aspx");
                        errorserver.Visible = true;

                    }
                    else if (nombre.Equals("server") || tipo.Equals("server"))
                    {
                        error.Visible = true;

                        //MessageBox.Show("Usuario: " + pw + ", pass: " + pass.Value + ", tipo: " + radiob + "", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (nombre.Equals("nulo"))
                    {
                        error.Visible = true;

                        //MessageBox.Show("Usuario: " + pw + ", pass: " + pass.Value + ", tipo: " + radiob + "", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (nombre == "malo")
                    {
                        error1.Visible = true;
                        //Response.Redirect("Log_in.aspx");
                        //MessageBox.Show("Usuario: " + pw + ", pass: " + pass.Value + ", tipo: " + radiob + "", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (nombre!="nulo" ||nombre!="malo" || tipo!="nope")
                    {
                        Session["login"] = nombre;
                        Session["tipo"] = tipo;
                        Session["Rut"] = pw;
                        if (tipo=="Trabajador")
                        {
                            Session["NombreEmpresa"] =  BLL.loginController.devuelveNombreEmpresa(pw);
                        }
                        BLL.MedicoDTO.envioCorreo("cfhidalgo.rain@gmail.com", "Cesar", "Hidalgo");
                        FormsAuthentication.RedirectFromLoginPage(user.Value, false);
                    }
                  
                

                
            }
            catch (Exception) 
            {
                error.Visible = true;
                //MessageBox.Show("Usuario: "+ pw +", pass: "+pass.Value+", tipo: "+radiob+"", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

      

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        
    }
}