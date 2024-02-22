using System;
using FlightSchedule.Interfaces;

namespace FlightSchedule.Service
{
    public class FlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IOrderRepository _orderRepository;

        public FlightService(IFlightRepository flightRepository, IOrderRepository orderRepository)
        {
            _flightRepository = flightRepository;
            _orderRepository = orderRepository;
        }

        public void AssignOrdersToFlights(string ordersFilePath)
        {
            try
            {
                var orderDestinations = _orderRepository.LoadOrders(ordersFilePath);
                var flights = _flightRepository.GetFlights();

                foreach (var orderDestination in orderDestinations)
                {
                    var order = new Order { OrderId = orderDestination.Key, Destination = orderDestination.Value };
                    var flight = flights.FirstOrDefault(x => x.Arrival == order.Destination && x.Orders.Count < 20);
                    if (flight != null)
                    {
                        flight.Orders.Add(order);
                        Console.WriteLine($"order: {order.OrderId}, flightNumber: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                    }
                    else
                    {
                        Console.WriteLine($"order: {order.OrderId}, flightNumber: not scheduled");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred during order processing: {e.Message}");
            }
        }

    }

}

