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
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowMassiveElement()
        {
            try
            {
                int[] massive = { 8, 7, 1, 4, 2 };
                Console.WriteLine("Input index of element in massive:");
                string? inputedValue = Console.ReadLine();
                string? checkedValue = inputedValue.Equals(string.Empty) ? null : inputedValue;
                int inputtedNumber = Int32.Parse(checkedValue);
                int massiveElement = massive[inputtedNumber];
                Console.WriteLine($"Massive element that has index {inputedValue} has value {massiveElement}");
            } catch(Exception ex)
            {
                throw;
            }
        }

    }
}
