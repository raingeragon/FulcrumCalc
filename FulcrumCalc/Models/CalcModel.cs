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
        { get
            {
                return Result;
            }
            set
            {
                Number = Result;
            }
        }

        public CalcModel()
        {
            Result = 0;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
