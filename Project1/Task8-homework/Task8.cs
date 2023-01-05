using Project1.Task7_homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task8_homework
{
    public class Task8
    {
        public static void Runner()
        {
            try
            {
                ShowMassiveElement();
            }
            catch (IndexOutOfRangeException ex)
            {
                ExceptionMethod(ex);
            }
            catch (FormatException ex)
            {
                ExceptionMethod(ex);
            }
        }

        public static void ExceptionMethod(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        public static void ShowMassiveElement()
        {
            try
            {
                int[] massive = { 8, 7, 1, 4, 2 };
                Console.WriteLine("Input index of element in massive:");
                string? inputedValue = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputedValue))
                 {
                    string? checkedValue = inputedValue;
                    int inputtedNumber = int.Parse(checkedValue);
                    int massiveElement = massive[inputtedNumber];
                    Console.WriteLine($"Massive element that has index {inputedValue} has value {massiveElement}");
                }
                else
                {
                    Console.WriteLine("Empty string");
                }
                

            } catch(Exception ex)
            {
                throw;
            }
        }

    }
}
