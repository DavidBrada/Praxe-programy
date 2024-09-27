using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Globalization;

namespace Mezinarodni_cesta
{
  internal class Program
  {
    static HttpClient client = new HttpClient();
    const string clientId = "NlMhYhylN9XPUYwkQhgnAmUgMfBboLdV"; // API key
    const string clientSecret = "AP8bS2DYNr5SVMR2";
    const string tokenUrl = "https://test.api.amadeus.com/v1/security/oauth2/token";
    const string hotelsUrl = "https://test.api.amadeus.com/v2/shopping/hotel-offers";
    private const string airportUrl = "https://test.api.amadeus.com/v1/reference-data/locations?";

    static async Task Main(string[] args)
    {
      const string accessKey = "85b3a016d956f6268339eaa2646e3363";
      string flightApiUrl = $"http://api.aviationstack.com/v1/flights?access_key={accessKey}";

      HttpResponseMessage response = await client.GetAsync(flightApiUrl);
      string responseBody = await response.Content.ReadAsStringAsync();

      //string formattedJson = FormatResponse(responseBody);
      //Console.WriteLine(formattedJson);
      //GetSelectedData(responseBody);

      try
        {
            string accessToken = await GetAccessToken();
            string airportIata = "Madrid"; // Example IATA code for Madrid Airport
            var (latitude, longitude) = await GetAirportLocation(accessToken, airportIata);
            await GetHotelsNearby(accessToken, latitude, longitude, 10);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void GetSelectedData(string jsonResponse)
    {
      try
      {
        var flightData = JsonSerializer.Deserialize<FlightData>(jsonResponse);

        if (flightData == null || flightData.data == null)
        {
          Console.WriteLine("No flight data found in the response.");
          return;
        }
        
        
        Console.Write("Enter departure date: ");
        string userDepartureDate = Console.ReadLine(); // ex: 2024-09-27
      
        Console.Write("Enter Departure airport: ");
        string userDepartureAirport = Console.ReadLine(); // ex: IAD
      
        Console.Write("Enter Arrival airport: ");
        string userArrivalAirport = Console.ReadLine(); // ex: PDK
        
        foreach (var flight in flightData.data)
        {
          
          if (userDepartureDate == flight.flight_date && 
              userDepartureAirport == flight.departure.airport || userDepartureAirport.ToUpper() == flight.departure.iata &&
              userArrivalAirport == flight.arrival.airport || userArrivalAirport.ToUpper() == flight.arrival.iata)
          {
            flight.PrintFlightInfo();
          }
          //flight.PrintFlightInfo();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("An error occurred while deserializing or printing the data: " + ex.Message);
      }
    }

    public static string FormatResponse(string jsonResponse){
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
        return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions{WriteIndented = true});
    }

    private static async Task<string> GetAccessToken()
    {
        var requestBody = new StringContent($"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");
        
        var response = await client.PostAsync(tokenUrl, requestBody);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json).RootElement.GetProperty("access_token").GetString();
        
        return token;
    }

   private static async Task GetHotelsNearby(string accessToken, double latitude, double longitude, int radius)
{
    using var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

   var url = $"{hotelsUrl}?latitude={latitude.ToString("F5", CultureInfo.InvariantCulture)}&longitude={longitude.ToString("F5", CultureInfo.InvariantCulture)}&radius={radius}";
    Console.WriteLine($"Hotel API URL: {url}");

    try
    {
        var response = await client.GetAsync(url);
        
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Hotels Response: {jsonResponse}");
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode}, {errorResponse}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}

    private static async Task<(double latitude, double longitude)> GetAirportLocation(string accessToken, string airportKeyword)
{
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    
    var url = $"{airportUrl}subType=AIRPORT&keyword={airportKeyword}";
    var response = await client.GetAsync(url);
    
    if (response.IsSuccessStatusCode)
    {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"JSON Response: {jsonResponse}"); // Log the entire response

        // Parse the JSON response
        var airportData = JsonDocument.Parse(jsonResponse).RootElement.GetProperty("data")[0]; // Get the first airport entry

        // Access latitude and longitude from geoCode
        double latitude = airportData.GetProperty("geoCode").GetProperty("latitude").GetDouble();
        double longitude = airportData.GetProperty("geoCode").GetProperty("longitude").GetDouble();
        
        return (latitude, longitude);
    }
    else
    {
        var errorResponse = await response.Content.ReadAsStringAsync();
        throw new Exception($"Error fetching airport location: {response.StatusCode}, {errorResponse}");
    }
}
  }
}