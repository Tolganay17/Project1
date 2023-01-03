using EmpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class Factory
    {
        public string factoryName;
        public Employee[] employees = new Employee[] { };
        Actor ac = new Actor();
        Teacher te = new Teacher();
        Lawyer la = new Lawyer();
        public Factory() { }
        public Factory(Employee[] employees, string factoryName)
        {
            this.employees = employees;
            this.factoryName = factoryName;
        }
        public int numOfEmp()
        {
            return employees.Length;
        }
        public void getEmpFL()
        {
            foreach (var item in employees)
            {
                Console.WriteLine("First name: " + item.FirstName + "--- " + "Last name:" + item.LastName);
            }
        }
        public void getByPos(string pos)
        {
            foreach (var item in employees)
            {
                if (item.Position == pos)
                {
                    Console.WriteLine("{0}-- Full Name: {1} {2} ", pos, item.FirstName, item.LastName);

                    switch (pos)
                    {
                        case "teacher":
                            Console.WriteLine(te.SimWork());
                            break;
                        case "actor":
                            Console.WriteLine(ac.SimWork());
                            break;
                        case "lawyer":
                            Console.WriteLine(la.SimWork());
                            break;
                        default:
                            Console.WriteLine("Employeee was not found");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Employee was not found");
                }
            }
        }
        /*if (pos == "teacher")
        {
            Console.WriteLine(te.SimWork());
        }
        else if (pos == "actor")
        {
            Console.WriteLine(ac.SimWork());
        }
        else if (pos == "lawyer")
        {
            Console.WriteLine(la.SimWork());
        }
        else
        {
            Console.WriteLine("Employeee was not found");
        }
     }else
    {
        Console.WriteLine("Employee was not found");
    }
}

}
        */

        public void addEmp(string firstName, string lastName, string position, int age)
        {
            var arr = employees.ToList();
            var empp = new Employee(firstName, lastName, position, age);
            arr.Add(empp);
            employees = arr.ToArray();
            Console.WriteLine("Employee is added");
        }


    }
}
