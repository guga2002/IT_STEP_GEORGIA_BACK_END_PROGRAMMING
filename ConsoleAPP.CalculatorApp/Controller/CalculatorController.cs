using CalculatorApp.CalculatorService;

namespace CalculatorApp.Controller
{
    public class CalculatorController
    {
       private readonly Icalculator calc;

        public CalculatorController()
        {
            calc = new CalculaterServicess();
        }
        public void AddNumber()
        {
            var res = Helper.HelperClass.Readnumbers();
            calc.AddNumber(res.Item1, res.Item2);
        }

        public void Substract()
        {
            var res = Helper.HelperClass.Readnumbers();
            calc.Substract(res.Item1, res.Item2);
        }

       public void multiplication()
        {
            var res = Helper.HelperClass.Readnumbers();
            calc.multiplication(res.Item1, res.Item2);
        }

        public void gayofa()
        {
            var res = Helper.HelperClass.Readnumbers();
            calc.gayofa(res.Item1, res.Item2);
        }


    }
}
