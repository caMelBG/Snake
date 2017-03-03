namespace SnakeGame.Models.Snake
{
    using System;
    
    public class Tail : Partition, IPartition
    {
        public Tail(Position position) : base(position, ConsoleColor.Gray, BoardValues.Snake)
        {
        }
    }
}
