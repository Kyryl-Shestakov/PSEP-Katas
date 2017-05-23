using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WeatherDataMunging
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            List<string> rowList = new List<string>();

            using (TextReader sr = new StreamReader("weather.dat"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    rowList.Add(line);
                }
            }

            IEnumerable<DayWeatherData> days = rowList.Where(e => Regex.IsMatch(e, @"^\s*(\d)+"))
                .Select(e =>
                {
                    int dayNumber = 0;
                    int maxTemperature = 0;
                    int minTemperature = 0;

                    Regex r = new Regex(@"(\d)+");
                    IEnumerable<int> matches = r.Matches(e).Cast<Match>().Select(m => int.Parse(m.Value));

                    dayNumber = matches.ElementAt(0);
                    maxTemperature = matches.ElementAt(1);
                    minTemperature = matches.ElementAt(2);

                    return new DayWeatherData(dayNumber, maxTemperature, minTemperature);
                });

            DayWeatherData minimalTemperatureSpreadDay = days.Aggregate((a, b) => a.TemperatureSpread < b.TemperatureSpread ? a : b);
            Console.WriteLine("The " + minimalTemperatureSpreadDay.DayNumber + " day has minimal temperature spread of " + minimalTemperatureSpreadDay.TemperatureSpread);
            Console.ReadKey(true);
        }
    }
}
