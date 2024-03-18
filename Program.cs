using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp6
{
    class Program
    {
        const int a = 3;

        static string[,] GamePole = new string[a, a];


        static void Display()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write("|" + GamePole[i, j] + "|");
                }
                Console.WriteLine();
                Console.WriteLine("-------");

            }
            //GamePole[0, 2] = "X";
            //GamePole[1, 1] = "X";
            //GamePole[2, 0] = "X";


        }
        static void Default()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    GamePole[i, j] = "&";
                }

            }
        }
        static bool Check(int IndexI, int IndexJ)
        {
            if (GamePole[IndexI, IndexJ] != "X" && GamePole[IndexI, IndexJ] != "0")
            {
                return true;
            }
            return false;
        }
        static bool PCSTEP(string PcFIG)
        {
            Random ran = new Random();
            int IndexI = ran.Next(0, a);
            int IndexJ = ran.Next(0, a);
            bool res = Check(IndexI, IndexJ);

            if (!res)
            {
                PCSTEP(PcFIG);
            }
            else
            {
                GamePole[IndexI, IndexJ] = PcFIG;
            }
            return true;

        }
        static bool GetWiner(string figure)
        {
            int hort;
            int vert;
            int diag = 0;
            int diag2 = 0;
            {
                for (int i = 0; i < a; i++)
                {
                    hort = 0;
                    vert = 0;
                    for (int j = 0; j < a; j++)
                    {
                        if (GamePole[i, j] == figure)
                        {
                            hort++;
                            if (hort == a)
                            {
                                return true;
                            }
                        }
                        if (GamePole[j, i] == figure)
                        {
                            vert++;
                            if (vert == a)
                            {
                                return true;
                            }
                        }
                    }
                    if (GamePole[i, i] == figure)
                    {
                        diag++;
                        if (diag == a)
                        {
                            return true;
                        }
                    }
                    if (GamePole[i, a - 1 - i] == figure)
                    {
                        diag2++;
                        if (diag2 == a)
                        {
                            return true;
                        }

                    }
                }
                return false;

            }
        }
        static bool GetUser(string figure)
        {
            Console.WriteLine("hodi blya");
            int indexI;
            int indexJ;

            while (true)
            {
                Console.WriteLine("hodi blya");
                indexI = -1;
                indexJ = -1;
                var input = Console.ReadLine();
                if (input != null)
                {
                    var mas = input?.Split(',');
                    if (mas.Length == 2)
                    {

                        if (mas[0] != null)
                        {
                            var resindexI = Int32.TryParse(mas[0], out indexI);
                        }
                        if (mas[1] != null)
                        {
                            var resindexI = Int32.TryParse(mas[0], out indexJ);
                        }
                    }
                }
                if (indexI != -1 && indexJ != -1)
                {
                    var resCheck = Check(indexI, indexJ);
                    if (resCheck)
                    {
                        GamePole[indexI, indexJ] = figure;
                        break;
                    }

                }

            }
            var res = GetWiner(figure);
            return res;
        }
        static (string, string) XSF()
        {
            string PcStep = "";
            string UserStep = "";
            while (true)
            {
                Console.WriteLine("виберете чем ходитие ");
                UserStep = Console.ReadLine();
                if (UserStep == "0" || UserStep == "X")
                {
                    PcStep = UserStep == "X" ? "0" : "X";
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный символ. Попробуйте еще раз.");
                }
            }
            return (UserStep, PcStep);

        }






        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;

            Default();
            Display();
            string UserFigeure;
            string PcFigure;
            (UserFigeure, PcFigure) = XSF();

            while (!GetUser(UserFigeure) && !PCSTEP(PcFigure))
            {

                // Здесь можно добавить дополнительный код, если нужно
            }






        }
    }

}



