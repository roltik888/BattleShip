namespace Battleship
{
    internal class Program
    {
        private static int w = 10;
        private static int h = 10;

        private static int[,] map = new int[h, w];
        private static string msg = "";
        private static bool done = false;

        static void Main(string[] args)
        {
            PopulateMap();
            while (!done)
            {
                DrawMap();

                Console.WriteLine($"X: 1 - {w}");
                Console.WriteLine($"Y: 1 - {h}\n");
                Console.Write("Enter a coordinate (X,Y): ");
                string coord = Console.ReadLine();

                try
                {
                    int xPos = Convert.ToInt32(coord.Split(',')[0]) - 1;
                    int yPos = Convert.ToInt32(coord.Split(',')[1]) - 1;

                    if (xPos > w - 1 || yPos > h - 1)
                    {
                        msg = "Shot out of range!";
                    }

                    CheckHit(xPos, yPos);
                }
                catch
                {
                    msg = "Unable to convert direction to coordinate";
                }
            }
        }

        private static void CheckHit(int x, int y)
        {
            if (map[y, x] == 3)
            {
                map[y, x] = 1;
                if (CheckWin())
                {
                    msg = "You Win!!!";
                    DrawMap();

                    Console.Write("Would you like to play again (y/n): ");
                    string answer = Console.ReadLine();

                    if (answer.ToLower() == "y")
                    {
                        PopulateMap();
                        msg = "";
                        return;
                    }
                    else
                    {
                        done = true;
                        return;
                    }
                }
                msg = "Shot hit!";
            }
            else
            {
                msg = "Miss!";
                map[y, x] = 2;
            }
        }

        private static bool CheckWin()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (map[i, j] == 3)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PopulateMap()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    map[i, j] = 0;
                }
            }

            AddShip();
        }

        private static void AddShip()
        {
            Random r = new();

            string direction;

            int x = r.Next(0, w - 1);
            int y = r.Next(0, h - 1);

            if (x < 5)
            {
                direction = "right";
            }
            else if (x > 5)
            {
                direction = "left";
            }
            else
            {
                direction = "left,right";
            }

            if (y < 5)
            {
                direction += "down";
            }
            else if (y > 5)
            {
                direction += "up";
            }
            else
            {
                direction += "up,down";
            }

            direction = direction.Split(',')[r.Next(0, direction.Split(',').Length)];

            if (direction == "up")
            {
                for (int i = y; i < y - 5; i--)
                {
                    map[i, x] = 3;
                }
            }
            else if (direction == "down")
            {
                for (int i = y; i < y + 5; i++)
                {
                    map[i, x] = 3;
                }
            }
            else if (direction == "left")
            {
                for (int i = x; i < x - 5; i--)
                {
                    map[y, i] = 3;
                }
            }
            else
            {
                for (int i = x; i < x + 5; i++)
                {
                    map[y, i] = 3;
                }
            }
        }

        private static void DrawMap()
        {
            Console.Clear();
            DrawLogo();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("+");
            for (int j = 0; j < w; j++)
            {
                Console.Write("-");
            }
            Console.Write("+\n");

            for (int i = 0; i < h; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("|");
                for (int j = 0; j < w; j++)
                {
                    switch (map[i, j])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("▒");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("0");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("▒");
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("|\n");
            }

            Console.Write("+");
            for (int j = 0; j < w; j++)
            {
                Console.Write("-");
            }
            Console.Write("+\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
        }

        private static void DrawLogo()
        {
            Console.Write("\n");
            Console.WriteLine(" ██████╗  █████╗ ████████╗████████╗██╗     ███████╗███████╗██╗  ██╗██╗██████╗ ");
            Console.WriteLine(" ██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝██╔════╝██║  ██║██║██╔══██╗");
            Console.WriteLine(" ██████╔╝███████║   ██║      ██║   ██║     █████╗  ███████╗███████║██║██████╔╝");
            Console.WriteLine(" ██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝  ╚════██║██╔══██║██║██╔═══╝ ");
            Console.WriteLine(" ██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗███████║██║  ██║██║██║     ");
            Console.WriteLine(" ╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝╚═╝╚═╝     ");
            Console.Write("\n");
        }
    }
}