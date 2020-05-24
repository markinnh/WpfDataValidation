using System;

namespace MyWpfValidators
{
    /// <summary>
    /// Should work for all .NET types, including strings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MyWpfValidators.IMyValidator{T}" />
    public struct GreaterThan<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        public T ValidValue { get; set; }
        public string FilterError => $"Enter a value greater than {ValidValue}";
        public GreaterThan(T filterValue)
        {
            ValidValue = filterValue;
        }

        public bool Succeeds(T Compare)
        {
            return ValidValue.CompareTo(Compare) == -1;
        }
    }

    public struct LessThan<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        public T ValidValue { get; set; }
        public string FilterError => $"Enter a value less than {ValidValue}";

        public LessThan(T filterValue)
        {
            ValidValue = filterValue;
        }

        public bool Succeeds(T Compare)
        {
            return ValidValue.CompareTo(Compare) == 1;
        }
    }
    public struct EqualTo<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        public T ValidValue { get; set; }
        public string FilterError => $"Compare as equal to {ValidValue}";

        public bool Succeeds(T Compare)
        {
            return ValidValue.CompareTo(Compare) == 0;
        }
    }

    public struct LessThanOrEqualTo<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        public T ValidValue { get; set; }
        public string FilterError => $"Enter a value less than or equal to {ValidValue}";
        public LessThanOrEqualTo(T initial)
        {
            ValidValue = initial;
        }
        public bool Succeeds(T Compare)
        {
            var compareTo = ValidValue.CompareTo(Compare);
            return compareTo == 0 || compareTo == 1;
        }
    }
    public struct GreaterThanOrEqualTo<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        public T ValidValue { get; set; }
        public string FilterError => $"Enter a value greater than or equal to {ValidValue}";
        public GreaterThanOrEqualTo(T initial)
        {
            ValidValue = initial;
        }

        public bool Succeeds(T Compare)
        {
            var compareTo = ValidValue.CompareTo(Compare);
            return compareTo == -1 || compareTo == 0;
        }
    }
    public struct Between<T> : IMyValidator<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// greater than (or equal to) the first validator
        /// </summary>
        public IMyValidator<T> LowerBound { get; set; }
        /// <summary>
        /// less than (or equal to) the second validator
        /// </summary>
        public IMyValidator<T> UpperBound { get; set; }
        public string FilterError => UpperBound.FilterError + " " + LowerBound.FilterError;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minimum">lower bound of range</param>
        /// <param name="maximum">upper bound of range</param>
        /// <param name="includeMin">include the minimum as part of the lower bound</param>
        /// <param name="includeMax">include the maximum as part of the upper bound</param>
        public Between(T minimum, T maximum, bool includeMin = true, bool includeMax = true)
        {
            LowerBound = includeMin ? (IMyValidator<T>)new GreaterThanOrEqualTo<T>(minimum) : new GreaterThan<T>(minimum);
            UpperBound = includeMax ? (IMyValidator<T>)new LessThanOrEqualTo<T>(maximum) :new LessThan<T>(maximum);
        }

        public bool Succeeds(T Compare)
        {
            return LowerBound.Succeeds(Compare) && UpperBound.Succeeds(Compare);
        }
    }
}
