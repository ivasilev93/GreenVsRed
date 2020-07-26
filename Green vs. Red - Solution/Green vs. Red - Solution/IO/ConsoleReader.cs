namespace Green_vs._Red___Solution.Models
{
    using Green_vs._Red___Solution.Interfaces;
    using System;

    public class ConsoleReader : IDataReader
    {        
        public ConsoleReader()
        {            
        }

        public (bool[,] Grid, int CellRow, int CellCol, int Generations) ReadData()
        {
            var dimentions = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            var cols = int.Parse(dimentions[0]);
            var rows = int.Parse(dimentions[1]);

            var grid = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    if (input[col] == '1')
                    {
                        // false(0) for red, (1)true for green
                        grid[row, col] = true;
                    }
                }
            }

            var cellArgs = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            return (grid, int.Parse(cellArgs[1]), int.Parse(cellArgs[0]), int.Parse(cellArgs[2]));
        }
    }
}
