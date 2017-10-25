using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpresaDTO
    {

        private string rut;

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private int telefono;

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string contra;

        public string Contra
        {
            get { return contra; }
            set { contra = value; }
        }

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

     


        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.empresa> ListadoEmpresas()
        {
            return ws.E_listarempresa();
        }


    }
}
