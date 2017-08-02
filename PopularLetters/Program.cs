using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? string.Empty;
            string[] delimiters = new string[] { ",", " " };

            input = delimiters.Aggregate(input, (current, delimiter) => current.Replace(delimiter, ""));

            var charCount = input
                .GroupBy(x => x)
                .Select(x => new { Character = x.Key, Count = x.Count() })
                .ToList();

            int max = charCount.Max(x => x.Count);
            var output = string.Join(" ",
                charCount
                    .Where(x => x.Count == max)
                    .Select(x => x.Character)
                );

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
