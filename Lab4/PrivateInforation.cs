using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    sealed class HelperClass {  public string code { set; get; }  }
    class PrivateInforation<T,K,L>
    {       
        protected T FirstField { set; get; }
        protected K SecondField { set; get; }
        virtual protected L ThirdField { set; get; }
        protected AppLic License { get; }
        protected readonly string PrivateCode = "sv4d65+^(*)@;[CkopSND :W}{0";

        public PrivateInforation(T firstfield, K secondfield, L thirdfield, AppLic license)
        {
            if (thirdfield.GetType() != typeof(HelperClass))
            {
                if (license.NewPrInfoAdded(PrivateCode))
                {
                    FirstField = firstfield;
                    SecondField = secondfield;
                    ThirdField = thirdfield;
                    License = license;
                }
                else
                {
                    Debug.WriteLine("Превышено количество доступных приватных информаций");
                    return;
                }
            }
            else
            {
                if (license.NewPrInfoAdded(  ((HelperClass)(object)(thirdfield)).code)  )
                {
                    FirstField = firstfield;
                    SecondField = secondfield;
                    ThirdField = thirdfield;
                    License = license;
                }
                else
                {
                    Console.WriteLine("Превышено количество доступных приватных информаций");
                    return;
                }
            }
            
        }
        public PrivateInforation(AppLic license)
        {
            if (license.NewPrInfoAdded(PrivateCode))
            {
                FirstField = default;
                SecondField = default;
                ThirdField = default;
                License = license;
            }
            else
            {
                Debug.WriteLine("Превышено количество доступных приватных информаций");
                return;
            }
        }

        public void SetFirstField(T content, int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                FirstField = content;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
            }
        }
        public void SetSecondField(K content, int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                SecondField = content;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
            }
        }
        virtual public void SetThirdField(L content, int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                ThirdField = content;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
            }
        }

        public T GetFirstField(int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                return FirstField;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
                return default;
            }
        }
        public K GetSecondField(int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                return SecondField;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
                return default;
            }
        }
        virtual public L GetThirdField(int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                return ThirdField;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
                return default;
            }
        }

        virtual public void GetInfo()
        {
            AppLic.Allower(License.License);
            Debug.WriteLine("Первое поле");
            Debug.WriteLine("Тип: " + FirstField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Второе поле");
            Debug.WriteLine("Тип: " + SecondField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Третье поле");
            Debug.WriteLine("Тип: " + ThirdField.GetType());
            Debug.WriteLine("Значение: " + FirstField);
        }
    }
}
