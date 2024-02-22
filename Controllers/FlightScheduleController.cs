using System;
using FlightSchedule.Interfaces;
using FlightSchedule.Service;

namespace FlightSchedule.Controllers
{
	public class FlightScheduleController
	{
        private IFlightRepository _flightRepository;
        private readonly FlightService _flightService;

        public FlightScheduleController(IFlightRepository flightRepository,FlightService flightService)
        {
            this._flightRepository = flightRepository;
            this._flightService = flightService;
        }

        public void DisplayFlightSchedule()
        {
            try
            {
                var flights = _flightRepository.GetFlights();
                foreach (var flight in flights)
                {
                    Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying the flight schedule: {e.Message}");
            }
        }
        public void ProcessFlightOrders(string ordersFilePath)
        {
            try
            {
                _flightService.AssignOrdersToFlights(ordersFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while processing flight assignments: {e.Message}");
            }
        }
    }
}

