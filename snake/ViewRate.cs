using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class ViewRate
    {
        public static void Results()
        {

            int xOffset = 30;
            int yOffset = 6;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Console.ForegroundColor = ConsoleColor.Red;
            Text.WriteText("Статистика", xOffset + 1, yOffset++);
            yOffset++;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Text.WriteText("Очки   Имя", xOffset, yOffset++);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Score.ScoresRead(xOffset, yOffset++);

            Console.ReadLine();
        }
    }
}