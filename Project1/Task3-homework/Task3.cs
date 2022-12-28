using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task3_homework
{
    internal class Task3
    {
        public static void Runner()
        {
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 1:");
            var num = 20;
            num += 5;
            Console.WriteLine("Variable {0}", num);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 2:");
            int n = int.Parse(Console.ReadLine());
            int years = n / 365;
            int months = (n % 365) / 31;
            int days = (n % 365) - months * 31;
            Console.WriteLine("years: {0}, months: {1}, days: {2}", years, months, days);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 3:");
            Console.WriteLine("Enter any number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number += 2);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 4:");
            short numShort = 34;
            byte numByte = 4;
            string inString = "Hello!";
            char inChar = 'R';
            float numFloat = 23.093433222f;
            int numInt = 40000;
            bool isAlive = true;
            byte numByte1 = 0;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 5:");
            Console.WriteLine("Enter value:");
            var input = Console.ReadLine();
            try
            {
                if (short.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is short type");
                }
                else if (ulong.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is ulong type");
                }
                else if (char.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (double.TryParse(input, out _))
                {
                    Console.WriteLine($"{input} is double type");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("data type is not valid");
            }
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 6:");
            var minusInput = 5;
            minusInput *= 7;
            minusInput--;

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 7:");
            Console.WriteLine("Enter any number:");
            int input1 = int.Parse(Console.ReadLine());
            if (input1 % 2 == 0)
            {
                Console.WriteLine("entered number is even");

            }
            else
            {
                Console.WriteLine("entered value is odd");
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 8:");
            Console.WriteLine("Enter a number:");
            int A = int.Parse(Console.ReadLine());
            if ((A < 50 && A != 37 && A >= 32) || A == 0 || A == 15)
            {
                Console.WriteLine("Working");
            }
            else
            {
                Console.WriteLine("Not Working");
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task 9:");
            Console.WriteLine("Enter number 1:");
            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number 2:");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an arithmetic operation (+, -, *, /)");
            char symbol = char.Parse(Console.ReadLine());
            switch (symbol)
            {
                case '+':
                    Console.WriteLine("number1 + number2 = " + number1 + number2);
                    break;
                case '-':
                    Console.WriteLine("number1 - number2 = " + (number1 - number2));
                    break;
                case '*':
                    Console.WriteLine("number1 * number2 = " + (number1 * number2));
                    break;
                case '/':
                    Console.WriteLine("number1 / number2 = " + (number1 / number2));
                    break;
                default:
                    Console.WriteLine("Enter valid operation!");
                    break;
            }

        }
    }
}
