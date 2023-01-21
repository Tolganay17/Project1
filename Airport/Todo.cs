using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public  class Todo
    {
        public List<Flights> res { get; set; } = new List<Flights>();
        public List<Passengers> pass { get; set; } = new List<Passengers>();
        

        public Todo( List<Passengers> pass, List<Flights> res)
        {
            this.pass = pass;
            this.res = res;
           
        }
    }
}
