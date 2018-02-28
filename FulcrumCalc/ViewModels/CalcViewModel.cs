using System.ComponentModel;
using FulcrumCalc.Models;
using System;
using System.Windows.Input;

namespace FulcrumCalc.ViewModels
{
    class CalcViewModel : INotifyPropertyChanged
    {
        private CalcModel model;
        private string mathstring;
        private string output;
        private bool newEntry;
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
        public string MathString
        {
            get
            {
                return mathstring;
            }
            set
            {
                mathstring = value;
                RaisePropertyChanged("MathString");
            }
        }

        public CalcViewModel()
        {
            model = new CalcModel();
            MathString = "";
            Output = "0";
        }

        public void TxtUpdate(string input)
        {
            if (input == ".")
            {
                if (!(Output == "0" || Output == "" || Output.Contains(".")))
                    Output += input;
            }
            else
                if (Output == "0" || newEntry)
                Output = input;
            else
                Output += input;
            newEntry = false;
            
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
            MathString += Output + " + ";
            newEntry = true;
        }

        private void Subtract()
        {
            MathString += Output + " - ";
            newEntry = true;
        }

        private void Multiply()
        {
            MathString += Output + " * ";
            newEntry = true;
        }

        private void Divide()
        {
            MathString += Output + " / ";
            newEntry = true;
        }

        private void Sqrt()
        {
                double res = model.Sqrt(StringToDouble(Output));
                Clear();
                TxtUpdate(res.ToString());
            newEntry = true;
        }

        private void Opposite()
        {
            double res = model.Opposite(StringToDouble(Output));
            Clear();
            TxtUpdate(res.ToString());
            newEntry = true;
        }

        private void Inverse()
        { 
            double res = model.Inverse(StringToDouble(Output));
            Clear();
            TxtUpdate(res.ToString());
            newEntry = true;
        }

        private void PlusPercent()
        {
            double res = model.Percent(StringToDouble(Output));
            Clear();
            TxtUpdate(res.ToString());
            newEntry = true;

        }

        private void Clear()
        {
            Output = "0";
        }

        private void ClearAll()
        {
            Output = "0";
            MathString = "";
        }

        private void Equal()
        {
            MathString += Output;
            Clear();
            // parses string that contains multi operations and returns the result on the screen
            var ops = MathString.Split(' ');
            int i = 1;
            double res = 0;
            double tempRes;
            string op;
            
            if (Convert.ToDouble(ops[0]) < 0)
                op = "-";
            else
                op = "";

            tempRes = Convert.ToDouble(ops[0]);
            while (i <= ops.Length)
            {
                if (i == ops.Length)
                {
                    break;
                }
                if (ops[i] == "/" || ops[i] == "*")
                {
                    while (i < ops.Length && (ops[i] == "/" || ops[i] == "*"))
                    {
                        if (ops[i] == "/")
                            tempRes = tempRes / Convert.ToDouble(ops[i + 1]);
                        else
                            tempRes = tempRes * Convert.ToDouble(ops[i + 1]);
                        i += 2;
                    }

                }
                if (i <= ops.Length)
                {

                    res += Convert.ToDouble(op + tempRes.ToString());
                    if (i + 1 < ops.Length)
                    {
                        if (ops[i] == "+")
                            op = "";
                        else
                            op = "-";
                        if (i != ops.Length)
                            tempRes = Convert.ToDouble(ops[i + 1]);
                        i += 2;
                    }
                }

            }
            MathString = "";
            Output = res.ToString();
            newEntry = true;
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
            var local = InputLanguageManager.Current;//ru-RU
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
                    cvm.Back();
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
                    if (local.CurrentInputLanguage.ToString() == "ru-RU")
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
                    if (local.CurrentInputLanguage.ToString() != "ru-RU")
                        TxtUpdate(".");
                    break;
                case "OemPeriod":
                    if (local.CurrentInputLanguage.ToString() != "ru-RU")
                    TxtUpdate(".");
                    break;
                case "Return":
                    cvm.Equal();
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
    }
}
