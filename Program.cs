using FlightSchedule;
using FlightSchedule.Controllers;
using FlightSchedule.Interfaces;
using FlightSchedule.Repositories;
using FlightSchedule.Service;

var flights = new List<Flight>
        {
            new Flight { FlightNumber = 1, Arrival = "YYZ", Day = 1 },
            new Flight { FlightNumber = 2, Arrival = "YYC", Day = 1 },
            new Flight { FlightNumber = 3, Arrival = "YVR", Day = 1 },
            new Flight { FlightNumber = 4, Arrival = "YYZ", Day = 2 },
            new Flight { FlightNumber = 5, Arrival = "YYC", Day = 2 },
            new Flight { FlightNumber = 6, Arrival = "YVR", Day = 2 }
        };

var flightRepository = new FlightRepository(flights);
var orderRepository = new OrderRepository();
var flightService = new FlightService(flightRepository, orderRepository);
var scheduler = new FlightScheduleController(flightRepository, flightService);

Console.WriteLine("Flight Schedule:");
scheduler.DisplayFlightSchedule();

string ordersFilePath = "flights.json";
Console.WriteLine("Load Orders:");
scheduler.ProcessFlightOrders(ordersFilePath);
