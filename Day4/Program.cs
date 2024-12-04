using System.Linq;

namespace Day4
{
    internal class Program
    {

        private static readonly int[,] Directions =
        {
            { 0, 1 },   //Right
            { 1, 0 },   //Down
            { 1, 1 },   //Horizontal right
            { 1, -1},   //Horizontal left
        };

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            Part1(input);
            Part2(input);
        }

        static void Part1(string[] input)
        {
            List<string> list = new List<string>();
            int rows = input.Length;
            int cols = input[0].Length;
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    for (int d = 0; d < Directions.GetLength(0); d++)
                    {
                        int hRow = Directions[d, 0];
                        int hCol = Directions[d, 1];

                        if (IsInBounds(row, col, hRow, hCol, 4, rows, cols))
                        {
                            string word = "";
                            for (int k = 0; k < 4; k++)
                            {
                                word += input[row + k * hRow][col + k * hCol];
                            }
                            list.Add(word);
                        }
                    }
                }
            }
            sum += list.Where(word => word == "XMAS" || word == "SAMX").Count();
            Console.WriteLine(sum);
        }
        static bool IsInBounds(int row, int col, int hRow, int hCol, int length, int rows, int cols)
        {
            int endRow = row + (length - 1) * hRow;
            int endCol = col + (length - 1) * hCol;

            return endRow >= 0 && endRow < rows && endCol >= 0 && endCol < cols;
        }

        static void Part2(string[] input)
        {
            List<string> cubes = new List<string>();
            int rows = input.Length;
            int cols = input[0].Length;
            int sum = 0;

            // ta ut alla 3x3 kuber
            for (int row = 0; row <= rows - 3; row++)
            {
                for (int col = 0; col <= cols - 3; col++)
                {
                    string cube = "";

                    for (int i = 0; i < 3; i++) 
                    {
                        for (int j = 0; j < 3; j++) 
                        {
                            cube += input[row + i][col + j];
                        }
                    }
                    cubes.Add(cube);
                }
            }
            //kolla positionerna 0,2,4,6,8 för MAS eller SAM
            foreach (string word in cubes)
            {
                if (((word[0] == 'M' && word[4] == 'A' && word[8] == 'S') || (word[0] == 'S' && word[4] == 'A' && word[8] == 'M')) &&
                    ((word[2] == 'M' && word[4] == 'A' && word[6] == 'S') || (word[2] == 'S' && word[4] == 'A' && word[6] == 'M')))
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
