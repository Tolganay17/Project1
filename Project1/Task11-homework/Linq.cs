using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task11_homework
{
    public class Linq
    {
        public static void Runner()
        {
            //1.Write a program in C# Sharp to show how the three parts of a query operation execute. 
            //Expected Output: The numbers which produce the remainder 0 after divided by 2 are: 0 2 4 6 8

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var myLinq = numbers.Where(x => x % 2 == 0);
            Console.Write("The numbers which produce the remainder 0 after divided by 2 are :");
            foreach (var l in myLinq)
            {
                Console.Write(l + " ");
            }
            Console.WriteLine();

            //2.Create a list of numbers: 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14.Write a program in C# Sharp to find the positive numbers within the range of 1 to 11 from a list of numbers using two WHERE conditions in LINQ Query.
            var list = new List<int>() { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
            myLinq = list.Where(x => x > 0 && x < 11);
            foreach (var l in myLinq)
            {
                Console.Write(l + " ");
            }
            //3.Write a program in C# Sharp to find the number of an array and the square of each number. 
            //Expected Output:
            //{ Number = 9, SqrNo = 81 }
            //{ Number = 8, SqrNo = 64 }
            //{ Number = 6, SqrNo = 36 }
            //{ Number = 5, SqrNo = 25 }
            Console.WriteLine(" ");
            int[] myArray = { 9, 8, 6, 5 };
            var myLin = myArray.Select((x, sqr) => new { x, sqr = x * x });
            foreach (var l in myLin)
            {
                Console.WriteLine(l);
            }
            //4.Write a program in C# Sharp to display the number and frequency of numbers from the given array.Expected Output :
            //The number and the Frequency are :
            //Number 5 appears 3 times
            //Number 9 appears 2 times
            //Number 1 appears 1 times
            Console.WriteLine("\nNumber and frequency: ");
            int[] myArray1 = { 5, 5, 5, 9, 9, 1 };
            var myLin1 = myArray1.GroupBy(g => g).Where(g => g.Count() > 0).Select((g, x) => new { g.Key, g = g.Count() });
            foreach (var l in myLin1)
            {
                Console.WriteLine(l);
            }
            // Write a program in C# Sharp to find the string which starts and ends with a specific character.
            //Test Data:
            //The cities are: 'ROME', 'LONDON', 'NAIROBI', 'CALIFORNIA', 'ZURICH', 'NEW DELHI', 'AMSTERDAM', 'ABU DHABI', 'PARIS'
            //Input starting character for the string : A
            //Input ending character for the string : M
            //Expected Output :
            //The city starting with A and ending with M is : AMSTERDAM
            Console.WriteLine("\nMust be Amsterdam: ");

            var listOfStrings = new List<string> { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            var myLinq2 = listOfStrings.Where(x => x.StartsWith('A')).Where(x => x.EndsWith('M'));
            foreach (var l in myLinq2)
            {
                Console.WriteLine(l);
            }
            //6.Write a program in C# Sharp to display the top n-th records
            //  Test Data:
            //  The members of the list are :5, 7, 13, 24, 6, 9, 8, 7
            //  How many records do you want to display ? : 3
            //  Expected Output :
            //  The top 3 records from the list are: 24, 13, 9
            var myList1 = new List<int> { 5, 7, 13, 24, 6, 9, 8, 7 };
            myList1.Sort();
            myList1.Reverse();
            Console.WriteLine("\nHow many records do you want to display?");
            var records = int.Parse(Console.ReadLine());
            foreach (var item in myList1.Take(records))
            {
                Console.WriteLine(item);
            }
            //7.Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            //  Expected Output:
            //  Here is the arranged list:
            //  ROME
            //  PARIS
            //  LONDON
            //  ZURICH
            //  NAIROBI
            //  ABU DHABI
            //  AMSTERDAM
            //  NEW DELHI
            //  CALIFORNIA
            var listOfCities = new List<string> { "ROME", "PARIS", "LONDON", "ZURICH", "NAIROBI", "ABU DHABI", "AMSTERDAM", "NEW DELHI", "CALIFORNIA" };
            var myLinq3 = listOfCities.OrderBy(x => x.Length).ThenBy(x => x);
            Console.WriteLine("\nCities:");
            foreach (var l in myLinq3)
            {
                Console.WriteLine(l);
            }
            //8.Write a program in C# Sharp to arrange the distinct elements in the list in ascending order.
            //  Expected Output:
            //  Biscuit
            //  Brade
            //  Butter
            //  Honey
            var listOfElements = new List<string> { "Biscuit", "Honey", "Brade", "Honey", "Butter", "Honey","Brade" };
            var myLinq4 = listOfElements.Distinct().OrderBy(x => x);
            Console.WriteLine("\nDistinct elements:");
            foreach (var l in myLinq4)
            {
                Console.WriteLine(l);
            }









        }
    }
}
