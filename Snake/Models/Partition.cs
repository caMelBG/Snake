namespace SnakeGame.Models
{
    using System;

    public abstract class Partition : IPartition
    {
        public const string Symbol = "██";

        protected Partition(Position position, ConsoleColor color, BoardValues boardValue)
        {
            this.Position = position;
            this.Color = color;
            this.BoardValue = boardValue;
        }

        public Position Position { get; set; }

        public ConsoleColor Color { get; private set; }

        public BoardValues BoardValue { get; private set; }
    }
}
