using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    abstract class Electro
    {
        protected string? _modelName;
        protected decimal _price;

        public abstract string Description { get; }
<<<<<<< HEAD
=======

        public void TurnOff() => Console.WriteLine("Press Turn Off button");
>>>>>>> master
    }
}
