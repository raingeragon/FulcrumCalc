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

            
            var uri = new Uri("light.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            var num = (((sender as Button).Content as Viewbox).Child as TextBlock).Text;
            cvm.TxtUpdate(num);
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            
            var op = (((sender as Button).Content as Viewbox).Child as TextBlock).Text;
            cvm.OperationSwitcher(op, cvm);
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            cvm.KeyBoardSwitcher(e.Key.ToString(), cvm);
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
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

        private void Light_Click(object sender, RoutedEventArgs e)
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
