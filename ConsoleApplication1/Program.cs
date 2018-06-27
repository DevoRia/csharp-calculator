using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CommandFactory factory = new CommandFactory();
            while (true)
            {
                var operation = ChoseOperation(factory);
                if (operation == null) break;
                double firstNum = getNumber();
                double secondNum = getNumber();
                Console.WriteLine("ВАШ РЕЗУЛЬТАТ: " + operation.Execute(firstNum, secondNum));
            }

            CommandFactory.Command ChoseOperation(CommandFactory factoryCommand)
            {
                Console.WriteLine(
                    "Вітаємо в калькуляторі \n введіть потрібну вам операцію : + - * / \n щоб вийти люба інша клавіша");
                char symbol = Console.ReadKey().KeyChar;
                return factoryCommand.GetCommandBySymbol(symbol);
            }

            double getNumber()
            {
                Console.Write(" Введіть число: ");
                return Convert.ToDouble(Console.ReadLine());
            }
        }
    }

    class CommandFactory
    {
        public Command GetCommandBySymbol(char symbol)
        {
            switch (symbol)
            {
                case '+': return new Summation();
                case '-': return new Subtraction();
                case '*': return new Multiplication();
                case '/': return new Division();
                default: return null;
            }
        }

        internal interface Command
        {
            double Execute(double a, double b);
        }


        class Summation : Command
        {
            public double Execute(double a, double b)
            {
                return a + b;
            }
        }

        class Subtraction : Command
        {
            public double Execute(double a, double b)
            {
                return a - b;
            }
        }

        class Multiplication : Command
        {
            public double Execute(double a, double b)
            {
                return a * b;
            }
        }

        class Division : Command
        {
            public double Execute(double a, double b)
            {
                return a / b;
            }
        }
    }
}
  
