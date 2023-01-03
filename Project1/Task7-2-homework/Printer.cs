using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    class Printer : Electro, Interface
    {
        private int paperWidth;
        private int paperHeight;
       
        public Printer(string? modelName, decimal price, int paperWidth, int paperHeight)
        {
            this.modelName = modelName;
            this.price = price;
            this.paperWidth = paperWidth;
            this.paperHeight = paperHeight;
        }

        public override string Description
        {
            get
            {
                return $"Price: {price}, model:{modelName}";
            }
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void TurnOn()
        {
            Console.WriteLine("Press button at the top");
        }

        public void TurnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
