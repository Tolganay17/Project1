namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Nice to meet you {0} {1}", name, surname);
        }
    }
}