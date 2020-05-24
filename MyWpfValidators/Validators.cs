using System;
using System.Collections.Generic;
using System.Text;

namespace WpfDataValidation
{
    /// <summary>
    /// Stored as objects, to allow mixing types within the collection.
    /// </summary>
    public class Validators
    {
        private readonly Dictionary<string, object> cachedFilters = new Dictionary<string, object>();

        public void Update(string Key,object value)
        {
            if (cachedFilters.ContainsKey(Key))
                cachedFilters[Key] = value;
            else
                cachedFilters.Add(Key, value);
        }
        public void Update(IEnumerable<KeyValuePair<string,object>> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                Update(item.Key, item.Value);
            }
        }
        public bool TryGetValue(string Key,out object value)
        {
            return cachedFilters.TryGetValue(Key, out value);
        }
    }
}
