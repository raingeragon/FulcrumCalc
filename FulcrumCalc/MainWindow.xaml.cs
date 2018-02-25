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
        void SetViewModel(string Context) => cvm.UpdateNumber = double.Parse(Context.ToString());

        private void Btn0_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn0.Content.ToString());
        private void Btn1_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn1.Content.ToString());
        private void Btn2_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn2.Content.ToString());
        private void Btn3_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn3.Content.ToString());
        private void Btn4_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn4.Content.ToString());
        private void Btn5_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn5.Content.ToString());
        private void Btn6_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn6.Content.ToString());
        private void Btn7_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn7.Content.ToString());
        private void Btn8_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn8.Content.ToString());
        private void Btn9_Click(object sender, RoutedEventArgs e) => SetViewModel(Btn9.Content.ToString());

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
                    Btn0_Click(sender, e);
                    
                    break;
                case "Numpad0":
                    Btn0_Click(sender, e);
                    break;
                case "D1":
                    Btn1_Click(sender, e);
                    break;
                case "Numpad1":
                    Btn1_Click(sender, e);
                    break;
                case "D2":
                    Btn2_Click(sender, e);
                    break;
                case "Numpad2":
                    Btn2_Click(sender, e);
                    break;
                case "D3":
                    Btn3_Click(sender, e);
                    break;
                case "Numpad3":
                    Btn3_Click(sender, e);
                    break;
                case "D4":
                    Btn4_Click(sender, e);
                    break;
                case "Numpad4":
                    Btn4_Click(sender, e);
                    break;
                case "D5":
                    Btn5_Click(sender, e);
                    break;
                case "Numpad5":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        PlusPercent_Click(sender, e);
                    else
                        Btn5_Click(sender, e);
                    break;
                case "D6":
                    Btn6_Click(sender, e);
                    break;
                case "Numpad6":
                    Btn6_Click(sender, e);
                    break;
                case "D7":
                    Btn7_Click(sender, e);
                    break;
                case "Numpad7":
                    Btn7_Click(sender, e);
                    break;
                case "D8":
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                        Multiply_Click(sender, e);
                    else
                        Btn8_Click(sender, e);
                    break;
                case "Numpad8":
                    Btn8_Click(sender, e);
                    break;
                case "D9":
                    Btn9_Click(sender, e);
                    break;
                case "Numpad9":
                    Btn9_Click(sender, e);
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
                        Equal_Click(sender,e);
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
                    if (!(local.CurrentInputLanguage.ToString()!="ru-Ru"))
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
