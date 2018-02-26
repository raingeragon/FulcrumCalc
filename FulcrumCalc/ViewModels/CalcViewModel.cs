using System.ComponentModel;
using FulcrumCalc.Models;
using System;

namespace FulcrumCalc.ViewModels
{
    class CalcViewModel : INotifyPropertyChanged
    {
        private double tempNumber;
        private CalcModel model;
        LastOperation lastoperation;
        bool newEntry;

        public CalcViewModel()
        {
            model = new CalcModel();
            tempNumber = 0;
            lastoperation = LastOperation.None;
            newEntry = false;
        }

        public double UpdateNumber
        {
            get
            {
                return StringToDouble(model.Number);
            }
            set
            {
                if (StringToDouble(model.Number) == 0 || newEntry)
                {
                    model.Number = value.ToString();
                    newEntry = false;
                }
                else
                    model.Number = model.Number.ToString() + value.ToString();
                RaisePropertyChanged("UpdateNumber");
            }
        }
        public void Back()
        {
            double res = model.Back(UpdateNumber);
            Clear();
            UpdateNumber = res;
        }
        public void Add()
        {
            if (lastoperation == LastOperation.Add)
            {
                double res = model.Add(UpdateNumber, tempNumber);
                Clear();
                UpdateNumber = res;
            }
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.Add;
        }

        public void Subtract()
        {
            if (lastoperation == LastOperation.Subtract)
            {
                double res = model.Subtract(tempNumber, UpdateNumber);
                Clear();
                UpdateNumber = res;
            }
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.Subtract;
        }

        public void Multiply()
        {
            if (lastoperation == LastOperation.Multiply)
            {
                double res = model.Multiply(UpdateNumber, tempNumber);
                Clear();
                UpdateNumber = res;
            }
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.Multiply;
        }

        public void Divide()
        {
            if (lastoperation == LastOperation.Divide)
            {
                double res = model.Divide(tempNumber, UpdateNumber);
                Clear();
                UpdateNumber = res;
            }
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.Divide;
        }

        public void Sqrt()
        {
            double res = model.Sqrt(UpdateNumber);
            Clear();
            UpdateNumber = res;
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.None;
        }

        public void Opposite()
        {
            double res = model.Opposite(UpdateNumber);
            Clear();
            UpdateNumber = res;
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.None;
        }

        public void Inverse()
        { 
            double res = model.Inverse(UpdateNumber);
            Clear();
            UpdateNumber = res;
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.None;
        }

        public void PlusPercent()
        {
            if (lastoperation == LastOperation.PLusPercent)
            {
                double res = model.PlusPercent(tempNumber, UpdateNumber);
                Clear();
                UpdateNumber = res;
            }
            tempNumber = UpdateNumber;
            newEntry = true;
            lastoperation = LastOperation.PLusPercent;
        }

        public void Clear()
        {
            model.Number = "0";
            UpdateNumber = 0;
        }

        public void ClearAll()
        {
            model.Number = "0";
            UpdateNumber = 0;
            tempNumber = 0;
            newEntry = false;
            lastoperation = LastOperation.None;
        }

        public void Equal()
        {
            switch (lastoperation)
            {
                case LastOperation.Add:
                    Add();
                    break;
                case LastOperation.Divide:
                    Divide();
                    break;
                case LastOperation.Inverse:
                    Inverse();
                    break;
                case LastOperation.Multiply:
                    Multiply();
                    break;
                case LastOperation.PLusPercent:
                    PlusPercent();
                    break;
                case LastOperation.Subtract:
                    Subtract();
                    break;
                default:
                    break;
            }
            lastoperation = LastOperation.None;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double StringToDouble(string val)
        {
            double res = 0;
            if (val[val.Length - 1] == '.')
                res = Convert.ToDouble(val.Remove(val.Length - 1));
            else
                res = Convert.ToDouble(val);
            return res;
            
        }
        enum LastOperation
        {
            None,
            Add,
            Divide,
            Subtract,
            Multiply,
            Sqrt,
            PLusPercent,
            Inverse,
            Opposite
        };
    }
}
