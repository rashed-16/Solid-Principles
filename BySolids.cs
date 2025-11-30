using System;

namespace SOLID_Calculator
{
    // ================================
    // Interface: Operation Contract
    // (I – Interface Segregation Principle)
    // ================================
    public interface IOperation
    {
        double Execute(double a, double b);
    }

    // ================================
    // Concrete Operations
    // (S – Single Responsibility Principle)
    // (O – Open/Closed Principle)
    // Each class handles ONE operation only.
    // New operations can be added without modifying existing ones.
    // ================================
    public class AddOperation : IOperation
    {
        public double Execute(double a, double b) => a + b;
    }

    public class SubtractOperation : IOperation
    {
        public double Execute(double a, double b) => a - b;
    }

    public class MultiplyOperation : IOperation
    {
        public double Execute(double a, double b) => a * b;
    }

    public class DivideOperation : IOperation
    {
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }

    public class PowerOperation : IOperation
    {
        public double Execute(double a, double b) => Math.Pow(a, b);
    }

    // ================================
    // Calculator Class
    // (D – Dependency Inversion Principle)
    // Depends on abstraction (IOperation), not concrete classes.
    // Operation is injected through constructor (Dependency Injection)
    // ================================
    public class SolidCalculator
    {
        private readonly IOperation _operation;

        public SolidCalculator(IOperation operation)
        {
            _operation = operation;
        }

        public double Calculate(double a, double b)
        {
            return _operation.Execute(a, b);
        }
    }
}
