namespace Green_vs._Red___Solution.Models
{
    using Green_vs._Red___Solution.Interfaces;
    using System;

    public class ConsoleWriter : IDataWriter
    {
        public void Write(int result)
        {
            Console.WriteLine(result);
        }
    }
}
