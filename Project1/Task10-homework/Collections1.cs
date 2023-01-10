using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1.Task10_homework
{
    public class Collections1
    {
        public static void Runner()
        {
            //1)Write a method to find the sum of all even numbers in a list.
            Console.WriteLine("List --1--");
            var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 };
            var myListS = new List<string> { "alice", "wonderland", "in", "boku", "kira" };
            SumInt(myList);

            //2) Create a list containing at least 10 integers, call your method, and output the result.
            Console.WriteLine("List --2--");
            Display(myList);

            // 3)Create a list of strings that contain words of different lengths.
            //Write a static method to output each word from a list of exactly 5 letters.
            //4)Modify your code to prompt the user to enter the length of a search term.
            Console.WriteLine("List --3--");
            Console.WriteLine("Write the length of word:");
            int length = int.Parse(Console.ReadLine());
            FindTheWord(myListS,length);

            //Create a LinkedList and two items, insert a second item after each occurrence of the first item in the list.So, if the list is [2,4,3,2,8,2,5,1,2] and the elements are 2 and 10, the result is [2,10,4,3,2,10,8,2,10,5,1,2,10] 
            Console.WriteLine("LinkedList --1--");
            var initList = new List<int> { 2, 4, 3, 2, 8, 2, 5, 1, 2 };
            LinkedList<int> linkedList = new LinkedList<int>(initList);
            int a = 2; int b = 10;
            int i = 0;
            int count = 0;
            LinkedList<int> list1 = new LinkedList<int>();
            while (i < linkedList.Count)
            {
                if (linkedList.ElementAt(i) == a)
                {
                    var newNode = linkedList.ElementAt(i); 
                    initList.Insert(i+1, b);
                }
                i++;
            }
            int k =initList.Count-1;
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
                    if (firstList[j] == secondList[l])
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
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("add element ");
            queue.Enqueue(int.Parse(Console.ReadLine()));
            Console.WriteLine("add element ");
            queue.Enqueue(int.Parse(Console.ReadLine()));
            Console.WriteLine("add element ");
            queue.Enqueue(int.Parse(Console.ReadLine()));

            foreach (var it in queue)
            {
                Console.WriteLine(it);
            }


        }
        public static void SumInt(List<int> list)
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
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void FindTheWord(List<string> list, int length)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string a = list[i].ToString();
                if (a.Length == length)
                {
                    Console.WriteLine(a);
                }
            }
        }



    }
}
