namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var readText = File.ReadAllText("input.txt").ToArray();

            var list1 = new List<int>();
            var list2 = new List<int>();

            foreach(var line in File.ReadAllLines("input.txt"))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                list1.Add(int.Parse(parts[0]));
                list2.Add(int.Parse(parts[1]));
            }

            list1.Sort();
            list2.Sort();

            var list = new List<int[]>();

            for (int i = 0; i < list1.Count; i++)
            {
                list.Add([list1[i], list2[i]]);
            }


            Part1(list);
            Part2(list1, list2);
        }

        public static void Part1(List<int[]> list)
        {
            var sum = 0;

            foreach (var item in list)
            {
                sum += Math.Abs(item[0] - item[1]);
            }

            Console.WriteLine(sum);
        }

        public static void Part2(List<int> left, List<int> right)
        {
            var sum = 0;
            foreach (var item in left)
            {
                var existsCount = right.Count(n => n == item);
                sum += existsCount * item;
            }
            Console.WriteLine(sum);
        }
    }
}
