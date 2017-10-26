using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicoDTO
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        private string univ;

        public string Univ
        {
            get { return univ; }
            set { univ = value; }
        }
        private string spec;

        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        public MedicoDTO()
        {
        }

    }
}
