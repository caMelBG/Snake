namespace SnakeGame.Models.Snake
{
    using System;

    public class Head : Partition, IPartition
    {
        public Head(Position position) : base(position, ConsoleColor.Red, BoardValues.Snake)
        {
        }
    }
}
