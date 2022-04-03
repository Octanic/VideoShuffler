using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace VideoShuffler.Registry
{
    public class WindowsRegistryManager : IRegistryManager
    {

        public IDictionary<string, string> ReadKey(string key, bool createIfEmpty)
        {
            RegistryKey registryKey = getWindowsKey(key, createIfEmpty);

            if (registryKey == null) return null;

            Dictionary<string, string> regk = new Dictionary<string, string>();
            foreach (var name in registryKey.GetValueNames())
            {
                regk.Add(name, Convert.ToString(registryKey.GetValue(name)));
            }

            return regk;
        }

        private static RegistryKey getWindowsKey(string key, bool createIfEmpty)
        {
            RegistryKey registryKey;
            try
            {
                registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key, true);
            }
            catch (Exception x)
            {
                throw new System.IO.IOException($"Falha de leitura do registro: {x.Message}\r\nChave:{key}", x);
            }

            if (registryKey == null && createIfEmpty)
            {
                try
                {
                    registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key);
                }
                catch (Exception x)
                {
                    throw new System.IO.IOException($"Falha ao escrever registro: {x.Message}\r\nChave:{key}", x);
                }
            }

            return registryKey;
        }

        public void WriteKey(string key, bool createIfEmpty, IDictionary<string, Tuple<string, RegistryValueKind>> keyValuePairs)
        {
            var k = getWindowsKey(key, createIfEmpty);
            foreach (var item in keyValuePairs)
            {
                k.SetValue(item.Key, item.Value.Item1, item.Value.Item2);
            }
            k.Close();
        }
    }
}
