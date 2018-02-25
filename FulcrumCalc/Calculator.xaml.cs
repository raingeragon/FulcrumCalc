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
    /// <summary>
    /// Логика взаимодействия для NiceSquare.xaml
    /// </summary>
    public partial class Calculator : UserControl
    {
        CalcViewModel cvm;
        public Calculator()
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

        private void Plus_Click(object sender, RoutedEventArgs e) => cvm.Add();
        private void Subtract_Click(object sender, RoutedEventArgs e) => cvm.Subtract();
        private void Multiply_Click(object sender, RoutedEventArgs e) => cvm.Multiply();
        private void Divide_CLick(object sender, RoutedEventArgs e) => cvm.Divide();
        private void Sqrt_Click(object sender, RoutedEventArgs e) => cvm.Sqrt();
        private void Inverse_Click(object sender, RoutedEventArgs e) => cvm.Inverse();
        private void PlusPercent_Click(object sender, RoutedEventArgs e) => cvm.PlusPercent();
        private void Clear_Click(object sender, RoutedEventArgs e) => cvm.Clear();
        private void ClearAll_Click(object sender, RoutedEventArgs e) => cvm.ClearAll();
        private void Equal_Click(object sender, RoutedEventArgs e) => cvm.Equal();
        private void Opposite_Click(object sender, RoutedEventArgs e) => cvm.Opposite();
    }
}
