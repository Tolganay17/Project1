using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_homework
{
    internal class Interfaces
    {
        public static void Runner()
        {
            var g = new General();
            g.Name = "Test";
            g.Color = "blue";
            g.SayName();
            g.SayColor();

        }
    }
    interface Interface1
    {
        string Color { get; set; }

        void SayColor();
    }
    interface Interface2
    {
        string Name { get; set; }

        void SayName();
    }

    class General : Interface1, Interface2
    {
        public string Name { get; set; }

        public void SayName() => Console.WriteLine("my name is {0}", Name);

        public string Color { get; set; }

        public void SayColor() => Console.WriteLine("my color is {0}", Color);

    }

}
