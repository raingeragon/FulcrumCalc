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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalcViewModel cvm;

        public MainWindow()
        {
            InitializeComponent();
            cvm = (CalcViewModel)DataContext;
            
        }
        void SetViewModel(string Context)
        {
            cvm.UpdateNumber = double.Parse(Context.ToString());
        }


        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            SetViewModel(Btn7.Content.ToString());
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            cvm.Add();
        }
    }
}
