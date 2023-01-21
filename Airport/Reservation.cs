using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int FlightId { get; set; }

        public Reservation()
        {
                
        }
        //public override string ToString()
        //{
        //    return "reservation:" + ReservationId;
        //}
    }
}
