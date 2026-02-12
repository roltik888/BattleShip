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
            int[,] polegracza = new int[w, h];
            int[] flota = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            int[,] widokgracza = new int[10, 10];
            int wybór = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz opcje: "
                                + "\n1. Gra w statki67"
                                + "\n2. Gra w statki (2 osoby ) (nie działa)"
                                + "\n3. Zasady"
                                + "\n4. Koniec");
                wybór = int.Parse(Console.ReadLine());
                switch (wybór)
                {
                    case 1:
                        Console.Clear();
                        foreach (int statekdlugosc in flota)
                        {
                            Postawstatki(pole, statekdlugosc);
                        }
                        foreach (int statekdlugosc in flota)
                        {
                            Console.Clear();
                            Console.WriteLine("Jak stawisz statki spoczątku masz statki rozmiaru 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 (kiedy stawisz statki pionowo to kwadrat który wybrałeś jest pierwszy pozostałe idą do dołu a kiedy poziomo do pierwszy kwadrat statku jest tam gdzie wpisałeś a inni do prawej strony)");
                            Postawstatkisam(polegracza, statekdlugosc);
                            rysujpole(polegracza);
                        }
                        while (true)
                        {
                            Console.Clear();
                            DrawLogo();
                            Console.WriteLine("Pole kompa");
                            rysujpole(widokgracza);
                            strzal(pole, widokgracza);

                            if (Wygrana(pole))
                            {
                                Console.WriteLine("Win"); break;
                            }
                            click(w);
                            Console.Clear(); DrawLogo();
                            Console.WriteLine("Twoje pole");
                            rysujpole(polegracza);
                            strzalkompa(polegracza);

                            if (Wygrana(polegracza))
                            {
                                Console.WriteLine("Nawet kompa nie wygrales..."); break;
                            }
                            click(w);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("NIE DZIAŁA!!!");
                        click(w);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Statki to gra dla dwóch osób, w której celem jest zatopienie wszystkich statków przeciwnika. Każdy gracz ustawia potajemnie na planszy 10×10 swoje statki (1 czteromasztowiec, 2 trójmasztowce, 3 dwumasztowce i 4 jednomasztowce), pionowo lub poziomo, tak aby się nie dotykały. Gracze strzelają na zmianę, podając współrzędne pól; przeciwnik informuje, czy był to strzał chybiony, trafiony lub zatopiony. Po trafieniu strzela się dalej, a po pudle kolej przechodzi na drugiego gracza. Wygrywa ten, kto pierwszy zatopi wszystkie statki przeciwnika.");
                        click(w);
                        break;
                    case 4:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Error");
                        break;
                }
            } while (wybór != 4);



















        }
        static void click(int w)
        {
            Console.WriteLine("1.Kontynuj"
                    + "\n2.Koniec");
            w = int.Parse(Console.ReadLine());
            switch (w)
            {
                case 1:
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        static void Postawstatkisam(int[,] pole, int dlugosc)
        {
            bool jest = false;
            while (!jest)
            {
                Console.WriteLine("Wpisz x 0-10");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Wpisz y 0-10");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Wpisz kierunek 0-1");
                int kierunek = int.Parse(Console.ReadLine());
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
        private static void strzalkompa(int[,] polegracza)
        {
            int x, y;
            do
            {
                x = xd.Next(0, 10);
                y = xd.Next(0, 10);
            }
            while (polegracza[x, y] != 0 && polegracza[x, y] != 1);

            if (polegracza[x, y] == 1)
            {
                polegracza[x, y] = 3;
                Console.WriteLine("Komputer trafil");
            }
            else
            {
                polegracza[x, y] = 2;
                Console.WriteLine("Komputer miss");
            }
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
        static void strzal(int[,] pole, int[,] widokgracza)
        {
            Console.WriteLine("Podaj X: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y: ");
            int y = int.Parse(Console.ReadLine());
            if (pole[x, y] == 1)
            {
                pole[x, y] = 3;
                widokgracza[x, y] = 3;
                Console.WriteLine("Trafiles");
                czyzabity(pole, x, y);
            }
            else if (pole[x, y] == 0)
            {
                pole[x, y] = 2;
                widokgracza[x, y] = 2;
                Console.WriteLine("Nie trafiles");
            }
        }
        static bool Wygrana(int[,] p)
        {
            int t = 0; for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (p[i, j] == 3) t++;
            return t >= 20;
        }
        static void czyzabity(int[,] pole, int x, int y)
        {
            bool zyje = false;

            int sx = x + 1;
            while (sx < 10 && (pole[sx, y] == 1 || pole[sx, y] == 3))
            {
                if (pole[sx, y] == 1) zyje = true;
                sx++;
            }
            sx = x - 1;
            while (sx >= 0 && (pole[sx, y] == 1 || pole[sx, y] == 3))
            {
                if (pole[sx, y] == 1) zyje = true;
                sx--;
            }
            int sy = y + 1;
            while (sy < 10 && (pole[x, sy] == 1 || pole[x, sy] == 3))
            {
                if (pole[x, sy] == 1) zyje = true;
                sy++;
            }
            sy = y - 1;
            while (sy >= 0 && (pole[x, sy] == 1 || pole[x, sy] == 3))
            {
                if (pole[x, sy] == 1) zyje = true;
                sy--;
            }
            if (!zyje)
            {
                Console.WriteLine("Zabity statek");

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
