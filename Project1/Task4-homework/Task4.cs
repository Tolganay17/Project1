using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task4_homework
{
    internal class Task4
    {
        public static void Runner()
        {
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 4:");
            int[] array = { 3, 5, 9, 8, 15 };
            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                product *= array[i];

                Console.WriteLine(product);
            }




            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 5:");
            int n = 2048;
            int count = 0;
            while (n > 10)
            {
                n /= 2;
                count++;
            }
            Console.WriteLine(count);


            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 6:");

            string[] arrayOfStr = { "Mila", "Kika", "Labas", "Sun" };
            for (int i = 0; i < arrayOfStr.Length; i++)
            {
                if (arrayOfStr[i] == "Labas")
                {
                    Console.WriteLine("Hello {0}", arrayOfStr[i]);
                    break;
                }
            }



            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 7:");
            int[] array1 = { 3, 5, 9, 15, 8 };
            int max = 0;
            int min = array1[0];
            for (int i = 0; i < array1.Length; i++)
            {

                if (array1[i] > max)
                {
                    max = array1[i];
                }
                if (array1[i] < min)
                {
                    min = array1[i];
                }
            }
            Console.WriteLine("maz = {0}, min = {1}", max, min);


            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 8:");
            int[] array2 = { 3, 14, 9, 15, 8 };
            int temp = 0;

            for (int i = 0; i < array2.Length - 1; i++)
            {
                for (int j = i + 1; j < array2.Length; j++)
                {
                    if (array2[j] < array2[i])
                    {
                        temp = array2[i];
                        array2[i] = array2[j];
                        array2[j] = temp;
                    }

                }

            }
            foreach (int item in array2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 9:");
            int mult = 1;


            for (int i = 1; i < 11; i++)
            {
                mult *= i;
                Console.WriteLine(mult);
            }


            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 10:");
            int[,] array4 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.Write(array4[0, 0]);
            Console.Write(" ");
            Console.Write(array4[0, 1]);
            Console.Write(" ");
            Console.WriteLine(array4[0, 2]);
            Console.Write(array4[1, 0]);
            Console.Write(" ");
            Console.Write(array4[1, 1]);
            Console.Write(" ");
            Console.WriteLine(array4[1, 2]);
            Console.Write(array4[2, 0]);
            Console.Write(" ");
            Console.Write(array4[2, 1]);
            Console.Write(" ");
            Console.Write(array4[2, 2]);



            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Task 11:");

            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var arrList = arr.ToList();
            arrList.Add(11);
            arrList.Insert(0, -1);
            arrList.Insert(4, 12);
            arrList.Remove(1);
            arr = arrList.ToArray();
            int[] arr2 = { 100, 200, 300 };
            int[] arrF = arr2.Concat(arr).ToArray();
            foreach (int item in arrF)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
