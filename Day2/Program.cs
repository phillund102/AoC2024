using System.Diagnostics;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Not proud of this day, but whatever it works... :D 
            var input = File.ReadAllLines("input.txt");

            Part1(input);

            Part2(input);
        }

        public static void Part1(string[] input)
        {
            var sum = 0;
            foreach (var part in input)
            {
                var splitted = part.Split(' ');
                bool increment;
                bool? prevIncrement = null;
                var isTrue = true;

                for (int i = 1; i < splitted.Length; i++)
                {
                    if (int.Parse(splitted[i - 1]) == int.Parse(splitted[i]) || Math.Abs(int.Parse(splitted[i - 1]) - int.Parse(splitted[i])) > 3)
                    {
                        isTrue = false;
                        break;
                    }
                    else if (int.Parse(splitted[i - 1]) > int.Parse(splitted[i]))
                    {
                        increment = false;
                    }
                    else
                    {
                        increment = true;
                    }

                    if(prevIncrement != null)
                    {
                        if(prevIncrement != increment)
                        {
                            isTrue = false;
                            break;
                        }
                    }

                    prevIncrement = increment;
                }

                if (isTrue) 
                {
                    sum += 1;
                }
            }
            Console.WriteLine(sum);
        }

        static void Part2(string[] input)
        {
            var sum = 0;

            foreach (var part in input)
            {
                var splitted = part.Split(' ');
                bool isOverallTrue = false;

                for (int removeIndex = 0; removeIndex < splitted.Length; removeIndex++)
                {
                    var reducedArray = splitted.Where((_, index) => index != removeIndex).ToArray();

                    bool increment;
                    bool? prevIncrement = null;
                    bool isTrue = true;

                    for (int i = 1; i < reducedArray.Length; i++)
                    {
                        if (int.Parse(reducedArray[i - 1]) == int.Parse(reducedArray[i]) || Math.Abs(int.Parse(reducedArray[i - 1]) - int.Parse(reducedArray[i])) > 3)
                        {
                            isTrue = false;
                            break;
                        }
                        else if (int.Parse(reducedArray[i - 1]) > int.Parse(reducedArray[i]))
                        {
                            increment = false;
                        }
                        else
                        {
                            increment = true;
                        }

                        if (prevIncrement != null)
                        {
                            if (prevIncrement != increment)
                            {
                                isTrue = false;
                                break;
                            }
                        }

                        prevIncrement = increment;
                    }

                    if (isTrue)
                    {
                        isOverallTrue = true;
                        break;
                    }
                }

                if (isOverallTrue)
                {
                    sum += 1;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
