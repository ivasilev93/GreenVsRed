namespace Green_vs._Red___Solution.Interfaces
{
    public interface IDataReader
    {
        public (bool[,] Grid, int CellRow, int CellCol, int Generations) ReadData();
    }
}
