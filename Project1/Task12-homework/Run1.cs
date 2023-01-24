using Project1.Task7_2_homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            const string jsonPath = @"C:\Users\tolganay.muratova\Projects\Project1\Project1\Json\";
            var fileName1 = $"{jsonPath}Data.json";
            var filename2 = $"{jsonPath}ToOject.json";
            var cars = new Car { CarName = "Tesla", Year = 2018, Wheels = 4 };
            var person = new Person { PersonName = "Amanda", Age = 26, IsMarried = false, Date = DateTime.Now };
            person.car.Add(cars);
            string jsonString = JsonSerializer.Serialize(person);
            File.WriteAllText(fileName1, jsonString);
            var jsonText = File.ReadAllText(filename2);
            var myNewPerson = JsonSerializer.Deserialize<Person>(jsonText);
        }
    }
}
