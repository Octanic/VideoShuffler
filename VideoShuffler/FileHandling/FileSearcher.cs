using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace VideoShuffler.FileHandling
{
    public static class FileSearcher
    {
        public static FilePairInformation[] FindFiles(string directory, string filters, SearchOption searchOption)
        {
            if (!Directory.Exists(directory)) return new FilePairInformation[] { };

            var include = (from filter in filters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) 
                           where !string.IsNullOrEmpty(filter.Trim()) 
                           select filter.Trim());

            var exclude = (from filter in include 
                           where filter.Contains(@"!") 
                           select filter);

            include = include.Except(exclude);

            if (include.Count() == 0) include = new string[] { "*" };

            var rxfilters = from filter in exclude 
                            select string.Format("^{0}$", filter.Replace("!", string.Empty).Replace(".", @"\.").Replace("*", ".*").Replace("?", "."));

            Regex regex = new Regex(string.Join("|", rxfilters.ToArray()), RegexOptions.IgnoreCase);

            List<Thread> workers = new List<Thread>();
            List<string> files = new List<string>();

            foreach (string filter in include)
            {
                Thread worker = new Thread(
                    new ThreadStart(
                        delegate
                        {
                            string[] allfiles = Directory.GetFiles(directory, filter, searchOption);
                            if (exclude.Count() > 0)
                            {
                                lock (files)
                                {
                                    files.AddRange(allfiles.Where(p => !regex.Match(p).Success));
                                }
                            }
                            else
                            {
                                lock (files)
                                {
                                    files.AddRange(allfiles);
                                }
                            }
                        }
                    ));

                workers.Add(worker);

                worker.Start();
            }

            foreach (Thread worker in workers)
            {
                worker.Join();
            }

            return files.Select(x => new FilePairInformation(x)).ToArray();

        }


        public static FilePairInformation[] FindFilesNonThreaded(string directory, string filters, SearchOption searchOption)
        {
            var filterArr = filters.Split(',').Where(x=>!x.Contains("!"));
            var filterExc = filters.Split(',').Where(x => x.Contains("!"));

            string[] retorno;

            if (!filterArr.Any()) filterArr = new string[] { "*" };

            var rxfilters = from filter in filterExc
                            select string.Format("^{0}$", filter.Replace("!", string.Empty).Replace(".", @"\.").Replace("*", ".*").Replace("?", "."));

            Regex regex = new Regex(string.Join("|", rxfilters.ToArray()), RegexOptions.IgnoreCase);

            var arquivos = (from fi in filterArr
                           select Directory.EnumerateFiles(directory, fi, searchOption)).SelectMany(x=>x);

            if (filterExc.Any())
            {
                retorno = (from a in arquivos
                           where !regex.IsMatch(a)
                           select a).ToArray();
            }
            else
            {
                retorno = arquivos.ToArray();
            }

            return retorno.Select(x => new FilePairInformation(x)).ToArray();

        }


    }
}
