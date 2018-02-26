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

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var op = (Button)sender;
            cvm.OperationSwitcher(op.Content.ToString(), cvm);
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            cvm.KeyBoardSwitcher(e.Key.ToString(), cvm);
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Theme_Checked(object sender, RoutedEventArgs e)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri("dark.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri("light.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
