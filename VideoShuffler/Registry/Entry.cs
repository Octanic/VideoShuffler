using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShuffler.Registry
{
    public class Entry
    {
        public string PastaOrigem { get; internal set; }
        public string AplicativoReader { get; internal set; }
        public string Filtro { get; internal set; }
        public int QtdArquivos { get; internal set; }
    }
}
