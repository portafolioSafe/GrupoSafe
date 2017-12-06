using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class capacitacionDTO
    {

        private int id;
        private string area;
        private string fecha;
        private string tema;
        private string expositor;
        private int asistencia;
        private string rut_empresa;
        private string tipo_cap;


         public capacitacionDTO() { 
        
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string Tema
        {
            get { return tema; }
            set { tema = value; }
        }
        public string Expositor
        {
            get { return expositor; }
            set { expositor = value; }
        }
        public int Asistencia
        {
            get { return asistencia; }
            set { asistencia = value; }
        }
        public string Rut_empresa
        {
            get { return rut_empresa; }
            set { rut_empresa = value; }
        }
        public string Tipo_cap
        {
            get { return tipo_cap; }
            set { tipo_cap = value; }
        }




        ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();

        public List<ServiceReference1.capacitacion> listarCapacitacion()
        {
            ServiceReference1.capacitacion cat = new ServiceReference1.capacitacion();
            return ws.ListarCapacitaciones();
        }

        public capacitacionDTO showCapacitacion(int id_cap)
        {


            ServiceReference1.capacitacion cap = ws.ShowCapacitacion(id_cap);
            this.Area = cap.Area;
            this.Asistencia = cap.Asistencia;
            this.Expositor = cap.Expositor;
            this.Fecha = cap.Fecha;
            this.Id = cap.Id;
            this.Rut_empresa = cap.Rut_empresa;
            this.Tema = cap.Tema;
            this.Tipo_cap = cap.Tipo_cap;


            return this;


        }

        public List<ServiceReference1.cap_tipo> listarTipoCapacitacion()
        {
            ServiceReference1.cap_tipo cat = new ServiceReference1.cap_tipo();
            return ws.GetListarTipoCap();
        }


        //public string toCapital(string cadena)
        //{


        //    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        //    return textInfo.ToTitleCase(cadena);
        //}

        public bool editarCapacitacion(int id_edit, string area, DateTime fecha, string tema, string expo, int asisten, string empresa, int tipocap)
        {
            if (ws.editarCApacitacion(id_edit, area, fecha, tema, expo, asisten, empresa, tipocap))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public List<ServiceReference1.capacitacion> ListarCapacitacionxFecha(string nombreEmpresa){

            return ws.ListarCapacitacionesxfecha(nombreEmpresa);

        }
        public List<ServiceReference1.capacitacion> ListarCapacitacionxEmpresa(string nombreEmpresa)
        {

            return ws.ListarCapacitacionesxempresa(nombreEmpresa);

        }
        public List<ServiceReference1.capacitacion> ListarCapacitacionxaño(string nombreEmpresa, int year)
        {

            return ws.ListadoCapacitacionXaño(nombreEmpresa,year);

        }


        public string asistirCap(int id_cap, string rut)
        {
            return ws.AsistirCapcitacion(id_cap, rut);
        }
        
        public List<ServiceReference1.detalle_cap> listarDetalleCapxUsuario(string nombre)
        {

            return ws.listarDetalleCapxUsuario(nombre);

        }


        public static List<ServiceReference1.detalle_cap> listarDetalleCapxUsuario2()
        {
            ServiceReference1.wsa1SoapClient ws = new ServiceReference1.wsa1SoapClient();
            return ws.listarDetalleCap();

        }


    }


}
