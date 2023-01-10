using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.task9_homework
{
    public class Human
    {
        protected string _name;
        protected string _lastName;

        public Human() { }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public override string ToString() => _name;
    }
}
