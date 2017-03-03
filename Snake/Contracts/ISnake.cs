namespace SnakeGame.Contracts
{
    using System.Collections.Generic;

    using SnakeGame.Models;

    public interface ISnake : IClearable
    {
        int Length { get; }

        IList<IPartition> Body { get; }

        void AddElement(IPartition element);

        void DeleteLastElement();

        void UpdatePositions(int startIndex, int endIndex, Position position);
    }
}
