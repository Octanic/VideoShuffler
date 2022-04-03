using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VideoShuffler.Tests")]
namespace VideoShuffler.EntryHandler
{
    /// <summary>
    /// Represents one registry entry to be read
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Source folder
        /// </summary>
        public string PastaOrigem { get; internal set; }
        /// <summary>
        /// Application used to read files
        /// </summary>
        public string AplicativoReader { get; internal set; }
        /// <summary>
        /// Text used to filter the files
        /// </summary>
        public string Filtro { get; internal set; }
        /// <summary>
        /// Amount of files to randomly pick
        /// </summary>
        public int QtdArquivos { get; internal set; }
    }
}
