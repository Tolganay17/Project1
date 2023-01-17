using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task12_homework
{
    public class Person
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
        public DateTime Date { get; set; }
        public List<Car> car { get; set; } = new List<Car>();
    }
}
