namespace Green_vs._Red___Solution.Engine
{
    using Green_vs._Red___Solution.Interfaces;
    using System;

    public class GameEngine
    {
        private IDataWriter writer_;
        private IDataReader reader_;

        public GameEngine(IDataWriter writer, IDataReader reader)
        {
            this.SetWriter(writer);
            this.SetReader(reader);
        }

        private void SetWriter(IDataWriter value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            this.writer_ = value;
        }

        private void SetReader(IDataReader value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            this.reader_ = value;
        }

        public void Run()
        {
            var readerData = this.reader_.ReadData();

            var generationsSimulator = new GenerationsSimulator(readerData.Grid, readerData.CellRow, readerData.CellCol, readerData.Generations);

            this.writer_.Write(generationsSimulator.CalculateCellChanges());
        }
    }
}
