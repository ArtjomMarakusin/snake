using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace snake
{
    class Score
    {
        public static int playerScore;
        public void Increase()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            playerScore++;
            Text.WriteText("Очки: " + playerScore, 81, 1);
        }

        public void ScoresSave(string name, int score)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string text;
            StreamWriter use = new StreamWriter(@"..\..\Top.txt", true);
            text = score + " " + name;
            use.WriteLine(text);
            use.Close();
        }

        public static void ScoresRead(int xOffset, int yOffset)
        {
            using (StreamReader usefrom = new StreamReader(@"..\..\Top.txt"))
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                List<string> list = new List<string>();
                list = File.ReadAllLines(@"..\..\Top.txt").ToList();
                var sortedUsers = from u in list
                                  orderby u descending
                                  select u;
                foreach (var u in sortedUsers)
                {
                    Text.WriteText(u, xOffset, yOffset++);
                }
            }
        }
    }
}

