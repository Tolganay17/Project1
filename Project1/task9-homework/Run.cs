using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.task9_homework
{
    public class Run
    {
        public static void Runner()
        {
            Display();
        }

        public static void Display()
        {
            GenenricClass<Man> man = new GenenricClass<Man>();

            GenenricClass<Woman> woman = new GenenricClass<Woman>();

            man.Add(new Man("Usop", "Kira"));
            man.Add(new Man("Akasa", "kasdas"));
            man.Add(new Man("Nikita", "Kintas"));
            man.Add(new Man("Meruem", "Lolokeh"));
            man.toStringGen();

            woman.Add(new Woman("Diana", "Kira"));
            woman.Add(new Woman("Alila", "kasdas"));
            woman.Add(new Woman("Alina", "Kintas"));
            woman.Add(new Woman("Meruert", "Lolokeh"));
            woman.toStringGen();

        }

    }
}
