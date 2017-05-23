using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataMunging
{
    public class DataMunger
    {
        public static DataHolder CalculateMinimalSpreadRow(
            string fileName,
            string identifierPattern,
            int firstValueColumnIndex,
            int secondValueColumnIndex)
        {
            List<string> rowList = new List<string>();

            using (TextReader sr = new StreamReader(fileName))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    rowList.Add(line);
                }
            }

            IEnumerable<DataHolder> holders = rowList
                .Where(e => Regex.IsMatch(e, @"^\s*(\d)+"))
                .Select(e =>
                {
                    Regex namePattern = new Regex(identifierPattern);
                    Regex numberPattern = new Regex(@"(\d)+");
                    IEnumerable<int> matches = numberPattern.Matches(e).Cast<Match>().Select(m => int.Parse(m.Value));

                    var name = namePattern.Match(e).Value;
                    IList<int> numbers = matches as IList<int> ?? matches.ToList();
                    var firstValue = numbers.ElementAt(firstValueColumnIndex);
                    var secondValue = numbers.ElementAt(secondValueColumnIndex);

                    return new DataHolder(name, firstValue, secondValue);
                });

            DataHolder minimalSpreadData = holders.Aggregate((a, b) => a.Difference < b.Difference ? a : b);

            return minimalSpreadData;
        }
    }
}
