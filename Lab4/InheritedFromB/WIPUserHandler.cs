using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab4
{
    class WIPUserHandler : BaseUserHandler
    {
        private List<string> savedlines;
        public WIPUserHandler(AppLic license) : base(license)
        {
            savedlines = new List<string>();
        }
        public override void SaveInfo(params string[] parameters)
        {
            AppLic.Allower(userLicense.License);
            switch (userLicense.License)
            {
                case 0:
                    {
                        if (savedlines.Count + parameters.Count() > 1)
                        {
                            Debug.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                            return;
                        }
                        savedlines.AddRange(parameters);
                        break;
                    }
                case 1:
                    {
                        if (savedlines.Count + parameters.Count() > 10)
                        {
                            Debug.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                            return;
                        }
                        savedlines.AddRange(parameters);
                        break;
                    }
                case 2:
                    {
                        savedlines.AddRange(parameters);
                        break;
                    }
            }
        }
        public override void StartGame()
        {
            AppLic.Allower(userLicense.License);
            Console.CursorVisible = false;
            Console.Clear();
            int[] currcoordinate = new int[2];
            currcoordinate[0] = Console.WindowWidth / 2;
            currcoordinate[1] = Console.WindowHeight / 2;
            Console.SetCursorPosition(currcoordinate[0], currcoordinate[1]);
            Console.Write('+');
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight / 2);
            Console.Write('+');
            
            bool helper = true;
            int numberofmoves = 0;
            int maxnumberofmoves = 0;
            switch (userLicense.License)
            {
                case 0:
                    {
                        maxnumberofmoves = 10;
                        break;
                    }
                case 1:
                    {
                        maxnumberofmoves = 100;
                        break;
                    }
                case 2:
                    {
                        maxnumberofmoves = int.MaxValue;
                        break;
                    }
            }
            while (helper)
            {
                if (numberofmoves >= maxnumberofmoves)
                {
                    return;
                }
                var key = Console.ReadKey().Key;
                Console.Clear();
                Console.SetCursorPosition(currcoordinate[0], currcoordinate[1]);
                Console.Write('+');

                switch (key)
                {
                    case ConsoleKey.W:
                        {
                            currcoordinate[1]--;
                            numberofmoves++;
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            currcoordinate[1]++;
                            numberofmoves++;
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            currcoordinate[0]--;
                            numberofmoves++;
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            currcoordinate[0]++;
                            numberofmoves++;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            helper = false;
                            return;
                        }
                }
                Console.SetCursorPosition(currcoordinate[0], currcoordinate[1]);
                Console.Write('+');
            }
            Console.CursorVisible = true;
        }
        public override void CreatetxtFile(string filecontent, string filename = "privatefiles")
        {
            AppLic.Allower(userLicense.License);
            if (userLicense.License == 2)
            {
                using (StreamWriter filestream = new StreamWriter(@"D:\private" + filename))
                {
                    filestream.Write(filecontent);
                    filestream.Close();
                }
            }
            else
            {
                Debug.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                return;
            }
        }
    }
}
