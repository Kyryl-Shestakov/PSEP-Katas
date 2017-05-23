using DataMunging;
using System;

namespace DataMungingApplication
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            DataHolder weatherData = DataMunger.CalculateMinimalSpreadRow(
                "weather.dat",
                @"\d+",
                1,
                2);

            Console.WriteLine(weatherData.Identifier + 
                " day has minimal temperature spread of " + weatherData.Difference);

            DataHolder footballData = DataMunger.CalculateMinimalSpreadRow(
                "football.dat",
                @"([A-z]|_)+",
                5,
                6);

            Console.WriteLine(footballData.Identifier + 
                " has minimal goal spread of " + footballData.Difference);

            Console.ReadKey(true);
        }
    }
}
