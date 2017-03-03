namespace SnakeGame
{
    using SnakeGame.Logic;
    using SnakeGame.Models.Snake;
    using SnakeGame.Provider;

    public class StartUp
    {
        private static void Main()
        {
            Engine engine = new Engine(
                new BoardProvider(),
                new ConsoleProvider(),
                new Snake());
            engine.Start();
        }
    }
}