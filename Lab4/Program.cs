using System;
using System.Diagnostics;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AppLic.ShowKeys();
            AppLic license = new AppLic(int.Parse(Console.ReadLine()));

            TemporaryInstructions temporaryInstructions = new TemporaryInstructions();
            temporaryInstructions.InfoDefiner("Name 1 ", 2, license);
            InheritedFromTempInst inherited = new InheritedFromTempInst();
            inherited.InfoDefiner("Name 2 ", 2, license);

            AdvancedUserHandler.GetInheritedInfo();

            PrivateInforation<int, string, AppLic> privateInforation = new PrivateInforation<int, string, AppLic>(10, "text", license, license);
            privateInforation.GetInfo();
            ExtendedPrInfo<TimeSpan, byte, bool, char> extendedPrInfo = new ExtendedPrInfo<TimeSpan, byte, bool, char>(TimeSpan.FromSeconds(123), 12, true, '$',license);
            extendedPrInfo.GetInfo();
            LimitedPrInfo<double, Action> limitedPrInfo = new LimitedPrInfo<double, Action>(1.1,() => Console.WriteLine("some info"),license);
            limitedPrInfo.GetInfo();


            Console.ReadKey(); 
        }
    }
}
