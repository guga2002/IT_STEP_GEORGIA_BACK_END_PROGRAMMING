using OOP.StudentManagementSystemApp;
using OOP.StudentManagementSystemApp.Menu;

string condition = "";
do
{
    try
    {
        Console.Clear();
        var res = MenuContext.Getchoice();

        MenuContext.operations[res].Invoke();

        Console.WriteLine("want use again ? Y/N");
        condition = Console.ReadLine();
    }
    catch (Exception exp)
    {
        Console.WriteLine(exp.Message);
    }
    finally
    {
        MenuContext.Destroyer();
    }

} while (condition == "Y");