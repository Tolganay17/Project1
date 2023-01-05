using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
    class MobilePhone : Electro, Interface
    {
        private double _numberOfPixelsInCamera;

        public MobilePhone(double numberOfPixelsInCamera, string? modelName, decimal price)
        {
            this._numberOfPixelsInCamera = numberOfPixelsInCamera;
            this._modelName = modelName;
            this._price = price;
        }

        public override string Description => $"Price: {_price}, model:{_modelName}, number of pixels in camera: {_numberOfPixelsInCamera}";

        public void TakePhoto() => Console.WriteLine("Press button on the screen and photo is ready");

        public void TurnOn() => Console.WriteLine("Press left side button");

    }
}
