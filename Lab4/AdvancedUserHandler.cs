using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class AdvancedUserHandler
    {
        public readonly BaseUserHandler[] infos;
        public AdvancedUserHandler(BaseUserHandler info)
        {
            infos = new BaseUserHandler[] { info };
        }
        public AdvancedUserHandler(BaseUserHandler maininfo, BaseUserHandler minorinfo)
        {
            infos = new BaseUserHandler[] { maininfo, minorinfo };
        }
        public AdvancedUserHandler(BaseUserHandler maininfo, BaseUserHandler minorinfo, BaseUserHandler someinfo)
        {
            infos = new BaseUserHandler[] { maininfo, minorinfo, someinfo };
        }
        
        static public void GetInheritedInfo()
        {
            Debug.WriteLine("Класс FlexibleUserHandler");
            foreach (var prop in typeof(FlexibleUserHandler).GetProperties())
            {
                Console.WriteLine("Свойство " + prop.Name + " типа " + prop.PropertyType);
            }
            Debug.WriteLine("Класс WIPUserHandler");
            foreach (var prop in typeof(WIPUserHandler).GetProperties())
            {
                Debug.WriteLine("Свойство " + prop.Name + " типа " + prop.PropertyType);
            }
            Debug.WriteLine("Класс SpecificUserHandler");
            foreach (var prop in typeof(SpecificUserHandler).GetProperties())
            {
                Debug.WriteLine("Свойство " + prop.Name + " типа " + prop.PropertyType);
            }
        }
        public void GetUserInfo()
        {
            for (int i = 0; i < infos.Length; i++)
            {
                switch (infos[i].userLicense.License)
                {
                    case 0:
                        {
                            Debug.WriteLine("Бесплатная версия");
                            break;
                        }
                    case 1:
                        {
                            Debug.WriteLine("Триальный режим");
                            break;
                        }
                    case 2:
                        {
                            Debug.WriteLine("Платная версия");
                            break;
                        }
                }
                if (i == 0)
                    Debug.WriteLine("Первостепенный аккаунт");
                if (i == 1)
                    Debug.WriteLine("Второстепенный аккаунт");
                if (i == 2)
                    Debug.WriteLine("Третьестепенный аккаунт");

                if (infos[i].GetType() == typeof(SpecificUserHandler))
                {
                    var tables = ((SpecificUserHandler)infos[i]).GiveTables(KeyMethod);
                    foreach (var table in tables)
                    {
                        Debug.WriteLine(table.Value);
                    }
                }
                if (infos[i].GetType() == typeof(FlexibleUserHandler))
                {
                    Debug.WriteLine("Сохраненная информация");
                    var lines = ((FlexibleUserHandler)infos[i]).savedlines;
                    foreach (var line in lines)
                    {
                        Debug.WriteLine(line);
                    }
                }
            }
        }
        private void KeyMethod()
        {

        }
    }
}
