using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FulcrumCalc
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public enum Skin
    {
        Light,
        Dark
    }
    public partial class App : Application
    {
        public static Skin Skin { get; set; } = Skin.Light;
        public void ChangeSkin(Skin newSkin)
        {
            Skin = newSkin;
            foreach(ResourceDictionary dict in Resources.MergedDictionaries)
            {
                if (dict is SkinResourceDictionary skinDict)
                    skinDict.UpdateSource();
                else
                    dict.Source = dict.Source;
            }
        }
    }
}
