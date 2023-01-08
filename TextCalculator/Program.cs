// See https://aka.ms/new-console-template for more information
using TextCalculator;

Console.Clear();

Console.WriteLine("input is a series of assignment expressions");

var inputs = new List<string>();

var input = Console.ReadLine();

while (input != string.Empty)
{
    inputs.Add(input);
    input = Console.ReadLine();

}

if (inputs.Any())
{
    var calculator = new Calculator();

    try
    {
        var result = calculator.Calc(ExpressionBuilder.Build(inputs));

        Console.WriteLine(Printer.Print(result));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.ReadLine();