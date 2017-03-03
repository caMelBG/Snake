namespace SnakeGame.Provider
{
    using SnakeGame.Contracts;
    using SnakeGame.Models;

    public class BoardProvider : IBoardProvider, IClearable
    {
        private const int BoardWidthSize = 25;
        private const int BoardHeightSize = 18;
        private int[,] board;

        public BoardProvider()
        {
            this.board = new int[BoardHeightSize, BoardWidthSize];
        }

        public void SetValue(IPartition partition)
        {
            int row = partition.Position.Y;
            int col = partition.Position.X / 2;
            this.board[row, col] = (int)partition.BoardValue;
        }

        public BoardValues CheckPosition(Position position)
        {
            int row = position.Y;
            int col = position.X / 2;
            if (row >= 0 && row < BoardHeightSize &&
                col >= 0 && col < BoardWidthSize)
            {
                if (this.board[row, col] == 0)
                {
                    return BoardValues.Empty;
                }
                else if (this.board[row, col] == 1)
                {
                    return BoardValues.Snake;
                }
                else if (this.board[row, col] == 2)
                {
                    return BoardValues.Food;
                }
            }

            return BoardValues.Wall;
        }

        public void Clear()
        {
            this.board = new int[BoardHeightSize, BoardWidthSize];
        }
    }
}
