using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TemporaryInstructions : InstructionsHelper
    {
        sealed override public void InfoDefiner(string userName, int accountsNumber, AppLic license)
        {
            if (this.GetType() != typeof(TemporaryInstructions))
            {
                Debug.WriteLine("type 1 " + userName.GetType().Name);
                Debug.WriteLine("type 2 " + accountsNumber.GetType().Name);
                Debug.WriteLine("type 3 " + license.GetType().Name);
            }

            Debug.WriteLine("Имя " + userName);

            Debug.WriteLine("Номер созданного аккаунта " + accountsNumber);
            if (license.License == 0)
            {
                Debug.WriteLine("Пробная версия, лицензия содержит " +  license.NumberOfPrInfo + " личных вложений");
            }
            if (license.License == 1)
            {
                Debug.WriteLine("Триальная версия, лицензия содержит " + license.NumberOfPrInfo + " личных вложений");
            }
            if (license.License == 2)
            {
                Debug.WriteLine("Лицензионная версия, лицензия содержит " + license.NumberOfPrInfo + " личных вложений");
            }
            
        }
    }
    class InheritedFromTempInst : TemporaryInstructions
    {

    }
}
