using CalculatorApp.Controller;

namespace CalculatorApp.context
{
    public class CalculatorContext
    {
        private Dictionary<ConsoleKey, Action> actions;
        private readonly CalculatorController controll;
        public CalculatorContext()
        {
            actions = new Dictionary<ConsoleKey, Action>();
            controll = new CalculatorController();
            loaddate();
        }

        private void loaddate()
        {
            actions.Add(ConsoleKey.Add, controll.AddNumber);
            actions.Add(ConsoleKey.Subtract, controll.Substract);
            actions.Add(ConsoleKey.Divide, controll.gayofa);
            actions.Add(ConsoleKey.Multiply, controll.multiplication);
        }
        public Dictionary<ConsoleKey, Action> GetContext()
        {
            return actions;

        } 
    }
}
