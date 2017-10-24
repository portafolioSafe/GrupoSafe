using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpresaDTO
    {

<<<<<<< HEAD
        private string rut_empresa;

        public string Rut_empresa
        {
            get { return rut_empresa; }
            set { rut_empresa = value; }
        }
        private string nombre_empresa;

        public string Nombre_empresa
        {
            get { return nombre_empresa; }
            set { nombre_empresa = value; }
        }

            
          ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
           
          public List<ServiceReference1.empresa> GetlistarEmpresaList()
        {
            ServiceReference1.empresa cat = new ServiceReference1.empresa();
            return ws.GetlistarEmpresaList();
        } 
        
        public EmpresaDTO()
        { 
        
        
        }



=======
        private string rut;
        private string nombre;
        private string direccion;
        private int telefono;
        private string correo;
        private string estado;
        private string contra;

        public EmpresaDTO(string rut, string nombre, string direccion, int telefono, string correo, string estado, string contra)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Estado = estado;
            this.Contra = contra;
        }

        public EmpresaDTO()
        {

        }

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Contra { get => contra; set => contra = value; }


        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.empresa> ListadoEmpresas()
        {
            return ws.E_listarempresa();
        }


>>>>>>> 2dad8eb95b93d2065ade786ba24866566c0ffe6d
    }
}
