using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfDataValidation
{
    public class AgeEntry : IDataErrorInfo
    {
        const int minAge = 16;
        const int maxAge = 150;
#if DEBUG
        static readonly string[] names = new string[] { "Fred", "Bob", "Chuck", "Joey", "Mark", "Tim" };
        static readonly Random random = new Random();
        static int pos = 0;
#endif
        public string Name { get; set; }
        public int Age { get; set; }

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
                if (columnName == nameof(Age) && (Age < minAge || Age > maxAge))
                {
                    return $"expecting an age between {minAge} and {maxAge}";
                }
                else if (columnName == nameof(Name) && string.IsNullOrEmpty(Name))
                    return $"{nameof(Name)} is expecting a value";
                else
                    return null;
                //throw new NotImplementedException();
            }
        }

        public string Error => null;
    }
}
