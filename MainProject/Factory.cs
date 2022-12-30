using EmpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    internal class Factory
    {
        public string factoryName;
    
       

        public Employee[] employees = new Employee[] { };
    
     

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
            if (employees.Length != 0)
            {
                foreach (var item in employees)
                {
                    Console.WriteLine("First name: " + item.firstName + "--- " + "Last name:" + item.lastName);
                }
            }
            else
            {
                Console.WriteLine("Employee was not found");
            }

        }

        public void getByPos(string pos)
        {
            foreach (var item in employees)
            {
                if (item.position == pos)
                {
                    Console.WriteLine("{0}-- Full Name: {1} {2} ", pos, item.firstName, item.lastName);
                }
                else
                {
                    Console.WriteLine("Employee was not found");
                }
            }

        }
        public void addEmp(string firstName, string lastName, string position, int age)
        {
            var arr= employees.ToList();

            Employee empp = new Employee(firstName,lastName,position,age);
            arr.Add(empp);
            employees = arr.ToArray();
            Console.WriteLine("Employee is added");
        }
        

    }
}
