using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FootballDataMunging
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            List<string> rowList = new List<string>();

            using (TextReader sr = new StreamReader("football.dat"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    rowList.Add(line);
                }
            }

            IEnumerable<FootballTeamData> teams = rowList.Where(e => Regex.IsMatch(e, @"^\s*(\d)+"))
                .Select(e =>
                {
                    string name = "";
                    int @for = 0;
                    int against = 0;

                    Regex namePattern = new Regex(@"([A-z]|_)+");
                    Regex numberPattern = new Regex(@"(\d)+");
                    IEnumerable<int> matches = numberPattern.Matches(e).Cast<Match>().Select(m => int.Parse(m.Value));

                    name = namePattern.Match(e).Value;
                    @for = matches.ElementAt(5);
                    against = matches.ElementAt(6);

                    return new FootballTeamData(name, @for, against);
                });

            FootballTeamData minimalGoalSpreadTeam = teams.Aggregate((a, b) => a.GoalSpread < b.GoalSpread ? a : b);
            Console.WriteLine(minimalGoalSpreadTeam.Name + " has minimal goal spread of " + minimalGoalSpreadTeam.GoalSpread);
            Console.ReadKey(true);
        }
    }
}
