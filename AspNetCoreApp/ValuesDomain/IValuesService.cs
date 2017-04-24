using System.Collections.Generic;

namespace AspNetCoreApp.ValuesDomain
{
    public interface IValuesService
    {
        IEnumerable<string> GetAll();
        string GetBy(int id);
    }
}