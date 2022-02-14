using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShuffler.Registry
{
    public class KeyWrapper<T>
    {
        public T Entry { get; set; }

        public bool IsValid { get; set; }
        public string Error { get; set; }
    }
}
