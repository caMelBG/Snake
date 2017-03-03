namespace SnakeGame.Models.Snake
{
    using System.Collections.Generic;
    using SnakeGame.Contracts;

    public class Snake : ISnake, IClearable
    {
        public Snake()
        {
            this.Body = new List<IPartition>();
        }

        public int Length
        {
            get
            {
                return this.Body.Count;
            }
        }

        public IList<IPartition> Body { get; private set; }

        public void AddElement(IPartition element)
        {
            this.Body.Add(element);
        }

        public void DeleteLastElement()
        {
            this.Body.RemoveAt(this.Length - 1);
        }

        public void UpdatePositions(int startIndex, int endIndex, Position position)
        {
            for (int index = endIndex; index >= startIndex; index--)
            {
                this.Body[index].Position = this.Body[index - 1].Position;
            }

            this.Body[0].Position = position;
        }

        public void Clear()
        {
            this.Body.Clear();
        }
    }
}
