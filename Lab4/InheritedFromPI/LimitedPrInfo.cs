using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class LimitedPrInfo<T,K> : PrivateInforation<T,K, HelperClass>
    {
        public LimitedPrInfo(T firstfield, K secondfield, AppLic license) 
            : base(firstfield,secondfield,(new HelperClass() {code = "<rGH**JM--5 2sf>dsnnn}?2454F222" } ),license)
        {
            
        }
        protected readonly string LimitedPrCode = "<rGH**JM--5 2sf>dsnnn}?2454F222";
        public void SetFirstField(T content)
        {
            AppLic.Allower(License.License);
            FirstField = content;
        }
        public void SetSecondField(K content)
        {
            AppLic.Allower(License.License);
            SecondField = content;
        }
        public T GetFirstField()
        {
            AppLic.Allower(License.License);
            return FirstField;           
        }
        public K GetSecondField()
        {
            AppLic.Allower(License.License);
            return SecondField;        
        }
        public void SetThirdField(HelperClass content)
        {
            AppLic.Allower(License.License);
            Debug.WriteLine("Данное поле вне доступа. Преобретите лицензию.");
        }
        public HelperClass GetThirdField()
        {
            Debug.WriteLine("Данное поле вне доступа. Преобретите лицензию.");
            return null;
        }
        override public void GetInfo()
        {
            Debug.WriteLine("Первое поле");
            Debug.WriteLine("Тип: " + FirstField.GetType());
            Debug.WriteLine("Значение: " + FirstField);

            Debug.WriteLine("Второе поле");
            Debug.WriteLine("Тип: " + SecondField.GetType());
            Debug.WriteLine("Значение: " + FirstField);
        }
    }
}
