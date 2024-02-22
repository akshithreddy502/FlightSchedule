using System;
namespace FlightSchedule.Interfaces
{
	public interface IOrderRepository
	{
        Dictionary<string, string> LoadOrders(string filePath);
    }
}

