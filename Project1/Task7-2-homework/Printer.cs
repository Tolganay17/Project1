using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    class Printer : Electro, Interface
    {
<<<<<<< HEAD
        private int paperWidth;
        private int paperHeight;
=======
        private int _paperWidth;
        private int _paperHeight;
>>>>>>> master

        public Printer(string? modelName, decimal price, int paperWidth, int paperHeight)
        {
            this._modelName = modelName;
            this._price = price;
            this._paperWidth = paperWidth;
            this._paperHeight = paperHeight;
        }

        public override string Description => $"Price: {_price}, model:{_modelName}";

        public void Print() => Console.WriteLine("Printing...");

        public void TurnOn() => Console.WriteLine("Press button at the top");
    }
}
