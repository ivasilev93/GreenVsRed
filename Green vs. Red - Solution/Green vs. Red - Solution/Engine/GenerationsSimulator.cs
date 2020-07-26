namespace Green_vs._Red___Solution.Engine
{
    using System;

    public class GenerationsSimulator
    {
        private bool[,] generationChangesTracker;
        private bool[,] grid_;
                
        public GenerationsSimulator(bool[,] grid, int targerCellRow, int targetCellCol, int generations)
        {
            this.Grid = grid;
            this.TargetCellRow = targerCellRow;
            this.TargetCellCol = targetCellCol;
            this.Generations = generations;
            this.generationChangesTracker = new bool[grid.GetLength(0), grid.GetLength(1)];
        }

        //would put validation in the setters, if needed, for example:
        public bool[,] Grid
        {
            get { return this.grid_; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.grid_ = value;
            }
        }

        //else just using auto properties
        public int TargetCellRow { get; set; }
        public int TargetCellCol { get; set; }
        public int Generations { get; set; }

        public int CalculateCellChanges()
        {
            int totalCellChanges = 0;

            for (int generation = 0; generation <= this.Generations; generation++)
            {
                if(this.Grid[TargetCellRow, TargetCellCol])
                {
                    totalCellChanges++;
                }

                GenerateChangesRecordForEveryCell();
                ExecuteGenerationChanges();

                Array.Clear(this.generationChangesTracker, 0, this.generationChangesTracker.Length);
            }            

            return totalCellChanges;
        }

        private void GenerateChangesRecordForEveryCell()
        {
            //checking each cell from the grid for changes
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    int greenNeighbours = 0;

                    for (int neighbourRow = row - 1; neighbourRow <= row + 1; neighbourRow++)
                    {
                        for (int neighbourCol = col - 1; neighbourCol <= col + 1; neighbourCol++)
                        {
                            //skip incase we step out of the grid bounds
                            if (neighbourRow < 0 || neighbourRow >= Grid.GetLength(0) || neighbourCol < 0 || neighbourCol >= Grid.GetLength(1))
                            {
                                continue;
                            }

                            //skip when neighbor's cell position matches cell's position
                            if (neighbourRow == row && neighbourCol == col)
                            {
                                continue;
                            }

                            //if neighbor is green, we add it up to the sum
                            if (Grid[neighbourRow, neighbourCol])
                            {
                                greenNeighbours++;
                            }
                        }
                    }

                    //if cell is red and matches conditions, mark for change
                    if (!Grid[row, col] && (greenNeighbours == 3 || greenNeighbours == 6))
                    {
                        this.generationChangesTracker[row, col] = true;
                    }

                    //if cell is green and matches conditions, mark for change
                    if (Grid[row,col] && greenNeighbours != 2 && greenNeighbours != 3 && greenNeighbours != 6)
                    {
                        this.generationChangesTracker[row, col] = true;
                    }                    
                }
            }
        }

        private void ExecuteGenerationChanges()
        {
            for (int row = 0; row < this.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < this.Grid.GetLength(1); col++)
                {
                    if (this.generationChangesTracker[row,col])
                    {
                        this.Grid[row, col] = !this.Grid[row, col];
                    }
                }
            }            
        }
    }
}
