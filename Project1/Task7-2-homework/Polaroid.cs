using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    class Polaroid : Electro, Interface
    {
        private int paperWidth;
        private int paperHeight;
        private double numberOfPixelsInCamera;
        public Polaroid(int paperWidth, int paperHeight, double numberOfPixelsInCamera, string? modelName, decimal price)
        {
            this.paperWidth = paperWidth;
            this.paperHeight = paperHeight;
            this.numberOfPixelsInCamera = numberOfPixelsInCamera;
            this.modelName = modelName;
            this.price = price;
        }
        public override string Description
        {
            get
            {
                return $"Price: {price}, model:{modelName}, number of pixels in camera: {numberOfPixelsInCamera}";
            }
        }

        public void TakePhoto()
        {
            Console.WriteLine("Press black button at the top and photo is ready");
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void TurnOn()
        {
            Console.WriteLine("Press right side button");
        }

        public void TurnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
