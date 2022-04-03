using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace snake
{
    class GameOver : Score
    {
        public void WriteGameOver()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            int xOffset = 25;
            int yOffset = 6;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            Text.WriteText("----------------------------", xOffset, yOffset++);
            Text.WriteText("   G A M E    O V E R", xOffset + 1, yOffset++);
            yOffset++;

            Console.ForegroundColor = ConsoleColor.Green;
            Text.WriteText("Ваш счет: " + playerScore, xOffset + 8, yOffset++);

            Console.ForegroundColor = ConsoleColor.Red;
            Text.WriteText("----------------------------", xOffset, yOffset++);
            yOffset++;

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Text.WriteText("Введите свое имя (мин 3 буквы): ", xOffset - 3, 13);
                    Console.SetCursorPosition(54, 13);
                    string playername = Console.ReadLine();
                    int sym = 3;
                    if (sym <= playername.Length)
                    {
                        ScoresSave(playername, playerScore);
                        break;
                    }
                    else
                    {
                        throw new LengthException();
                    }
                }
                catch (LengthException)
                {
                    Text.WriteText("                                        ", xOffset, 13);
                    Text.WriteText("Введите имя, в котором минимум 3 символа", xOffset - 3, 14);
                }
            }
        }
    }
}
