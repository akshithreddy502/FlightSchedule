using System;
using FlightSchedule.Interfaces;

namespace FlightSchedule.Repositories
{
	public class FlightRepository:IFlightRepository
	{
        private List<Flight> _flights;

        public FlightRepository(List<Flight> flights)
        {
            this._flights = flights;
        }

        public List<Flight> GetFlights()
        {
            return _flights;
        }
    }
}

