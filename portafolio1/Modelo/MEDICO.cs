//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEDICO
    {
        public MEDICO()
        {
            this.ATENCION_MEDICA = new HashSet<ATENCION_MEDICA>();
        }
    
        public string RUT_MEDICO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string ESPECIALIDAD { get; set; }
    
        public virtual ICollection<ATENCION_MEDICA> ATENCION_MEDICA { get; set; }
    }
}
