using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IceCity
{
    public class WeatherService
    {
     
        public async Task<List<DailyUsage>> FetchLastMonthWeatherAsync(HeaterBase defaultHeater)
        {
            List<DailyUsage> weatherUsages = new List<DailyUsage>();
            using var httpClient = new HttpClient();

           
            DateTime now = DateTime.UtcNow;
            DateTime start = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            DateTime end = new DateTime(now.Year, now.Month, 1).AddDays(-1);

            Console.WriteLine($"\n[API] Fetching weather data from {start:yyyy-MM-dd} to {end:yyyy-MM-dd}...");

            
            string url = $"https://archive-api.open-meteo.com/v1/archive?latitude=31.0409&longitude=31.3785&start_date={start:yyyy-MM-dd}&end_date={end:yyyy-MM-dd}&daily=temperature_2m_max,temperature_2m_min,precipitation_sum";

            try
            {
               
                var response = await httpClient.GetStringAsync(url);

                using var json = JsonDocument.Parse(response);
                var daily = json.RootElement.GetProperty("daily");

                var dates = daily.GetProperty("time").EnumerateArray();
                var maxTemps = daily.GetProperty("temperature_2m_max").EnumerateArray();
                var minTemps = daily.GetProperty("temperature_2m_min").EnumerateArray();
                var rain = daily.GetProperty("precipitation_sum").EnumerateArray();

                
                while (dates.MoveNext() && maxTemps.MoveNext() && minTemps.MoveNext() && rain.MoveNext())
                {
                    DateTime date = DateTime.Parse(dates.Current.GetString());
                    double maxTemp = maxTemps.Current.GetDouble();

                    
                    double simulatedHours = maxTemp < 20 ? 8.0 : 3.0;

                    
                    DailyUsage usage = new DailyUsage(date, simulatedHours, defaultHeater);
                    weatherUsages.Add(usage);
                }

                Console.WriteLine("[API] Weather data fetched and saved successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[API ERROR] Failed to fetch weather data: {ex.Message}");
            }

            return weatherUsages;
        }

    }
}