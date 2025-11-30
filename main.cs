using System;

namespace SOLID_Calculator
{
    // ================================
    // Program Entry Point
    // Uses Strategy Pattern to select operation at runtime.
    // ================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter first number:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("\nChoose operation: add / sub / mul / div / pow");
            string op = Console.ReadLine().Trim().ToLower();

            // Choosing the strategy (operation)
            IOperation selectedOperation = op switch
            {
                "add" => new AddOperation(),
                "sub" => new SubtractOperation(),
                "mul" => new MultiplyOperation(),
                "div" => new DivideOperation(),
                "pow" => new PowerOperation(),
                _ => null
            };

            if (selectedOperation == null)
            {
                Console.WriteLine("Invalid operation selected.");
                return;
            }

            // Passing the selected operation to the calculator (Dependency Injection)
            SolidCalculator calculator = new SolidCalculator(selectedOperation);

            double result = calculator.Calculate(a, b);
            Console.WriteLine($"\nResult = {result}");
        }
    }
}
