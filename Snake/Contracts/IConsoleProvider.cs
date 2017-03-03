namespace SnakeGame.Contracts
{
    using SnakeGame.Models;

    public interface IConsoleProvider : IClearable
    {
        int ConsoleWindowWidth { get; }

        int ConsoleWindowHeight { get; }

        void PrintPartition(IPartition partition);
    }
}
