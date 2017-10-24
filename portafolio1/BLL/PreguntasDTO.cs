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
        private string pregunta;
        private string estado;
        private int id_cat;

        public PreguntasDTO(int id, string pregunta, string estado, int id_cat)
        {
            this.Id = id;
            this.Pregunta = pregunta;
            this.Estado = estado;
            this.Id_cat = id_cat;
        }

        public int Id { get => id; set => id = value; }
        public string Pregunta { get => pregunta; set => pregunta = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Id_cat { get => id_cat; set => id_cat = value; }

      
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

        public static List<ServiceReference1.Pregunta> lisatopreguntas(int id)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_listarPreguntaXcategoria(id);
        }



    }
}
