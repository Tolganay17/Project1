using Project1.Task7_2_homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1.Task12_homework
{
    public class Run1
    {
        public static void Runner()
        {
            var fileName1 = "C:\\Users\\tolganay.muratova\\Projects\\Project1\\Project1\\Json\\Data.json";
            var filename2 = @"C:\Users\tolganay.muratova\Projects\Project1\Project1\Json\ToOject.json";
            var cars = new Car { CarName = "Tesla", Year = 2018, Wheels = 4 };
            var person = new Person { PersonName = "Amanda", Age = 26, IsMarried = false, Date = DateTime.Now };
            person.car.Add(cars);
            string jsonString = JsonSerializer.Serialize(person);
            File.WriteAllText(fileName1, jsonString);
            var jsonText = File.ReadAllText(filename2);
            var myNewPerson = JsonSerializer.Deserialize<Person>(jsonText);
        }
    }

    public class Person
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
        public DateTime Date { get; set; }
        public List<Car> car { get; set; } = new List<Car>();
    }

    public class Car
    {
        public string CarName { get; set; }
        public int Year { get; set; }
        public int Wheels { get; set; }
    }
}
