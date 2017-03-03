namespace SnakeGame.Models
{
    using System;

    public class Movement
    {
        public Movement(ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    this.X = 0;
                    this.Y = -1;
                    break;
                case ConsoleKey.DownArrow:
                    this.X = 0;
                    this.Y = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    this.X = -2;
                    this.Y = 0;
                    break;
                case ConsoleKey.RightArrow:
                    this.X = 2;
                    this.Y = 0;
                    break;
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
