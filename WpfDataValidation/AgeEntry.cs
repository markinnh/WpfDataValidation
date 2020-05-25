using MyWpfValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfDataValidation
{
    public class AgeEntry : IDataErrorInfo
    {
        Dictionary<string, string> _errors = new Dictionary<string, string>();
        const int minAge = 16;
        const int maxAge = 150;
        public static int MinimumAge { get; set; } = minAge;
        public static int MaximumAge { get; set; } = maxAge;
#if DEBUG
        static readonly string[] names = new string[] { "Fred", "Barney", "George", "Elroy", "Bob", "Chuck", "Joey", "Mark", "Tim", "Jeff", "Jim", "Cory" };
        static readonly Random random = new Random();
        static int pos = 0;
#endif
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                if (string.IsNullOrEmpty(name))
                {
                    var errMsg = $"{nameof(Name)} is a required input";
                    _errors.Update(nameof(Name), errMsg);
                }
                else
                    _errors.Remove(nameof(Name));
            }
        }
        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
                if (age < MinimumAge || age > MaximumAge)
                    _errors.Update(nameof(Age), $"{nameof(Age)} must be between {MinimumAge} and {MaximumAge}");
                else
                    _errors.Remove(nameof(Age));
            }
        }

        public AgeEntry()
        {
#if DEBUG
            Name = names[pos++];
            if (pos == names.Length)
                pos = 0;
            Age = random.Next(minAge, maxAge);
#endif
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.TryGetValue(nameof(Age), out string result))
                    return result;
                else if (_errors.TryGetValue(nameof(Name), out string nameResult))
                    return nameResult;
                else
                    return string.Empty;
                //throw new NotImplementedException();
            }
        }

        public string Error => null;
    }
}
