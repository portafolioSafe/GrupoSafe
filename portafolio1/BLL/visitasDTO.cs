using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class visitasDTO
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string lugar;

        public string Lugar
        {
            get { return lugar; }
            set { lugar = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private string rut_empresa;

        public string Rut_empresa
        {
            get { return rut_empresa; }
            set { rut_empresa = value; }
        }
        private int tipo_examen;



        public int Tipo_examen
        {
            get { return tipo_examen; }
            set { tipo_examen = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


     

        public  bool GuardarVisita(string lugar, DateTime fecha, DateTime hora, string empresa, int tipoexamen)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.GuardarVisita(lugar,fecha,hora,empresa,tipoexamen);
        
        }

        public List<ServiceReference1.visitasMedicas> listarVisitas(){
        
             ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
             return ws.listarVisitas();

        }

        public string asistirCap(int id_vis, string rut)
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.AsignarMedico(id_vis,rut);
        }

    }
}
