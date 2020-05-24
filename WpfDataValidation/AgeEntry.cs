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
        static readonly string[] names = new string[] { "Fred", "Bob", "Chuck", "Joey", "Mark", "Tim" };
        static int pos = 0;

        public string Name { get; set; }
        public int Age { get; set; }

        public AgeEntry()
        {
            Name = names[pos++];
            if (pos == names.Length)
                pos = 0;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Age))
                    if (Age < minAge || Age > maxAge)
                        return $"expecting an age between {minAge} and {maxAge}";
                    else if (columnName == nameof(Name))
                        if (string.IsNullOrEmpty(Name))
                            return $"{nameof(Name)} is expecting a value";
                throw new NotImplementedException();
            }
        }

        public string Error => null;
    }
}
