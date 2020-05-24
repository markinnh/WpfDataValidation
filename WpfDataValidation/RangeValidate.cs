using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MyWpfValidators;

namespace WpfDataValidation
{

    public abstract class BaseFilterValidate:ValidationRule
    {
        public static Validators Validators { get; protected set; } = new Validators();

    }
    public class IntFilterValidate : BaseFilterValidate
    {

        public string Key { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Validators.TryGetValue(Key, out object result))
            {
                if (result is IMyValidator<int> validator)
                {
                    if (int.TryParse((string)value, out int age))
                    {
                        if (!validator.Succeeds(age))
                            return new ValidationResult(false, validator.FilterError);
                        else
                            return ValidationResult.ValidResult;
                    }
                    else
                        return new ValidationResult(false, $"unable to parse {value} into an integer.");
                }
                else
                    return new ValidationResult(false, $"stored range in incorrect format");
            }
            else
                return new ValidationResult(false, $"unable to find range indexed by {Key}");
        }
    }
    public class LessThanValidate : ValidationRule
    {
        public static readonly DependencyProperty  MaximumProperty = DependencyProperty.RegisterAttached("Maximum", typeof(int), typeof(TextBox));

        public static void SetMaximum(UIElement element, int value) => element.SetValue(MaximumProperty, value);
        public static int GetMaximum(UIElement element) => (int)element.GetValue(MaximumProperty);

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
