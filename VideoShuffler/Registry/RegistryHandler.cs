using System;
using System.Collections.Generic;
using VideoShuffler.EntryHandler;

namespace VideoShuffler.Registry
{
    /// <summary>
    /// Class that will handle Registry
    /// </summary>
    public class RegistryHandler : IEntryHandler
    {

        private const string KEY_PASTA_ORIGEM = "PastaOrigem";
        private const string KEY_APLICATIVO_READER = "AplicativoReader";
        private const string KEY_FILTRO = "Filtro";
        private const string KEY_QTD_ARQUIVOS = "QtdArquivos";

        private readonly string _context;
        public string RegistryPath { get; private set; }

        private readonly IRegistryManager _registryManager;

        public RegistryHandler(string context, IRegistryManager registryManager)
        {
            _context = context;
            RegistryPath = $"SOFTWARE\\VideoShuffler\\{_context}";
            _registryManager = registryManager;
        }


        public KeyWrapper<Entry> Read()
        {
            var r = new KeyWrapper<Entry>();

            var k = _registryManager.ReadKey(RegistryPath, true);

            if (k == null)
            {
                r.Error = $"Não foi possível abrir a chave {RegistryPath}";
                r.IsValid = false;
            }
            else
            {

                r.Entry = new Entry()
                {
                    PastaOrigem = Convert.ToString(k[KEY_PASTA_ORIGEM]),
                    AplicativoReader = Convert.ToString(k[KEY_APLICATIVO_READER]),
                    Filtro = Convert.ToString(k[KEY_FILTRO]),
                    QtdArquivos = Convert.ToInt32(k[KEY_QTD_ARQUIVOS])
                };
                r.IsValid = true;

            }

            return r;
        }

        public KeyWrapper<bool> Write(Entry entry)
        {
            var values = new Dictionary<string, Tuple<string, Microsoft.Win32.RegistryValueKind>>
            {
                { KEY_FILTRO, new Tuple<string, Microsoft.Win32.RegistryValueKind>(entry.Filtro, Microsoft.Win32.RegistryValueKind.String) },
                { KEY_QTD_ARQUIVOS, new Tuple<string, Microsoft.Win32.RegistryValueKind>(Convert.ToString(entry.QtdArquivos), Microsoft.Win32.RegistryValueKind.DWord) },
                { KEY_APLICATIVO_READER, new Tuple<string, Microsoft.Win32.RegistryValueKind>(entry.AplicativoReader, Microsoft.Win32.RegistryValueKind.String) },
                { KEY_PASTA_ORIGEM, new Tuple<string, Microsoft.Win32.RegistryValueKind>(entry.PastaOrigem, Microsoft.Win32.RegistryValueKind.String) }
            };

            try
            {
                _registryManager.WriteKey(RegistryPath, true, values);
            }
            catch(Exception x)
            {
                return new KeyWrapper<bool>()
                {
                    IsValid = false,
                    Error = x.Message
                };

            }

            return new KeyWrapper<bool>()
            {
                IsValid = true
            };
        }
    }
}
