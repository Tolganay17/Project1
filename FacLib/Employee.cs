using System.Reflection.Metadata.Ecma335;

namespace EmpLib
{
    public class Employee
    {
       
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Employee() { }
        public Employee(string firstName)
        { 
            this.firstName = firstName;
        }

        public Employee(string firstName, string lastName, string position, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.age = age;
         
              
        }

        
        public void getAllInfoEmp() 
        {
           Console.WriteLine("First name: {0}", FirstName);
           Console.WriteLine("Last name: {0}",LastName);
           Console.WriteLine("Position: {0}", Position);
           Console.WriteLine("Age: {0}", Age);
         
            }
        
         public virtual string SimWork()
        {
            return "I'm working!";
        }


      
    }

    public class Teacher : Employee
    {
        public override string SimWork()
        {
            return "teacher is working!";
        }
    }
    public class Actor : Employee
    {
        public override string SimWork()
        {
            return "actor is working!";
        }
    }
    public class Lawyer : Employee
    {
        public override string SimWork()
        {
            return "lawyer is working!";
        }
    }
}