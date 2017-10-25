using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PreguntasDTO
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pregunta;

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int id_cat;

        public int Id_cat
        {
            get { return id_cat; }
            set { id_cat = value; }
        }

        public PreguntasDTO(int id, string pregunta, string estado, int id_cat)
        {
            this.Id = id;
            this.Pregunta = pregunta;
            this.Estado = estado;
            this.Id_cat = id_cat;
        }
        public PreguntasDTO()
        {

        }
  
      
        public static bool AgregarPregunta(int id, string pregunta)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();


            if (ws.E_agregarPregunta(id,pregunta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public  List<ServiceReference1.Pregunta> lisatopreguntas(int id)
        {
            
            return ws.E_listarPreguntaXcategoria(id);
        }

        public static List<ServiceReference1.Pregunta> ListarXcategoria(int id)
        {
           ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_listarPreguntaXcategoria(id);
        }


    }
}
