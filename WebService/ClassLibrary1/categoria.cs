using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class categoria
    {
        private int id;
        private string nombre;
        private string estado;
        private int idTipo;

        public int IdTipo
        {
            get { return idTipo; }
            set { idTipo = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }





        public categoria()
        {

        }
        public categoria(int id, string nombre, string estado, int idTipo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = estado;
            this.IdTipo = idTipo;
        }
    }
}
