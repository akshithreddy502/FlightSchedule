using System;
namespace FlightSchedule.Interfaces
{
	public interface IFlightRepository
	{
		List<Flight> GetFlights();
	}
}

