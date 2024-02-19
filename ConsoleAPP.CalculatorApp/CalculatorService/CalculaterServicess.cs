
namespace CalculatorApp.CalculatorService
{
    public class CalculaterServicess:Icalculator
    {
        public void AddNumber(int a, int b)
        {
            Console.WriteLine($"{a} + {b} = {a+b}");
        }
        public void Substract(int a, int b)
        {
            Console.WriteLine($"{a} - {b} = {a - b}");
        }
        public void multiplication(int a, int b)
        {
            Console.WriteLine($"{a} * {b} = {a * b}");
        }
        public void gayofa(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException(" B is zero , we can not perform operations");
            Console.WriteLine($"{a} / {b} = {a / b}");
        }
    }
}
