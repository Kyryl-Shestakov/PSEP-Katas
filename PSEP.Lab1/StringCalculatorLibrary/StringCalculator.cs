using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Int32;

namespace StringCalculatorLibrary
{
    public static class StringCalculator
    {
        public static int Add1(string numbers)
        {
            if (numbers.Equals(""))
            {
                return 0;
            }

            int commaIndex = numbers.IndexOf(",", StringComparison.Ordinal);

            if (commaIndex < 0)
            {
                return Parse(numbers);
            }

            string firstNumber = numbers.Substring(0, commaIndex);
            string secondNumber = numbers.Substring(commaIndex + 1);

            return Parse(firstNumber) + Parse(secondNumber);
        }

        public static int Add2(string numbers)
        {
            return (numbers.Equals("")) ? 0 : numbers.Split(',').Sum(e => Parse(e));
        }

        public static int Add3(string numbers)
        {
            return (numbers.Equals("")) ? 0 : numbers.Split(',', '\n').Sum(e => Parse(e));
        }

        public static int Add4(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                string[] separatedNumbers = numbers.Substring(4).Split(numbers[2]);
                return separatedNumbers.Where(e => !e.Equals("")).Sum(e => Parse(e));
            }

            return (numbers.Equals("")) ? 0 : numbers.Split(',', '\n').Sum(e => Parse(e));
        }

        public static int Add5(string numbers)
        {
            string[] separatedNumbers = ((numbers.StartsWith("//"))
                ? numbers.Substring(4).Split(numbers[2])
                : ((numbers.Equals("")) ? new string[0] : numbers.Split(',', '\n'))).Where(e => !e.Equals("")).ToArray();

            if (!separatedNumbers.Any())
            {
                return 0;
            }

            var numberList = separatedNumbers.Select(Parse).ToList();

            if (numberList.Any(e => e < 0))
            {
                throw new ArgumentException("Negative numbers are not allowed: " + numberList.Where(e => e < 0).Select(e => e.ToString()).Aggregate((a, b) => a + ", " + b), nameof(numbers));
            }

            return numberList.Sum();
        }

        public static int Add6(string numbers)
        {
            string[] separatedNumbers = ((numbers.StartsWith("//"))
                ? numbers.Substring(4).Split(numbers[2])
                : ((numbers.Equals("")) ? new string[0] : numbers.Split(',', '\n'))).Where(e => !e.Equals("")).ToArray();

            if (!separatedNumbers.Any())
            {
                return 0;
            }

            var numberList = separatedNumbers.Select(Parse).ToList();

            if (numberList.Any(e => e < 0))
            {
                throw new ArgumentException("Negative numbers are not allowed: " + numberList.Where(e => e < 0).Select(e => e.ToString()).Aggregate((a, b) => a + ", " + b), nameof(numbers));
            }

            return numberList.Where(e => e <= 1000).Sum();
        }

        public static int Add7(string numbers)
        {
            string[] separatedNumbers = null;

            if (numbers.StartsWith("//["))
            {
                Match delimiterMatch = Regex.Match(numbers, @"\[(.)\1*?\]");

                if (delimiterMatch.Success)
                {
                    separatedNumbers =
                        numbers.Substring(numbers.IndexOf("]\n", StringComparison.Ordinal) + 2)
                            .Replace(delimiterMatch.Value.Substring(1, delimiterMatch.Value.Length - 2), ",")
                            .Split(',');
                }
            }
            else
            {
                separatedNumbers = ((numbers.StartsWith("//"))
                ? numbers.Substring(4).Split(numbers[2])
                : ((numbers.Equals("")) ? new string[0] : numbers.Split(',', '\n'))).Where(e => !e.Equals("")).ToArray();
            }

            

            if (!separatedNumbers.Any())
            {
                return 0;
            }

            var numberList = separatedNumbers.Select(Parse).ToList();

            if (numberList.Any(e => e < 0))
            {
                throw new ArgumentException("Negative numbers are not allowed: " + numberList.Where(e => e < 0).Select(e => e.ToString()).Aggregate((a, b) => a + ", " + b), nameof(numbers));
            }

            return numberList.Where(e => e <= 1000).Sum();
        }

        public static int Add8(string numbers)
        {
            string[] separatedNumbers = null;

            if (numbers.StartsWith("//["))
            {
                Match beginning = Regex.Match(numbers, @"\A//(\[.\])+");

                if (beginning.Success)
                {
                    MatchCollection delimiterCollection = Regex.Matches(beginning.Value, @"\[.\]");
                    char[] delimiters = delimiterCollection.Cast<Match>().Select(m => m.Value[1]).ToArray();
                    separatedNumbers =
                        numbers.Substring(numbers.IndexOf("]\n", StringComparison.Ordinal) + 2).Split(delimiters);
                }
                else
                {
                    Match delimiterMatch = Regex.Match(numbers, @"\[(.)\1*?\]");

                    if (delimiterMatch.Success)
                    {
                        separatedNumbers =
                            numbers.Substring(numbers.IndexOf("]\n", StringComparison.Ordinal) + 2)
                                .Replace(delimiterMatch.Value.Substring(1, delimiterMatch.Value.Length - 2), ",")
                                .Split(',');
                    }
                }
            }
            else
            {
                separatedNumbers = ((numbers.StartsWith("//"))
                ? numbers.Substring(4).Split(numbers[2])
                : ((numbers.Equals("")) ? new string[0] : numbers.Split(',', '\n'))).Where(e => !e.Equals("")).ToArray();
            }



            if (!separatedNumbers.Any())
            {
                return 0;
            }

            var numberList = separatedNumbers.Select(Parse).ToList();

            if (numberList.Any(e => e < 0))
            {
                throw new ArgumentException("Negative numbers are not allowed: " + numberList.Where(e => e < 0).Select(e => e.ToString()).Aggregate((a, b) => a + ", " + b), nameof(numbers));
            }

            return numberList.Where(e => e <= 1000).Sum();
        }

        public static int Add9(string numbers)
        {
            string[] separatedNumbers = null;

            if (numbers.StartsWith("//["))
            {
                Match beginning = Regex.Match(numbers, @"\A//(\[(.)*?\])+");

                if (beginning.Success)
                {
                    MatchCollection delimiterCollection = Regex.Matches(beginning.Value, @"\[(.)*?\]");
                    string[] delimiters = delimiterCollection.Cast<Match>().Select(m => m.Value.Substring(1, m.Value.Length - 2)).ToArray();
                    string joinedNumbers = numbers.Substring(numbers.IndexOf("]\n", StringComparison.Ordinal) + 2);
                    joinedNumbers = delimiters.Aggregate(joinedNumbers, (current, d) => current.Replace(d, ";"));
                    separatedNumbers = joinedNumbers.Split(';');
                }
            }
            else
            {
                separatedNumbers = ((numbers.StartsWith("//"))
                ? numbers.Substring(4).Split(numbers[2])
                : ((numbers.Equals("")) ? new string[0] : numbers.Split(',', '\n'))).Where(e => !e.Equals("")).ToArray();
            }



            if (!separatedNumbers.Any())
            {
                return 0;
            }

            var numberList = separatedNumbers.Select(Parse).ToList();

            if (numberList.Any(e => e < 0))
            {
                throw new ArgumentException("Negative numbers are not allowed: " + numberList.Where(e => e < 0).Select(e => e.ToString()).Aggregate((a, b) => a + ", " + b), nameof(numbers));
            }

            return numberList.Where(e => e <= 1000).Sum();
        }
    }
}
