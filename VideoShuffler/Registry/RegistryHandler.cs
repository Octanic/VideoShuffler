using System;
using VideoShuffler.EntryHandler;

namespace VideoShuffler.Registry
{
    /// <summary>
    /// Class that will handle Registry
    /// </summary>
    public class RegistryHandler:IEntryHandler
    {

        private const string KEY_PASTA_ORIGEM = "PastaOrigem";
        private const string KEY_APLICATIVO_READER = "AplicativoReader";
        private const string KEY_FILTRO = "Filtro";
        private const string KEY_QTD_ARQUIVOS = "QtdArquivos";

        private readonly string _context;
        private string lastError;
        public string RegistryPath { get; private set; }

        public RegistryHandler(string context)
        {
            _context = context;
            RegistryPath = $"SOFTWARE\\VideoShuffler\\{_context}";
        }


        public KeyWrapper<Entry> Read()
        {
            var r = new KeyWrapper<Entry>();

            var key = forceGetKey(RegistryPath);

            if (key == null)
            {
                r.Error = lastError;
                r.IsValid = false;
            }
            else
            {
                r.Entry = new Entry()
                {
                    PastaOrigem = Convert.ToString(key.GetValue(KEY_PASTA_ORIGEM)),
                    AplicativoReader = Convert.ToString(key.GetValue(KEY_APLICATIVO_READER)),
                    Filtro = Convert.ToString(key.GetValue(KEY_FILTRO)),
                    QtdArquivos = Convert.ToInt32(key.GetValue(KEY_QTD_ARQUIVOS) ?? 0)
                };
                r.IsValid = true;
            }

            key.Close();
            lastError = string.Empty;
            return r;
        }

        private Microsoft.Win32.RegistryKey forceGetKey(string key)
        {
            Microsoft.Win32.RegistryKey registryKey = null;
            try
            {
                registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key, true);
            }
            catch (Exception x)
            {
                lastError = $"Falha de leitura do registro: {x.Message}";
            }

            if (registryKey == null)
            {
                try
                {
                    registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key);

                }
                catch (Exception x)
                {
                    lastError = $"Falha ao escrever registro: {x.Message}";
                }
            }

            return registryKey;

        }

        public KeyWrapper<bool> Write(Entry entry)
        {
            var k = forceGetKey(RegistryPath);

            if (k == null)
            {
                return new KeyWrapper<bool>()
                {
                    IsValid = false,
                    Error = lastError
                };
            }

            k.SetValue(KEY_FILTRO, entry.Filtro, Microsoft.Win32.RegistryValueKind.String);
            k.SetValue(KEY_QTD_ARQUIVOS, entry.QtdArquivos, Microsoft.Win32.RegistryValueKind.DWord);
            k.SetValue(KEY_APLICATIVO_READER, entry.AplicativoReader, Microsoft.Win32.RegistryValueKind.String);
            k.SetValue(KEY_PASTA_ORIGEM, entry.PastaOrigem, Microsoft.Win32.RegistryValueKind.String);

            k.Close();

            return new KeyWrapper<bool>()
            {
                IsValid = true
            };
        }
    }
}
