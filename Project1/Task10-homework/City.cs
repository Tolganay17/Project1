using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task10_homework
{
    public class City
    {
        private int _population;
        private double _area;

        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public City(int population, double area)
        {
            this._population = population;
            this._area = area;
        }

        public override string ToString()
        {
            return string.Format($"area: {_area}, population :{_population} ");
        }
    }
}
