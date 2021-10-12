using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab4
{
    class FlexibleUserHandler : BaseUserHandler
    {
        public List<string> savedlines { private set; get; }
        public FlexibleUserHandler(AppLic license) : base(license)
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
                            if (savedlines.Count >= 1)
                            {
                                savedlines.RemoveAt(0);
                            }
                            savedlines.Add(parameters.Last());
                            return;
                        }
                        savedlines.AddRange(parameters);
                        break;
                    }
                case 1:
                    {
                        if (savedlines.Count + parameters.Count() > 10)
                        {
                            
                            if (savedlines.Count < 10)
                            {
                                int lineLengthHelper = 10 - savedlines.Count;
                                for (int i = 0; i < lineLengthHelper; i++)
                                {
                                    savedlines.Add(parameters.ElementAt(i));
                                }
                                for (int i = 0; i < lineLengthHelper; i++)
                                {
                                    parameters[i] = null;
                                }
                            }
                            int SavedLinesIndex = 0;
                            int countHelper = 0;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                if (countHelper == 10)
                                {
                                    countHelper = 0;
                                    SavedLinesIndex = 0;
                                }
                                if (parameters[i] != null)
                                {
                                    countHelper++;
                                    savedlines[SavedLinesIndex] = parameters[i];
                                }
                            }
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
                            Console.Clear();
                            helper = false;
                            return;
                        }
                }
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
