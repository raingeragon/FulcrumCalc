using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FulcrumCalc
{
    public class SkinResourceDictionary : ResourceDictionary
    {
        private Uri _lightTheme;
        private Uri _darkTheme;

        public Uri LightTheme
        {
            get
            {
                return _lightTheme;
            }
            set
            {
                _lightTheme = value;
                UpdateSource();
            }
        }

        public Uri DarkTheme
        {
            get
            {
                return _darkTheme;
            }
            set
            {
                _darkTheme = value;
                UpdateSource();
            }
        }

        public void UpdateSource()
        {
            var val = App.Skin == Skin.Light ? LightTheme : DarkTheme;
            if (val != null && Source != val)
                Source = val;
        }
    }

}
