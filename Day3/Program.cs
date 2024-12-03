using System.Text.RegularExpressions;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            Part1(input);
            Part2(input);
        }

        static void Part1(string input)
        {
            var sum = 0;

            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");

            sum += matches.Cast<Match>().Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value));

            Console.WriteLine(sum);
        }

        static void Part2(string input)
        {
            string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
            var sum = 0;
            bool dont = false;
            var matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                if(match.Value == "do()")
                {
                    dont = false;
                } else if (match.Value == "don't()")
                {
                    dont = true;
                } else
                {
                    if (!dont)
                    {
                        sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
