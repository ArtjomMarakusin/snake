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

			Text.WriteText("Пауза", 81, 3);
			Text.WriteText("(Клик мышью)", 81, 4);
			Text.WriteText("Продолжить", 81, 6);
			Text.WriteText("(Нажать стрелочки на клавиатуре)", 81, 7);

			HorizontalLine upline = new HorizontalLine(0, 78, 0, '*');
			HorizontalLine downline = new HorizontalLine(0, 78, 24, '*');
			VerticalLine leftline = new VerticalLine(0, 24, 0, '*');
			VerticalLine rightline = new VerticalLine(0, 24, 78, '*');
			upline.Drow();
			downline.Drow();
			leftline.Drow();
			rightline.Drow();
			Parametrs settings = new Parametrs();
			Sounds soundplay = new Sounds(settings.GetResourceFolder());
			soundplay.Play("title.mp3");
			Sounds soundeat = new Sounds(settings.GetResourceFolder());
			Sounds soundlost = new Sounds(settings.GetResourceFolder());

			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Drow();

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Text.WriteText("Очки: 0", 81, 1);
			Score scores = new Score();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					soundlost.Play("gameover.mp3");
					break;
				}

				if (snake.Eat(food))
				{
					soundeat.Play("eat.mp3");
					Console.ForegroundColor = ConsoleColor.Yellow;
					food = foodCreator.CreateFood();
					food.Draw();
					Console.ForegroundColor = ConsoleColor.Green;
					scores.Increase();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Green;
					snake.Move();
				}

				Thread.Sleep(Speed.SnSped(Score.playerScore));

				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			GameOver end = new GameOver();
			end.WriteGameOver();
			ViewRate.Results();
		}

	}
}