using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FulcrumCalc.ViewModels;

namespace FulcrumCalc
{
    public partial class MainWindow : Window
    {
        CalcViewModel cvm;

        public MainWindow()
        {
            InitializeComponent();
            cvm = (CalcViewModel)DataContext;

        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            var num = (Button)sender;
            cvm.UpdateNumber = double.Parse(num.Content.ToString());
        }

        private void Back_Click(object sender, RoutedEventArgs e) => cvm.Back();
        private void Add_Click(object sender, RoutedEventArgs e) => cvm.Add();
        private void Subtract_Click(object sender, RoutedEventArgs e) => cvm.Subtract();
        private void Multiply_Click(object sender, RoutedEventArgs e) => cvm.Multiply();
        private void Divide_Click(object sender, RoutedEventArgs e) => cvm.Divide();
        private void Sqrt_Click(object sender, RoutedEventArgs e) => cvm.Sqrt();
        private void Inverse_Click(object sender, RoutedEventArgs e) => cvm.Inverse();
        private void PlusPercent_Click(object sender, RoutedEventArgs e) => cvm.PlusPercent();
        private void Clear_Click(object sender, RoutedEventArgs e) => cvm.Clear();
        private void ClearAll_Click(object sender, RoutedEventArgs e) => cvm.ClearAll();
        private void Equal_Click(object sender, RoutedEventArgs e) => cvm.Equal();
        private void Opposite_Click(object sender, RoutedEventArgs e) => cvm.Opposite();
        private void Comma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Theme_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Dark);
            RefreshNiceSquare();
        }

        private void Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Light);
            RefreshNiceSquare();
        }

        private void OnBlueClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Light);
            RefreshNiceSquare();
        }

        private void OnRedClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Dark);
            RefreshNiceSquare();
        }
        private void RefreshNiceSquare()
        {
            //NiceSquareContainer.Child = new NiceSquare();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            var local = InputLanguageManager.Current;//ru-Ru
            switch (e.Key.ToString())
            {
                case "D0":
                    NumBtn_Click(Btn0, e);
                    break;
                case "Numpad0":
                    NumBtn_Click(Btn0, e);
                    break;
                case "D1":
                    NumBtn_Click(Btn1, e);
                    break;
                case "Numpad1":
                    NumBtn_Click(Btn1, e);
                    break;
                case "D2":
                    NumBtn_Click(Btn2, e);
                    break;
                case "Numpad2":
                    NumBtn_Click(Btn2, e);
                    break;
                case "D3":
                    NumBtn_Click(Btn3, e);
                    break;
                case "Numpad3":
                    NumBtn_Click(Btn3, e);
                    break;
                case "D4":
                    NumBtn_Click(Btn4, e);
                    break;
                case "Numpad4":
                    NumBtn_Click(Btn4, e);
                    break;
                case "D5":
                    NumBtn_Click(Btn5, e);
                    break;
                case "Numpad5":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        PlusPercent_Click(sender, e);
                    else
                        NumBtn_Click(Btn5, e);
                    break;
                case "D6":
                    NumBtn_Click(Btn6, e);
                    break;
                case "Numpad6":
                    NumBtn_Click(Btn6, e);
                    break;
                case "D7":
                    NumBtn_Click(Btn7, e);
                    break;
                case "Numpad7":
                    NumBtn_Click(Btn7, e);
                    break;
                case "D8":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        Multiply_Click(sender, e);
                    else
                        NumBtn_Click(Btn8, e);
                    break;
                case "Numpad8":
                    NumBtn_Click(Btn8, e);
                    break;
                case "D9":
                    NumBtn_Click(Btn9, e);
                    break;
                case "Numpad9":
                    NumBtn_Click(Btn9, e);
                    break;
                case "Back":
                    Back_Click(sender, e);
                    break;
                case "Add":
                    Add_Click(sender, e);
                    break;
                case "OemPlus":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        Add_Click(sender, e);
                    else
                        Equal_Click(sender, e);
                    break;
                case "Multiply":
                    Multiply_Click(sender, e);
                    break;//D8
                case "Divide":
                    Divide_Click(sender, e);
                    break;
                case "OemQuestion":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        Comma_Click(sender, e);
                    else
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        Divide_Click(sender, e);
                    break;
                case "Subtract":
                    Subtract_Click(sender, e);
                    break;
                case "OemMinus":
                    if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
                        Subtract_Click(sender, e);
                    break;
                case "Decimal":
                    Comma_Click(sender, e);
                    break;
                case "OemComma":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        Comma_Click(sender, e);
                    break;
                case "OemPeriod":
                    if (!(local.CurrentInputLanguage.ToString() != "ru-Ru"))
                        Comma_Click(sender, e);
                    break;
            }
        }
    }
}
