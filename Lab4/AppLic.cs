using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class AppLic
    {
        private static readonly int[] Keys;
        public readonly byte License;
        public readonly int Code;
        public int NumberOfPrInfo { get; private set; }
        static AppLic()
        {
            Random random = new Random();
            Keys = new int[20];
            for (int i = 0; i < 10; i++)
            {
                Keys[i] = random.Next(10000000, 99999999);
            }
            for (int i = 10; i < 20; i++)
            {
                Keys[i] = random.Next(1000, 9999);
            }         
        }
        public AppLic(int key = -1)
        {
            NumberOfPrInfo = 0;
            Code = key;
            if (key == -1)
            {
                License = 0;
                return;
            }
            if (key <= 0 || key.ToString().Length != 8 && key.ToString().Length != 4)
            {
                Debug.WriteLine("Введен неподходящий формат ключа.");
                return;
            }
            if (Keys.Contains(key) && key.ToString().Length == 4)
            {
                License = 1;
                return;
            }
            if (Keys.Contains(key) && key.ToString().Length == 8)
            {
                License = 2;
                return;
            }
            
        }
        public static void ShowKeys()
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                Console.WriteLine(Keys[i]);
            }
        }
        public static void AllowTrial()
        {
            Debug.WriteLine("Триальный режим");
        }
        public static void AllowCommon()
        {
            Debug.WriteLine("Бесплатная версия");
        }
        public static void AllowPro()
        {
            Debug.WriteLine("Платная версия");
        }
        public static void Allower(byte license)
        {
            switch (license)
            {
                case 0: { AllowCommon(); break; }
                case 1: { AllowTrial(); break; }
                case 2: { AllowPro(); break; }
            }
        }
        public bool NewPrInfoAdded(string privateCode)
        {
            Allower(License);
            if (License == 0)
            {
                if (privateCode == "sv4d65 + ^(*)@;[CkopSND: W}{0" || privateCode == "<rGH**JM--5 2sf>dsnnn}?2454F222")
                {
                    if (privateCode == "sv4d65 + ^(*)@;[CkopSND: W}{0")
                    {
                        if (NumberOfPrInfo >= 1)
                        {
                            return false;
                        }
                        else
                        {
                            NumberOfPrInfo++;
                            return true;
                        }
                    }
                    if (privateCode == "<rGH**JM--5 2sf>dsnnn}?2454F222")
                    {
                        if (NumberOfPrInfo >= 3)
                        {
                            return false;
                        }
                        else
                        {
                            NumberOfPrInfo++;
                            return true;
                        }
                    }
                    return default;
                }
                else
                {
                    return false;
                }
            }
            else
                return true;
            
        }
    }
}
