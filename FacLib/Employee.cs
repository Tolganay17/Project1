namespace EmpLib
{
    public class Employee
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Employee() { }
        public Employee(string firstName)
        {
            this._firstName = firstName;
        }

        public Employee(string firstName, string lastName, string position, int age)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._position = position;
            this._age = age;
        }


        public void getAllInfoEmp()
        {
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Age: {Age}");
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