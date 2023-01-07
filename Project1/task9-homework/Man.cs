using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1.task9_homework
{
    public class Man : Human
    {
        public Man() { }

        public Man(string name, string lastname)
        {
            _name = name;
            _lastName = lastname;
        }
    }
}
