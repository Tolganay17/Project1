using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_homework
{
    internal class Runner1
    {
        public static void Runner()
        {

            Bulldog b = new Bulldog("Bulldog");
            b.SayBreed();
            b.Color = "blue";
            b.BulColor();

            Pitbull p = new Pitbull("Pitbull", 13);
            p.SayBreed();
            p.PitbullAge();

            Chao c = new Chao("Chao",3);
            c.SayBreed();
            c.ChaoTails();

        }
    }
    abstract class Dog
    {
        protected string breedName;
        public Dog(string breedName)
        {
            this.breedName = breedName;
        }
        public abstract string BreedName { get; set; }

        public abstract void SayBreed();
        public void Hello() { Console.WriteLine("Hello!"); }

    }
    class Bulldog : Dog
    {
        private string color;
        public string Color { get; set; }
        private int age;

        public Bulldog(string breedName) : base(breedName)
        { this.breedName= breedName;
        }

        public override string BreedName {
            get
            {
                return breedName;
            }
            set
            {
                breedName = value;
            }
        }

        public override void SayBreed()
        {
            Console.WriteLine("I am {0}",BreedName);
        }
        public void BulColor()
        {
            Console.WriteLine("my color is {0}", Color);
        }

    }
    class Pitbull : Dog
    {
        private int age;
        public int Age { get; set; }

        public Pitbull(string breedName, int age) : base(breedName)
        {
            this.breedName = breedName;
            Age = age;
        }

        public override string BreedName
        {
            get
            {
                return breedName;
            }
            set
            {
                breedName = value;
            }
        }

        public override void SayBreed()
        {
            Console.WriteLine("I am {0}", BreedName);
        }
        public void PitbullAge()
        {
            Console.WriteLine("Pitbill is {0} years old", Age);
        }

    }
    class Chao : Dog
    {
        private int numTails;

        public int NumTails
        {
            get { return numTails; }
            set { numTails = value; }
        }


        public Chao(string breedName, int tails) : base(breedName)
        {
            this.breedName = breedName;
            numTails = tails;
        }

        public override string BreedName
        {
            get
            {
                return breedName;
            }
            set
            {
                breedName = value;
            }
        }

        public override void SayBreed()
        {
            Console.WriteLine("I am {0}", BreedName);
        }
        public void ChaoTails()
        {
            Console.WriteLine("Chao has {0} tails", NumTails);
        }

    }
}
