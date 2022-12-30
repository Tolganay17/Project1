using EmpLib;

namespace MainProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Employee[] employees = new Employee[] {  };
            Employee em = new Employee();

            Factory factory= new Factory(employees ,"boba");

            bool done = false;
            while (!done)
            {
            Console.WriteLine("");
            Console.WriteLine("************************");
            Console.WriteLine("1.Number of employees");
            Console.WriteLine("2.List of all employees");
            Console.WriteLine("3. Employeees by position");
            Console.WriteLine("4. Add am employee");
            Console.WriteLine("5. Exit");
            Console.WriteLine("************************");
             
                Console.WriteLine("You choice:");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:

                        Console.WriteLine(factory.numOfEmp());
                        Console.WriteLine("");
                        em.getAllInfoEmp();
                        break;
                    case 2:
                        factory.getEmpFL();
                        break;
                    case 3:
                        {
                            Console.WriteLine("Write the position");
                            string pos = Console.ReadLine();
                            factory.getByPos(pos);

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Write first name:");
                            string fn = Console.ReadLine();
                            Console.WriteLine("Write last name:");
                            string sn = Console.ReadLine();
                            Console.WriteLine("Write the position:");
                            string ps = Console.ReadLine();
                            Console.WriteLine("Write age:");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Proceeding.... {0}--{1}--{2}--{3}",fn,sn,ps,age);
                            factory.addEmp(fn, sn, ps, age);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Bye! Have a nice day!");
                            done= true;
                            break;
                        }
                    
                    default:
                        Console.WriteLine("Type valid choice");
                        Console.WriteLine();
                        break;

                }
                
            }
        }
    }
}