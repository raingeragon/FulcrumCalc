using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FulcrumCalc.Models
{
    class CalcModel
    {
        private double Result;

        public double Number
        {
            get
            {
                return Result;
            }
            set
            {
                Result = value;
            }
        }

        public CalcModel()
        {
            Result = 0;
        }

        public double Add(double x, double y) => x + y;

        public double Subtract(double x, double y) => x - y;

        public double Multiply(double x, double y) => x * y;

        public double Divide(double x, double y) => x / y;

        public double Sqrt(double x) => Math.Sqrt(x);

        public double Inverse(double x) => 1.0 / x;

        public double Opposite(double x) => -x;

        public double PlusPercent(double x, double y) => x + x * y / 100.0;

        public double Back(double x)
        {
            return (int)x / 10;
        }
    }
}
