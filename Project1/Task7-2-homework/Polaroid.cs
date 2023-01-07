using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    class Polaroid : Electro, Interface
    {
        private int _paperWidth;
        private int _paperHeight;
        private double _numberOfPixelsInCamera;

        public Polaroid(int paperWidth, int paperHeight, double numberOfPixelsInCamera, string? modelName, decimal price)
        {
            this._paperWidth = paperWidth;
            this._paperHeight = paperHeight;
            this._numberOfPixelsInCamera = numberOfPixelsInCamera;
            this._modelName = modelName;
            this._price = price;
        }

        public override string Description => $"Price: {_price}, model:{_modelName}, number of pixels in camera: {_numberOfPixelsInCamera}";

        public void TakePhoto() => Console.WriteLine("Press black button at the top and photo is ready");

        public void Print() => Console.WriteLine("Printing...");

        public void TurnOn() => Console.WriteLine("Press right side button");
    }
}
