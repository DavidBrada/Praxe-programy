using System;

namespace Mezinarodni_cesta
{
	public class Flight
	{
		public string flight_date { get; set; }
		public Departure departure { get; set; }
		public Arrival arrival { get; set; }
		public Airline airline { get; set; }

		public void PrintFlightInfo()
		{
			Console.WriteLine();
			Console.WriteLine($"Flight date: {flight_date}");
			Console.WriteLine($"Departing from {departure.airport} ({departure.iata}), gate {departure.gate} ({departure.timezone})");
			Console.WriteLine($"Arriving at {arrival.airport} ({arrival.iata}), ({arrival.timezone})");
			Console.WriteLine($"With {airline.name}");
			Console.WriteLine("--------------------");
		}
	}

	public class Airline
	{
		public string name { get; set; }
	}

    public class Departure
	{
		public string airport { get; set; }
		public string timezone { get; set; }
		public string iata { get; set; }
		public string? gate { get; set; }
	}

    public class Arrival
	{
		public string airport { get; set; }
		public string timezone { get; set; }
		public string iata { get; set; }
	}

    public class FlightData
	{
		public List<Flight> data { get; set; }

	}
}