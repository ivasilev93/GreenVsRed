namespace Green_vs._Red___Solution
{
    using Green_vs._Red___Solution.Interfaces;
    using Green_vs._Red___Solution.Models;
    using Green_vs._Red___Solution.Engine;

    public class Start
    {
        static void Main(string[] args)
        {
            IDataReader reader = new ConsoleReader();
            IDataWriter writer = new ConsoleWriter();

            var gameEngine = new GameEngine(writer, reader);

            gameEngine.Run();
        }       
    }
}
