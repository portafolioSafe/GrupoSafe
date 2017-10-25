using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EvaluacionDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string obstec;

        public string Obstec
        {
            get { return obstec; }
            set { obstec = value; }
        }
        private string obsing;

        public string Obsing
        {
            get { return obsing; }
            set { obsing = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int id_tipo;

        public int Id_tipo
        {
            get { return id_tipo; }
            set { id_tipo = value; }
        }
        private int id_empresa;

        public int Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }
        private int id_usuario;

        public int Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public EvaluacionDTO()
        {

        }

        public EvaluacionDTO(int id, DateTime fecha, string obstec, string obsing, string estado, int id_tipo, int id_empresa, int id_usuario)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Obstec = obstec;
            this.Obsing = obsing;
            this.Estado = estado;
            this.Id_tipo = id_tipo;
            this.Id_empresa = id_empresa;
            this.Id_usuario = id_usuario;
        }



        public static List<ServiceReference1.Evaluacion> ultimaEvaluacionXtecnico(string rut)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.listadoUltimaEvaluacion(rut);
        }

        public static bool AgregarEvaluacion(string empresa, int tipo, string rut, DateTime fecha, string obsT, string recI, string estado)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_agregarEvaluacion(fecha,obsT,recI, estado,tipo,empresa,rut);
        }

        public static List<ServiceReference1.Evaluacion> ListarEvaluacionTecnico(string rut)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.E_listadoPorTecnico(rut);
        }

    }
}
