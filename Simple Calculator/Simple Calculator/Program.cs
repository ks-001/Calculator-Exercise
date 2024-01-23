using System.Text.RegularExpressions;

string[] GetExpression()
{
    bool validExpression = false;

    string[] substrings = null;

    Console.WriteLine("Please enter an expression: ");

    while (!validExpression)
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"^(\d+)\s*([+\-*/])\s*(\d+)$");

        substrings = regex.Split(input);

        if (substrings.Length <= 1)
        {
            Console.WriteLine("Please enter an expression of the form a+b, a/c etc where a and b are integers.");
            continue;
        }
        validExpression = true;
    }

    return substrings;

}

double ComputeResult(string[] _expression)
{
    double result;

    double leftOperand = Convert.ToDouble(_expression[1]);

    string operation = _expression[2];

    double rightOperand = Convert.ToDouble(_expression[3]);


    switch (operation)
    {
        case "+":
            result = leftOperand + rightOperand;
            break;
        case "-":
            result = leftOperand - rightOperand;
            break;
        case "*":
            result = leftOperand * rightOperand;
            break;
        case "/":
            if (rightOperand == 0)
            {
                Console.WriteLine("Unable to divide by zero.");
                result = double.NaN;
                break;
            }
            result = leftOperand / rightOperand;
            break;
        default:
            result = double.NaN;
            break;
    }

    return result;
}

Console.WriteLine("---Calculator---");

bool stopRunning = false;

while (!stopRunning)
{
    string[] expression = GetExpression();

    double result = ComputeResult(expression);

    if (!Double.IsNaN(result))
    {
        Console.WriteLine(result.ToString());
    }

    Console.WriteLine("Press x then Enter to exit, or Enter on its own to continue.");

    if (Console.ReadLine() == "x")
    {
        stopRunning = true;
    }

}
