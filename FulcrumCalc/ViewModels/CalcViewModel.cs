using System.ComponentModel;
using FulcrumCalc.Models;
using System;
using System.Windows.Input;

namespace FulcrumCalc.ViewModels
{
    class CalcViewModel : INotifyPropertyChanged
    {
        private string tempNumber;
        private CalcModel model;
        LastOperation lastoperation;
        private string output;
        public string Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                RaisePropertyChanged("Output");
            }
        }
            

        public CalcViewModel()
        {
            model = new CalcModel();
            tempNumber = "0";
            Output = "0";
            lastoperation = LastOperation.None;
        }

        public void TxtUpdate(string input)
        {
            if (input == ".")
            {
                if (!(Output == "0" || Output =="" || Output.Contains(".")))
                    Output += input;
            }
            else
                if (Output == "0")
                Output = input;
            else
                Output += input;
            
        }


        #region Operations

        private void Back()
        {
            string res = model.Back(Output);
            Clear();
            TxtUpdate(res);
        }

        private void Add()
        {
            if (lastoperation == LastOperation.Add)
            {
                double res = model.Add(StringToDouble(tempNumber), StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            }
            tempNumber = Output;
            if (lastoperation == LastOperation.None)
                Output = "";
            lastoperation = LastOperation.Add;
        }

        private void Subtract()
        {
            if (lastoperation == LastOperation.Subtract)
            {
                double res = model.Subtract(StringToDouble(tempNumber), StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            }
            tempNumber = Output;
            if (lastoperation == LastOperation.None)
                Output = "";
            lastoperation = LastOperation.Subtract;
        }

        private void Multiply()
        {
            if (lastoperation == LastOperation.Multiply)
            {
                double res = model.Multiply(StringToDouble(tempNumber), StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            }
            tempNumber = Output;
            if (lastoperation == LastOperation.None)
                Output = "";
            lastoperation = LastOperation.Multiply;
        }

        private void Divide()
        {
            if (lastoperation == LastOperation.Divide)
            {
                double res = model.Divide(StringToDouble(tempNumber), StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            }
            tempNumber = Output;
            if (lastoperation == LastOperation.None)
                Output = "";
            lastoperation = LastOperation.Divide;
        }

        private void Sqrt()
        {
            if (StringToDouble(Output) >= 0)
            {
                double res = model.Sqrt(StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
                tempNumber = Output;
            }
                lastoperation = LastOperation.None;
            
        }

        private void Opposite()
        {
            double res = model.Opposite(StringToDouble(Output));
            Clear();
            TxtUpdate(res.ToString());
            tempNumber = Output;
            lastoperation = LastOperation.None;
        }

        private void Inverse()
        { 
            double res = model.Inverse(StringToDouble(Output));
            Clear();
            TxtUpdate(res.ToString());
            tempNumber = Output;
            lastoperation = LastOperation.None;
        }

        private void PlusPercent()
        {
            if (lastoperation == LastOperation.PLusPercent)
            {
                double res = model.PlusPercent(StringToDouble(tempNumber), StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            }
            tempNumber = Output;
            if (lastoperation == LastOperation.None)
                Output = "";
            lastoperation = LastOperation.PLusPercent;
        }

        private void Clear()
        {
            Output = "0";
        }

        private void ClearAll()
        {
            Output = "0";
            tempNumber = "0";
            lastoperation = LastOperation.None;
        }

        private void Equal()
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
            switch (op)
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
                    TxtUpdate("0");
                    break;
                case "NumPad0":
                    TxtUpdate("0");
                    break;
                case "D1":
                    TxtUpdate("1");
                    break;
                case "NumPad1":
                    TxtUpdate("1");
                    break;
                case "D2":
                    TxtUpdate("2");
                    break;
                case "NumPad2":
                    TxtUpdate("2");
                    break;
                case "D3":
                    TxtUpdate("3");
                    break;
                case "NumPad3":
                    TxtUpdate("3");
                    break;
                case "D4":
                    TxtUpdate("4");
                    break;
                case "NumPad4":
                    TxtUpdate("4");
                    break;
                case "D5":
                    TxtUpdate("5");
                    break;
                case "NumPad5":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.PlusPercent();
                    else
                        TxtUpdate("5");
                    break;
                case "D6":
                    TxtUpdate("6");
                    break;
                case "NumPad6":
                    TxtUpdate("6");
                    break;
                case "D7":
                    TxtUpdate("7");
                    break;
                case "NumPad7":
                    TxtUpdate("7");
                    break;
                case "D8":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        cvm.Multiply();
                    else
                        TxtUpdate("8");
                    break;
                case "NumPad8":
                    TxtUpdate("8");
                    break;
                case "D9":
                    TxtUpdate("9");
                    break;
                case "NumPad9":
                    TxtUpdate("9");
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
                        TxtUpdate(".");
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
                    TxtUpdate(".");
                    break;
                case "OemComma":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        TxtUpdate(".");
                    break;
                case "OemPeriod":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                    TxtUpdate(".");
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
            if (val.Length == 0)
                return res;
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
