using System.ComponentModel;
using FulcrumCalc.Models;
using System;
using System.Windows.Input;

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
                return model.Number;
            }
            set
            {
                if (model.Number == 0 || newEntry)
                {
                    model.Number = value;
                    newEntry = false;
                }
                else
                    model.Number = double.Parse(model.Number.ToString() + value.ToString());
                RaisePropertyChanged("UpdateNumber");
            }
        }

        #region Operations
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
            model.Number = 0;
            UpdateNumber = 0;
        }

        public void ClearAll()
        {
            model.Number = 0;
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
        #endregion

#region Switchers
        public void OperationSwitcher(string op, CalcViewModel cvm)
        {
            switch(op)
            {
                case "+":
                    cvm.Add();
                    break;
                case "-":
                    cvm.Subtract();
                    break;
                case "*":
                    cvm.Multiply();
                    break;
                case "/":
                    cvm.Divide();
                    break;
                case "√":
                    cvm.Sqrt();
                    break;
                case "±":
                    cvm.Opposite();
                    break;
                case "1/x":
                    cvm.Inverse();
                    break;
                case "%":
                    cvm.PlusPercent();
                    break;
                case "CE":
                    cvm.Clear();
                    break;
                case "C":
                    cvm.ClearAll();
                    break;
                case "=":
                    cvm.Equal();
                    break;
                case "←":
                    cvm.Back();
                    break;
            }
        }

        public void KeyBoardSwitcher(string key, CalcViewModel cvm)
        {
            var local = InputLanguageManager.Current;//ru-Ru
            switch (key)
            {
                case "D0":
                    UpdateNumber = 0;
                    break;
                case "NumPad0":
                    UpdateNumber = 0;
                    break;
                case "D1":
                    UpdateNumber = 1;
                    break;
                case "NumPad1":
                    UpdateNumber = 1;
                    break;
                case "D2":
                    UpdateNumber = 2;
                    break;
                case "NumPad2":
                    UpdateNumber = 2;
                    break;
                case "D3":
                    UpdateNumber = 3;
                    break;
                case "NumPad3":
                    UpdateNumber = 3;
                    break;
                case "D4":
                    UpdateNumber = 4;
                    break;
                case "NumPad4":
                    UpdateNumber = 4;
                    break;
                case "D5":
                    UpdateNumber = 5;
                    break;
                case "NumPad5":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.PlusPercent();
                    else
                        UpdateNumber = 5;
                    break;
                case "D6":
                    UpdateNumber = 6;
                    break;
                case "NumPad6":
                    UpdateNumber = 6;
                    break;
                case "D7":
                    UpdateNumber = 7;
                    break;
                case "NumPad7":
                    UpdateNumber = 7;
                    break;
                case "D8":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.Multiply();
                    else
                        UpdateNumber = 8;
                    break;
                case "NumPad8":
                    UpdateNumber = 8;
                    break;
                case "D9":
                    UpdateNumber = 9;
                    break;
                case "NumPad9":
                    UpdateNumber = 9;
                    break;
                case "Back":
                    Back();
                    break;
                case "Add":
                    Add();
                    break;
                case "OemPlus":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.Add();
                    else
                        cvm.Equal();
                    break;
                case "Multiply":
                    Multiply();
                    break;
                case "Divide":
                    Divide();
                    break;
                case "OemQuestion":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        //Comma_Click(sender, e);
                        break;
                    else
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.Divide();
                    break;
                case "Subtract":
                    cvm.Subtract();
                    break;
                case "OemMinus":
                    if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
                        cvm.Subtract();
                    break;
                case "Decimal":
                   // Comma_Click(sender, e);
                    break;
                case "OemComma":
                    //if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        //Comma_Click(sender, e);
                    break;
                case "OemPeriod":
                    //if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        //Comma_Click(sender, e);
                    break;
            }
        }
#endregion

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
