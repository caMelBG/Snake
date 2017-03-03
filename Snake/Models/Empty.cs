namespace SnakeGame.Models
{
    using System;

    public class Empty : Partition, IPartition
    {
        public Empty(Position position) : base(position, ConsoleColor.Black, BoardValues.Empty)
        {
        }
    }
}