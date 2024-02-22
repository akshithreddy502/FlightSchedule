using System;
using System.Text.Json;
using FlightSchedule.Interfaces;

namespace FlightSchedule.Repositories
{
	public class OrderRepository :IOrderRepository
	{
        public Dictionary<string, string> LoadOrders(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);

                var orderDestinations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonString)
                                  .ToDictionary(x => x.Key, x => x.Value["destination"]);

                return orderDestinations;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error: File not found - {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return new Dictionary<string, string>();

        }
    }
}

