namespace SnakeGame.Contracts
{
    using SnakeGame.Models;

    public interface IBoardProvider : IClearable
    {
        void SetValue(IPartition partition);

        BoardValues CheckPosition(Position position);
    }
}
