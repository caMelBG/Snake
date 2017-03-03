namespace SnakeGame.Models
{
    using System;

    public class Food : Partition, IPartition
    {
        public Food(Position position) : base(position, ConsoleColor.Green, BoardValues.Food)
        {
        }
    }
}
