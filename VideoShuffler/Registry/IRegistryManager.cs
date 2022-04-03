using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShuffler.Registry
{

    /// <summary>
    /// Interface to wrap Microsoft.Win32.Registry
    /// </summary>
    public interface IRegistryManager
    {

        IDictionary<string, string> ReadKey(string key, bool createIfEmpty);

        void WriteKey(string key, bool createIfEmpty, IDictionary<string, Tuple<string, RegistryValueKind>> keyValuePairs);

    }
}
