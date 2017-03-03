namespace SnakeGame.Models
{
    using System;
    
    public class Wall : Partition, IPartition
    {
        public Wall(Position position) : base(position, ConsoleColor.Blue, BoardValues.Snake)
        {
        }
    }
}
