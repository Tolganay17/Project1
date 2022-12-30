namespace EmpLib
{
    public class Employee
    {
        public static int count;
        public string firstName { get; }
        public string lastName { get; }
        public string position { get; }
        public int age { get; }
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
            count++;
              
        }
       
        public string Employ
        {
           get; set; 
        }
        
        public void getAllInfoEmp() 
        {
           Console.WriteLine("First name: {0}", firstName);
           Console.WriteLine("Last name: {0}", lastName);
           Console.WriteLine("Position: {0}", position);
           Console.WriteLine("Age: {0}", age);
         
            }
        
         public string simWork()
        {
            return "I'm working!";
        }


      
    }
}