using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Project1.Task10_homework
{
    public class Collections1
    {
        public static void Runner()
        {
            //1)Write a method to find the sum of all even numbers in a list.
            Console.WriteLine("List --1--");
            var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var myListOfStrings = new List<string> { "alice", "wonderland", "in", "boku", "kira" };
            SumEvenNumbers(myList);

            //2) Create a list containing at least 10 integers, call your method, and output the result.
            Console.WriteLine("List --2--");
            Display(myList);

            // 3)Create a list of strings that contain words of different lengths.
            //Write a static method to output each word from a list of exactly 5 letters.
            //4)Modify your code to prompt the user to enter the length of a search term.
            Console.WriteLine("List --3--");
            Console.WriteLine("Write the length of word:");
            int length = int.Parse(Console.ReadLine());
            FindTheWordByLength(myListOfStrings, length);

            //Create a LinkedList and two items, insert a second item after each occurrence of the first item in the list.So, if the list is [2,4,3,2,8,2,5,1,2] and the elements are 2 and 10, the result is [2,10,4,3,2,10,8,2,10,5,1,2,10] 
            Console.WriteLine("LinkedList --1--");
            var initList = new List<int> { 2, 4, 3, 2, 8, 2, 5, 1, 2 };
            var linkedList = new LinkedList<int>(initList);
            int a = 2; int b = 10;
            int i = 0;
            int count = 0;
            LinkedList<int> list1 = new LinkedList<int>();
            while (i < linkedList.Count)
            {
                if (linkedList.ElementAt(i) == a)
                {
                    initList.Insert(i + 1, b);
                }
                i++;
            }
            int k = initList.Count - 1;
            if (initList.ElementAt(k) == a)
            {
                initList.Add(10);
            }
            foreach (var stu in initList)
            {
                Console.WriteLine(stu);
            }
            //Merge two related lists of numbers by including in the final list only those numbers that occur in both lists. So, if the lists are[1, 3, 4, 7, 12] and[1, 5, 7, 9], the result will be[1, 7]. *
            Console.WriteLine("List --2--");
            var finalList = new List<int>();
            var firstList = new List<int> { 1, 3, 4, 7, 12 };
            var secondList = new List<int> { 1, 7 };
            for (int j = 0; j < firstList.Count; j++)
            {
                for (int l = 0; l < secondList.Count; l++)
                {
                    if (secondList.Contains(firstList[j]))
                    {
                        finalList.Add(firstList[j]);
                    }
                }
            }
            foreach (var item in finalList)
            {
                Console.WriteLine(item);
            }

            //Create a Queue via inputting queue elements into console.Create GetMaxValue() method, which should return the maximum value stored in the queue and not remove this value from the queue. Create DeleteMaxValue() method which find max value in the queue and removes it.Call GetMaxValue() method => confirm it returns max value and not deletes it from the queue.Call DeleteMaxValue () => confirm it deletes max value from the queue.Call GetMaxValue() again and confirm it returns actual max value.
            Console.WriteLine("queue:");
            var queue = new Queue<int>();
            AddElementsQueue(queue);
            AddElementsQueue(queue);
            AddElementsQueue(queue);
            queue = new Queue<int>(queue.OrderBy(q => q));
            ReverseQueue(queue);
            GetMaxValue(queue);
            Console.WriteLine("Before deletion:");

            foreach (var it in queue)
            {
                Console.WriteLine(it);
            }

            DeleteFirstValue(queue);
            Console.WriteLine("After deletion:");

            foreach (var it in queue)
            {
                Console.WriteLine(it);
            }
            GetMaxValue(queue);

            //Write a program that takes three letters as input and displays them in reverse order. Use Stack.
            Console.WriteLine("---stack---");
            var myStack = new Stack<int>();
            Console.WriteLine("Enter values:");
            AddElementsStack(myStack);
            AddElementsStack(myStack);
            AddElementsStack(myStack);
            Console.WriteLine("in reverse order:");
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            //Dictionary
            //Add a new value whose key is your name and whose value is your age. Do this using the Add method.Then addanother value to the dictionary using index notation. This time, use a different name and a different age.Finally, read the first item you added to the dictionary and write it to the console using Console.WriteLine.

            var myDic = new Dictionary<string, int>();
            myDic.Add("Tolganay", 22);
            myDic["Alila"] = 22;
            Console.WriteLine($"key : {myDic.ElementAt(0).Key} ||  value: {myDic.ElementAt(0).Value}");

            //Create two lists, each with 10 values.The first list is of type int, where the values are not in order.the second list is of type string, the values are also not alphabetically specified. Write a method that performs sorting operations on the two lists the int list in ascending and the string list in descending order. Then this method merges the lists into a dictionary.Output the resulting word to the console *
            var myListF = new List<int>() { 4, 3, 7, 8, 6 };
            var myListG = new List<string>() { "aka", "maka", "saka", "lola", "kola" };
            MergeListsToDic(myListF, myListG);

            //            Create a City class where there are fields int population, double area.Create a dictionary where Key is the name of the city and Value is the corresponding name of the cityand the object of type City. Create 5 elements for the dictionary. 
            //Sort the dictionary by city area and display it on your console
            //Browse the dictionary by population in reverse order and display it on your console
            //Count the total population of all cities and output to the console *
            Dictionary<string, City> myCity = new Dictionary<string, City>();
            myCity.Add("Oku", new City(23, 456.5));
            myCity.Add("Aka", new City(34, 345.4));
            myCity.Add("mika", new City(24, 355.2));
            myCity.Add("Lala", new City(44, 445.4));
            myCity.Add("Saka", new City(54, 555.2));
            
            
            var sorted = myCity.OrderBy(x => x.Value.Area);
            var dictionary = sorted.ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine("sorted dictionary by area:");
            foreach (var item in dictionary)
            {
                Console.WriteLine($" key : {item.Key}  value : {item.Value}");
            }
            var reversed = myCity.OrderByDescending(x => x.Value.Population);
            dictionary = reversed.ToDictionary(x=>x.Key, x=>x.Value);
            Console.WriteLine("descending order by population");
            foreach (var item in dictionary)
            {
                Console.WriteLine($" key : {item.Key}  value : {item.Value}");
            }
            double sum = myCity.Sum(v => v.Value.Area);
            Console.WriteLine($"Sum of area:{sum}");
        }

        public static void AddElementsStack(Stack <int> s)
        {
            Console.WriteLine("First value:");
            s.Push(int.Parse(Console.ReadLine()));

        }

        public static void AddElementsQueue(Queue<int> s)
        {
            Console.WriteLine("First value:");
            s.Enqueue(int.Parse(Console.ReadLine()));

        }

        public static void MergeListsToDic(List<int> i, List<string> s)
        {
            i.Sort();
            s.Sort();
            s.Reverse();
            var dic = new Dictionary<int, string>();
            foreach (var key in i)
            {
                foreach (var value in s)
                {
                    dic[key] = value;
                    s.Remove(value);
                    break;
                }
            }
            foreach (var item2 in dic)
            {
                Console.WriteLine(item2);
            }
        }

        public static void ReverseQueue(Queue<int> q)
        {
            if (!q.Any())
                return;
            var fr = (int)q.Peek();
            q.Dequeue();
            ReverseQueue(q);
            q.Enqueue(fr);
        }

        public static void GetMaxValue(Queue<int> q)
        {
            Console.WriteLine($"Max element: {q.Peek()}");
        }

        public static void DeleteFirstValue(Queue<int> q)
        {
            Console.WriteLine($"Max element: {q.Dequeue()}");
        }

        public static void SumEvenNumbers(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    sum += list[i];
                }
            }
            Console.WriteLine(sum);
        }

        public static void Display(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void FindTheWordByLength(List<string> list, int length)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string a = list[i];
                if (a.Length == length)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
}
