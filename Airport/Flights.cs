using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Flights
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string City { get; set; }
        public string Country{ get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public int NumberOfSeats { get; set; }

    }
}
