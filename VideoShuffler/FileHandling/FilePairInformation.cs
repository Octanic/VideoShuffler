using System.IO;

namespace VideoShuffler.FileHandling
{
    public class FilePairInformation
    {
        public string FileName { get; private set; }
        public string Path { get; private set; }

        public FilePairInformation(string path)
        {
            Path = path;
            FileInfo fi = new FileInfo(path);
            FileName = fi.Name;
        }

    }
}
