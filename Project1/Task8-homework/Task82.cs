using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task8_homework
{
    public class Task82
    {
        public static void Runner()
        {
            try
            {
                AgeChecker();
            }catch(CustomException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void AgeChecker()
        {
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            if(age == 18)
            {
                throw new CustomException();
            }
            Console.WriteLine("Welcome!");
        }
    }
    public class CustomException :Exception
    {
        public CustomException(): base("Age should not be 18!")
        {

        }
    }
}
