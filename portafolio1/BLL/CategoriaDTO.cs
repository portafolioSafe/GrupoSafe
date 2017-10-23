using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaDTO
    {

        private int id_cat;

        public int Id_cat
        {
            get { return id_cat; }
            set { id_cat = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }





        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public CategoriaDTO(int id_cat, string nombre, string estado, int id)
        {
            this.Id_cat = id_cat;
            this.Nombre = nombre;
            this.Estado = estado;
            this.Id = id;
        }

        public CategoriaDTO()
        {

        }

    

        public List<ServiceReference1.categoria> listarCategoria()
        {
            ServiceReference1.categoria cat = new ServiceReference1.categoria();
            return ws.E_listadoCategoria();
        }

        public bool AgregarCategoria(int id, string nombre)
        {
            return ws.E_guardarCategoria(nombre, id);
        }





    }
}
