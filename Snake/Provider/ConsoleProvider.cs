namespace SnakeGame.Provider
{
    using System;
    using System.Text;

    using Models;
    using SnakeGame.Contracts;

    public class ConsoleProvider : IConsoleProvider, IClearable
    {
        public const int WindowWidth = 50;
        public const int WindowHeight = 20;
        private const string Title = "Snake v1.0";

        public ConsoleProvider()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(WindowWidth, WindowHeight);
            Console.CursorVisible = false;
            Console.Title = Title;
        }

        public int ConsoleWindowWidth
        {
            get
            {
                return WindowWidth;
            }
        }

        public int ConsoleWindowHeight
        {
            get
            {
                return WindowHeight;
            }
        }

        public void PrintPartition(IPartition partition)
        {
            if (partition.Position.X >= 0 && partition.Position.X < WindowWidth &&
                partition.Position.Y >= 0 && partition.Position.Y < WindowHeight)
            {
                Console.ForegroundColor = partition.Color;
                Console.SetCursorPosition(partition.Position.X, partition.Position.Y);
                Console.Write(Partition.Symbol);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
