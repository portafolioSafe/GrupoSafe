using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetallePreguntaDTO
    {
        private string respuesta;
        private int idPregunta;
        private int idEvaluacion;

        public DetallePreguntaDTO()
        {

        }

        public DetallePreguntaDTO(string respuesta, int idPregunta, int idEvaluacion)
        {
            this.Respuesta = respuesta;
            this.IdPregunta = idPregunta;
            this.IdEvaluacion = idEvaluacion;
        }

        public string Respuesta { get => respuesta; set => respuesta = value; }
        public int IdPregunta { get => idPregunta; set => idPregunta = value; }
        public int IdEvaluacion { get => idEvaluacion; set => idEvaluacion = value; }



        public static bool AgregarDetalle(int idE, int idP, string p)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_agregarDetallePregunta(p,idP,idE);
        }


    }
}
