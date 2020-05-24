using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MyWpfValidators;

namespace WpfDataValidation
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        const int startMin = 16;
        const int startMax = 130;
        const int startAge = 50;
        const string AgeValidatorKey = "AgeLimits";
        IEnumerable<KeyValuePair<string, object>> validators = new KeyValuePair<string, object>[]
        {
            new KeyValuePair<string, object>(AgeValidatorKey, new Between<int>(startMin,
                                                                               startMax,
                                                                               includeMax:false))
        };

        protected void Set<T>(ref T target, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(target, value))
            {
                target = value;
                OnPropertyChanged(propertyName);
            }
        }
        //public int ViewMin { get; set; } = 25;
        private int viewMin = startMin;

        public int ViewMin
        {
            get => viewMin;
            set
            {
                Set<int>(ref viewMin, value, nameof(ViewMin));
                UpdateRanges();
                OnPropertyChanged(nameof(AgeInputPrompt));
            }
        }

        //public int ViewMax { get; set; } = 130;
        private int viewMax = startMax;

        public int ViewMax
        {
            get => viewMax;
            set
            {
                Set<int>(ref viewMax, value, nameof(ViewMax));
                UpdateRanges();
            }
        }
        public string AgeInputPrompt => $"enter an age between {ViewMin} and {ViewMax}";

        private void UpdateRanges()
        {
            System.Diagnostics.Debug.WriteLine($"Test of between : { 25.Between(15, 23)}");
            BaseFilterValidate.Validators.Update(AgeValidatorKey, new Between<int>(ViewMin, ViewMax, includeMax: false));
        }

        //public RangeValidate Validate { get; set; } = new RangeValidate() { Min = 25, Max = 90 };
        public int Age { get; set; } = startAge;

        public string Error => null;
        /// <summary>
        /// individual field validation based on the name of fields passed
        /// </summary>
        /// <param name="columnName">name of field to be validated</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Age))
                {
                    if (Age < ViewMin || Age > ViewMax)
                        return $"Age expected to be between {ViewMin} and {ViewMax}";
                }
                else if (columnName == nameof(ViewMin))
                {
                    if (ViewMin > ViewMax)
                        return $"Minimum age has to be less than maximum age";
                }
                else
                    System.Diagnostics.Debug.WriteLine($"accessing columnName : {columnName}");

                return string.Empty;
            }
        }

        public MainWindowViewModel()
        {
            //BaseFilterValidate.Ranges.Add("dedad7ba-ec74-4bce-996f-f538195d2509", new SpecifiedRange<int>(ViewMin, ViewMax));
            BaseFilterValidate.Validators.Update(validators);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
}
