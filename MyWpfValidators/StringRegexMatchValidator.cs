using System;
using System.Collections.Generic;
using System.Text;

namespace MyWpfValidators
{
    public struct StringRegexMatchValidator : IMyValidator<string>
    {
        public string Pattern { get; set; }
        public string FilterError => $"expected to match regex pattern : {Pattern}";

        public bool Succeeds(string Compare)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Compare,Pattern);
        }
    }
}
