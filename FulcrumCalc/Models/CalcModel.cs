using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FulcrumCalc.Models
{
    class CalcModel
    {
        public double Add(double x, double y) => x + y;

        public double Subtract(double x, double y) => x - y;

        public double Multiply(double x, double y) => x * y;

        public double Divide(double x, double y) => x / y;

        public double Sqrt(double x) => Math.Sqrt(x);

        public double Inverse(double x) => 1.0 / x;

        public double Opposite(double x) => -x;

        public double Percent(double x) => x / 100.0;

        public string Back(string x)
        {
            if (x.Length > 1)
            return x.Remove(x.Length - 1);
            return "0";
        }
    }
}
