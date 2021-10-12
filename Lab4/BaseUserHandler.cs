using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class BaseUserHandler
    {
        private List<string> savedlines;
        public AppLic userLicense { get; }
        public BaseUserHandler(AppLic license)
        {
            userLicense = license;
            savedlines = new List<string>();
        }
        public virtual void SaveInfo(params string[] parameters)
        {
            AppLic.Allower(userLicense.License);
            switch (userLicense.License)
            {
                case 0:
                    {
                        if (savedlines.Count + parameters.Count() > 1)
                        {
                            Console.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                            return;
                        }
                        savedlines.AddRange(parameters);
                        break;
                    }
                case 1:
                    {
                        if (savedlines.Count + parameters.Count() > 10)
                        {
                            Console.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
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
        public virtual void StartGame()
        {
            AppLic.Allower(userLicense.License);
            Console.CursorVisible = false;
            Console.Clear();
            int[] currcoordinate = new int[2];
            currcoordinate[0] = Console.WindowWidth / 2;
            currcoordinate[1] = Console.WindowHeight / 2;
            Console.SetCursorPosition(currcoordinate[0], currcoordinate[1]);
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
            while(helper)
            {
                
                
                Console.Clear();
                Console.SetCursorPosition(currcoordinate[0], currcoordinate[1]);
                Console.Write('+');
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        {
                            numberofmoves++;
                            currcoordinate[1]--;
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            numberofmoves++;
                            currcoordinate[1]++;
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            numberofmoves++;
                            currcoordinate[0]--;
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            numberofmoves++;
                            currcoordinate[0]++;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            helper = false;
                            return;
                        }                      
                }
                if (numberofmoves >= maxnumberofmoves)
                {
                    Console.Clear();
                    return;                    
                }
            }
            Console.CursorVisible = true;
        }
        public virtual void CreatetxtFile(string filecontent, string filename = "privatefiles")
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
                Console.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                return;
            }
        }

    }
}
