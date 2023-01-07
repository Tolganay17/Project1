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
            var b = new Bulldog("Bulldog");
            b.SayBreed();
            b.Color = "blue";
            b.BulColor();

            var p = new Pitbull("Pitbull", 13);
            p.SayBreed();
            p.PitbullAge();

            var c = new Chao("Chao", 3);
            c.SayBreed();
            c.ChaoTails();

        }
    }
    abstract class Dog
    {
        protected string _breedName;

        public Dog(string breedName)
        {
            this._breedName = breedName;
        }
        public abstract string BreedNameP { get; set; }

        public void SayBreed() => Console.WriteLine($"I am {BreedNameP}");

        public void Hello() => Console.WriteLine("Hello!");
    }
    class Bulldog : Dog
    {
        private string _color;

        public string Color { get; set; }

        public Bulldog(string breedName) : base(breedName)
        {
            this._breedName = breedName;
        }

        public override string BreedNameP
        {
            get
            {
                return _breedName;
            }
            set
            {
                _breedName = value;
            }
        }

        public void BulColor() => Console.WriteLine($"my color is {Color}");
    }

    class Pitbull : Dog
    {
        private int _age;
        public int Age { get; set; }

        public Pitbull(string breedName, int age) : base(breedName)
        {
            this._breedName = breedName;
            Age = age;
        }

        public override string BreedNameP
        {
            get
            {
                return _breedName;
            }
            set
            {
                _breedName = value;
            }
        }
        public void PitbullAge() => Console.WriteLine($"Pitbill is {Age} years old");
    }

    class Chao : Dog
    {
        private int _numTails;

        public int NumTails
        {
            get { return _numTails; }
            set { _numTails = value; }
        }

        public Chao(string breedName, int tails) : base(breedName)
        {
            this._breedName = breedName;
            _numTails = tails;
        }

        public override string BreedNameP
        {
            get
            {
                return _breedName;
            }
            set
            {
                _breedName = value;
            }
        }
        public void ChaoTails() => Console.WriteLine($"Chao has {NumTails} tails");
    }
}