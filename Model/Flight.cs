using System;
namespace FlightSchedule
{
	public class Flight
	{
        public int FlightNumber { get; set; }
        public string Departure { get; set; } = "YUL";
        public string Arrival { get; set; }
        public int Day { get; set; }
        public List<Order> Orders { get; } = new List<Order>();      
    }
}

