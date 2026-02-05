using System.Runtime.CompilerServices;

namespace Statki
{
    internal class Program
    {
        static Random xd = new Random();
        static void Main(string[] args)
        {
            // GTA VI code
            // graphic = high
            // walk = w, a, s, d
            // run = shift 
            // bugs = no
            // cheater = ban
            int woda = 0;
            int statek = 1;
            int shoot = 2;
            int trafiony = 3;
            int w = 10;
            int h = 10;
            int[,] pole = new int[w, h];
            int[,] widokGracza = new int[10, 10];
            int[] flota = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            while (true)
            {
                Console.Clear();
                DrawLogo();
                rysujpole(pole);
                strzal(pole);
            }


















        }
        static void Postawstatki(int[,] pole, int dlugosc)
        {
            bool jest = false;
            while (!jest)
            {
                int x = xd.Next(0, 10);
                int y = xd.Next(0, 10);
                int kierunek = xd.Next(0, 2);
                if (Moznapostawic(pole, x, y, dlugosc, kierunek))
                {
                    for (int i = 0; i < dlugosc; i++)
                    {
                        int kX = (kierunek == 0) ? x : x + i;
                        int kY = (kierunek == 0) ? y + i : y;
                        pole[kX, kY] = 1;
                    }
                    jest = true;
                }
            }
        }
        static bool Moznapostawic(int[,] pole, int x, int y, int dlugosc, int kierunek)
        {
            for (int i = 0; i < dlugosc; i++)
            {
                int kX = (kierunek == 0) ? x : x + i;
                int kY = (kierunek == 0) ? y + i : y;
                if (kX >= 10 || kY >= 10) return false;
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int sprX = kX + dx;
                        int sprY = kY + dy;
                        if (sprX >= 0 && sprX < 10 && sprY >= 0 && sprY < 10)
                        {
                            if (pole[sprX, sprY] != 0) return false;
                        }
                    }
                }
            }
            return true;
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
        static void strzal(int[,] pole)
        {
            Console.WriteLine("Podaj X: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y: ");
            int y = int.Parse(Console.ReadLine());
            if (pole[x, y] == 1)
            {
                pole[x,y] = 3;
                Console.WriteLine("Trafiłeś");
            }
            else if (pole[x, y] == 0)
            {
                pole[x,y] = 2;
                Console.WriteLine("Nie trafiłeś");
            }
        }
        static void rysujpole(int[,] pole)
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
            for (int y = 0; y < pole.GetLength(1); y++)
            {
                Console.Write(y + " ");
                for (int x = 0; x < pole.GetLength(0); x++)
                {
                    switch (pole[x, y])
                    {
                        case 0:
                            Console.Write("~ ");
                            break;
                        case 1:
                            Console.Write("■ ");
                            break;
                        case 2:
                            Console.Write("o ");
                            break;
                        case 3:
                            Console.Write("X ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
