namespace SnakeGame.Models
{
    using System;

    public interface IPartition
    {
        Position Position { get; set; }

        ConsoleColor Color { get; }

        BoardValues BoardValue { get; }
    }
}
