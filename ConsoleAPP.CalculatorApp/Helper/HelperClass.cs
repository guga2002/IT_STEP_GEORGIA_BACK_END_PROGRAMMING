using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Helper
{
    public static class HelperClass
    {

        public static  (int ,int) Readnumbers()
        {
            try
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("enter first number");
                int a = int.Parse(Console.ReadLine() ?? "-1");
                Console.WriteLine("enter Second Number ");
                int b = int.Parse(Console.ReadLine() ?? "-1");
                (int, int) shedeg = (a, b);
                Console.ResetColor();
                return shedeg;
            }
            catch (InvalidCastException exp)
            {
                if (exp is not null)
                {
                    throw exp;
                }
            }
            return (0, 0);
        }
    }
}
