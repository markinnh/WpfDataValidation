using System;
using System.Collections.Generic;
using System.Text;

namespace MyWpfValidators
{
    public interface IPropertyLink
    {
        string PropertyName { get; set; }
    }
    public interface IMyValidator<T>
    {
        bool Succeeds(T Compare);
        string FilterError { get; }
    }

    public interface IMyValidatorSupported
    {
        IEnumerable<KeyValuePair<string, object>> Validators();
    }
}
