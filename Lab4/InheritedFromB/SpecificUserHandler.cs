using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab4
{
    class SpecificUserHandler : BaseUserHandler
    {
        private List<KeyValuePair<ConsoleKey, string>> table;
        public List<string> commentary;
        public SpecificUserHandler(AppLic license) : base(license)
        {
            table = new List<KeyValuePair<ConsoleKey, string>>();
            commentary = new List<string>();
        }
        public override void SaveInfo(params string[] parameters)
        {
            AppLic.Allower(userLicense.License);
            switch (userLicense.License)
            {
                case 0:
                    {
                        if (commentary.Count + parameters.Count() > 1)
                        {
                            Debug.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                            return;
                        }
                        commentary.AddRange(parameters);
                        break;
                    }
                case 1:
                    {
                        if (commentary.Count + parameters.Count() > 10)
                        {
                            Debug.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                            return;
                        }
                        commentary.AddRange(parameters);
                        break;
                    }
                case 2:
                    {
                        commentary.AddRange(parameters);
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
                            table.Add(new KeyValuePair<ConsoleKey, string>(key, "move number " + numberofmoves +
                                ", up " + DateTime.Now));
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            numberofmoves++;
                            currcoordinate[1]++;
                            table.Add(new KeyValuePair<ConsoleKey, string>(key, "move number " + numberofmoves +
                                ", down " + DateTime.Now));
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            numberofmoves++;
                            currcoordinate[0]--;
                            table.Add(new KeyValuePair<ConsoleKey, string>(key, "move number " + numberofmoves +
                                ", left " + DateTime.Now));
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            numberofmoves++;
                            currcoordinate[0]++;
                            table.Add(new KeyValuePair<ConsoleKey, string>(key, "move number " + numberofmoves +
                                ", right " + DateTime.Now));
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
        public override void CreatetxtFile(string filecontent = "GameMoves", string filename = "privatefiles")
        {
            AppLic.Allower(userLicense.License);
            if (userLicense.License == 2)
            {
                using (StreamWriter filestream = new StreamWriter(@"D:\private" + filename))
                {
                    filestream.WriteLine(filecontent);
                    foreach (var pair in table)
                    {
                        filestream.WriteLine(pair.Key + " | " + pair.Value);
                    }
                    string commentary = "";
                    foreach (var line in this.commentary)
                    {
                        commentary += line + ";";
                    }
                    filestream.Write(commentary);
                    filestream.Close();
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попытка выйти за границы доступа лицензии.");
                return;
            }
        }
        public List<KeyValuePair<ConsoleKey, string>> GiveTables(Action method)
        {
            if (method.Method.Name == "KeyMethod" && method.Method.GetGenericMethodDefinition() == typeof(AdvancedUserHandler))
            {
                return table;
            }
            else
                return null;
        }
    }
}
