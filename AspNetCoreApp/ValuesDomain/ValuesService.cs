using System;
using System.Collections.Generic;

namespace AspNetCoreApp.ValuesDomain
{
    public class ValuesService : IValuesService
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        public string GetBy(int id)
        {
            return "value " + id;
        }
    }
}
