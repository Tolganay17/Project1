using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task7_2_homework
{
     class MobilePhone : Electro, Interface
    {
        private double numberOfPixelsInCamera;
      

        public MobilePhone(double numberOfPixelsInCamera, string? modelName, decimal price)
        {
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
            Console.WriteLine("Press button on the screen and photo is ready");
        }

        public void TurnOn()
        {
            Console.WriteLine("Press left side button");
        }

        public void TurnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }
}
