using System.ComponentModel;
using FulcrumCalc.Models;
namespace FulcrumCalc.ViewModels
{
    class CalcViewModel : INotifyPropertyChanged
    {
        private double tempNumber;
        private CalcModel model;
        LastOperation lastoperation;
        bool bnewEntry;

        public CalcViewModel()
        {
            model = new CalcModel();
            tempNumber = 0;
            lastoperation = LastOperation.None;
            bnewEntry = false;
        }

        public double UpdateNumber
        {
            get
            {
                return model.Number;
            }
            set
            {
                if (model.Number == 0 || bnewEntry)
                {
                    model.Number = value;
                    bnewEntry = false;
                }
                else
                    model.Number = double.Parse(model.Number.ToString() + value.ToString());
            }
        }
        public void Add()
        {
            if (lastoperation == LastOperation.Add)
            {
                double sum = model.Add(UpdateNumber, tempNumber);
                Clear();
                UpdateNumber = sum;
            }
        }

        public void Clear()
        {
            model.Number = 0;
            UpdateNumber = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        enum LastOperation
        {
            None,
            Add
        };
    }
}
