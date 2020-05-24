using System;
using System.Collections.Generic;
using System.Text;

namespace MyWpfValidators
{
    public static class Extensions
    {
        public static bool Between<T>(this T comparable, T minimum, T maximum, bool includeMin = true, bool includeMax = true) where T : struct, IComparable<T>
        {
            System.Diagnostics.Debug.WriteLine($"Check if {comparable} is between {minimum} {(includeMin ? $"(including {minimum})" : $"(excluding {minimum})")} and {maximum} {(includeMax ? $"(including {maximum})" : $"(excluding {maximum})")}");
            var result = new Between<T>(minimum, maximum, includeMin, includeMax);
            return result.Succeeds(comparable);
        }
    }
}
