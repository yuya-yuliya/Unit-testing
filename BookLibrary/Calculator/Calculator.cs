using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            char[] separators = { ',', '\n' };
            var sum = 0;

            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (!string.IsNullOrEmpty(numbers))
            {
                var regex = new Regex(@"^\\(\S)\n", RegexOptions.Singleline);
                string[] substrs;
                if (regex.IsMatch(numbers))
                {
                    var match = regex.Match(numbers);
                    numbers = numbers.Replace(match.Value, "");
                    substrs = numbers.Split(new string[] { match.Groups[1].Value }, StringSplitOptions.None);
                }
                else
                {
                    substrs = numbers.Split(separators);
                }

                var parseNumbers = substrs.Select(substr => 
                {
                    if (!int.TryParse(substr, out int number))
                    {
                        throw new ArgumentException();
                    }

                    return number;
                });

                var negatives = parseNumbers.Where(number => number < 0).ToArray();
                if (negatives.Length > 0)
                {
                    throw new ArgumentOutOfRangeException($"Has negative numbers: {string.Join(",", negatives)}");
                }

                sum = parseNumbers.Sum();
            }

            return sum;
        }
    }
}
