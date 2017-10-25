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

        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }
        private int idPregunta;

        public int IdPregunta
        {
            get { return idPregunta; }
            set { idPregunta = value; }
        }
        private int idEvaluacion;

        public int IdEvaluacion
        {
            get { return idEvaluacion; }
            set { idEvaluacion = value; }
        }

        public DetallePreguntaDTO()
        {

        }

        public DetallePreguntaDTO(string respuesta, int idPregunta, int idEvaluacion)
        {
            this.Respuesta = respuesta;
            this.IdPregunta = idPregunta;
            this.IdEvaluacion = idEvaluacion;
        }

     

        public static bool AgregarDetalle(int idE, int idP, string p)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_agregarDetallePregunta(p,idP,idE);
        }

        public static List<ServiceReference1.Detalle_evaluacion> ListarDetalle(int evaluacion)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_listadoDetalle(evaluacion);
        }


    }
}
