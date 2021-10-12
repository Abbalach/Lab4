using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class ExtendedPrInfo<T,K,L,P> : PrivateInforation<T,K,L>
    {
        private P FourthField { get; set; }
        public ExtendedPrInfo(T firstfield, K secondfield, L thirdfield, P fourthfield, AppLic license) 
            : base(firstfield, secondfield, thirdfield, license)
        {
            FourthField = fourthfield;
        }
        public ExtendedPrInfo(AppLic license) : base(license)
        {
            FourthField = default;
        }
        public P GetFourthField(int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                return FourthField;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
                return default;
            }
        }
        public void SetFourthField(P content, int code)
        {
            AppLic.Allower(License.License);
            if (code == License.Code)
            {
                FourthField = content;
            }
            else
            {
                Debug.WriteLine("Несовпадение пароля. В доступе отказано");
            }
        }
        override public void GetInfo()
        {
            Debug.WriteLine("Первое поле");
            Debug.WriteLine("Тип: " + FirstField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Второе поле");
            Debug.WriteLine("Тип: " + SecondField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Третье поле");
            Debug.WriteLine("Тип: " + ThirdField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Третье поле");
            Debug.WriteLine("Тип: " + FourthField.GetType());
            Debug.WriteLine("Значение: " + FourthField);
        }
    }
}
