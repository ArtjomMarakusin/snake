using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace snake
{
	class Program
	{
		public const ConsoleColor BorderColor = ConsoleColor.Yellow;

		static void Main(string[] args)
		{

			Walls walls = new Walls(80, 25);
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			walls.Draw();

			HorizontalLine upline = new HorizontalLine(0, 78, 0, '*');
			HorizontalLine downline = new HorizontalLine(0, 78, 24, '*');
			VerticalLine leftline = new VerticalLine(0, 24, 0, '*');
			VerticalLine rightline = new VerticalLine(0, 24, 78, '*');
			upline.Drow();
			downline.Drow();
			leftline.Drow();
			rightline.Drow();

			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Drow();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();

				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
		}

	}
}