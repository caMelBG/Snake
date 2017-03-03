namespace SnakeGame.Logic
{
    using System;
    using System.Threading;
    
    using Contracts;
    using Models;
    using Models.Snake;

    public class Engine
    {
        private const int StartSnakeLength = 5;
        private const int StartSnakePositionX = 20;
        private const int StartSnakePositionY = 13;
        private const int StartFoodPositionX = 10;
        private const int StartFoodPositionY = 10;

        private IBoardProvider boardProvider;
        private IConsoleProvider consoleProvider;
        private ISnake snake;
        private int timer = 150;

        public Engine(IBoardProvider boardProvider, IConsoleProvider consoleProvider, ISnake snake)
        {
            this.boardProvider = boardProvider;
            this.consoleProvider = consoleProvider;
            this.snake = snake;
        }

        public void Start()
        {
            this.Initialization();
            this.GameLoop();
        }

        private void GameOver()
        {
            Thread.Sleep(500);
            this.boardProvider.Clear();
            this.consoleProvider.Clear();
            this.snake.Clear();
            this.Start();
        }
        
        private void Initialization()
        {
            // Food Initialization
            var position = new Position(StartFoodPositionX, StartFoodPositionY);
            var food = new Food(position);
            this.boardProvider.SetValue(food);
            this.consoleProvider.PrintPartition(food);

            // Snakes Head Initilization
            position = new Position(StartSnakePositionX, StartSnakePositionY);
            var head = new Head(position);
            this.snake.AddElement(head);
            this.boardProvider.SetValue(head);
            this.consoleProvider.PrintPartition(head);

            // Snakes Body Initialization
            for (int index = 2; index <= StartSnakeLength * 2; index += 2)
            {
                position = new Position(StartSnakePositionX + index, StartSnakePositionY);
                var tail = new Tail(position);
                this.snake.AddElement(tail);
                this.boardProvider.SetValue(tail);
                this.consoleProvider.PrintPartition(tail);
            }

            // Bottom Wall Initialization
            for (int index = 0; index < this.consoleProvider.ConsoleWindowWidth - 1; index++)
            {
                position = new Position(index, this.consoleProvider.ConsoleWindowHeight - 2);
                var wall = new Wall(position);
                this.consoleProvider.PrintPartition(wall);
            }
        }

        private void GameLoop()
        {
            Movement movement = null;
            var previousKey = new ConsoleKeyInfo();
            var currentKey = new ConsoleKeyInfo();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey();
                    if (previousKey.Key != currentKey.Key)
                    {
                        if ((previousKey.Key == ConsoleKey.UpArrow && currentKey.Key == ConsoleKey.DownArrow) ||
                            (previousKey.Key == ConsoleKey.DownArrow && currentKey.Key == ConsoleKey.UpArrow) ||
                            (previousKey.Key == ConsoleKey.LeftArrow && currentKey.Key == ConsoleKey.RightArrow) ||
                            (previousKey.Key == ConsoleKey.RightArrow && currentKey.Key == ConsoleKey.LeftArrow))
                        {
                            continue;
                        }
                        else
                        {
                            previousKey = currentKey;
                            movement = new Movement(previousKey.Key);
                        }
                    }
                }

                this.GameUpdate(movement);
                Thread.Sleep(this.timer);
            }
        }

        private void GameUpdate(Movement movement)
        {
            if (movement == null)
            {
                return;
            }

            int x = this.snake.Body[0].Position.X + movement.X;
            x = x % 2 == 1 ? x -= 1 : x;
            int y = this.snake.Body[0].Position.Y + movement.Y;
            var newHeadPosition = new Position(x, y);
            var boardValue = this.boardProvider.CheckPosition(newHeadPosition);
            if (boardValue == BoardValues.Empty)
            {
                this.Move(newHeadPosition);
            }
            else if (boardValue == BoardValues.Food)
            {
                this.Eat(newHeadPosition);
                this.NewFood();
            }
            else if (boardValue == BoardValues.Snake)
            {
                if (this.snake.Body[0].Position.X != newHeadPosition.X ||
                    this.snake.Body[0].Position.Y != newHeadPosition.Y)
                {
                    this.GameOver();
                }
            }
            else if (boardValue == BoardValues.Wall)
            {
                this.GameOver();
            }
        }

        private void Move(Position newHeadPosition)
        {
            var head = this.snake.Body[0];
            var prev = this.snake.Body[1];
            var snakeLastElementPosition = this.snake.Body[this.snake.Length - 1].Position;
            var empty = new Empty(snakeLastElementPosition);
            this.snake.UpdatePositions(1, this.snake.Length - 1, newHeadPosition);
            this.consoleProvider.PrintPartition(head);
            this.boardProvider.SetValue(head);
            this.consoleProvider.PrintPartition(prev);
            this.boardProvider.SetValue(prev);
            this.consoleProvider.PrintPartition(empty);
            this.boardProvider.SetValue(empty);
        }

        private void Eat(Position position)
        {
            var newElement = new Tail(position);
            this.snake.AddElement(newElement);
            this.snake.UpdatePositions(1, this.snake.Length - 1, position);
            this.consoleProvider.PrintPartition(this.snake.Body[0]);
            this.consoleProvider.PrintPartition(this.snake.Body[1]);
            this.boardProvider.SetValue(newElement);
        }

        private void NewFood()
        {
            var position = this.GeneratePosition();
            var boardValue = this.boardProvider.CheckPosition(position);
            while (boardValue != BoardValues.Empty)
            {
                position = this.GeneratePosition();
                boardValue = this.boardProvider.CheckPosition(position);
            }

            var food = new Food(position);
            this.boardProvider.SetValue(food);
            this.consoleProvider.PrintPartition(food);
        }

        private Position GeneratePosition()
        {
            var random = new Random();
            int x = random.Next(0, this.consoleProvider.ConsoleWindowWidth);
            x = x % 2 == 1 ? x += 1 : x;
            int y = random.Next(0, this.consoleProvider.ConsoleWindowHeight);
            var position = new Position(x, y);
            return position;
        }
    }
}
