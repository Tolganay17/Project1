using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Passengers
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Passengers()
        {

        }
        
        public List<Reservation> reservation { get; set; } = new List<Reservation>();
        public override string ToString()
        {
            return "name:" + FirstName;
        }
    }
}
