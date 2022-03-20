using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace VideoShuffler.FileHandling
{

    /// <summary>
    /// Class for searching files
    /// </summary>
    public static class FileSearcher
    {
        /// <summary>
        /// Search files in a directory using filters
        /// </summary>
        /// <param name="directory">Directory to look up</param>
        /// <param name="filterText">filter to perform the search</param>
        /// <param name="searchOption">Options to use in case you wish to perform a recursive search, or just on the top directory</param>
        /// <remarks><code>filterText can be either exclusive or inclusive and accept multiple filters. 
        /// Just use <code>!</code> to perform a NOT operation</code> and use comma to separate search arguments.</remarks>
        /// <returns>An array of <code>FilePairInformation</code> containing the files found.</returns>
        public static FilePairInformation[] FindFiles(string directory, string filterText, SearchOption searchOption)
        {
            if (!Directory.Exists(directory)) return new FilePairInformation[] { };
            IEnumerable<string> include, exclude, rxfilters;

            (include, exclude, rxfilters) = buildFilter(filterText);

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

        /// <summary>
        /// Build the filters to be used during the search.
        /// </summary>
        /// <param name="filters">Filter text to be interpreted.</param>
        /// <remarks><paramref name="filters"/> can be either a windows search pattern, or use ! to negate and comma to separate multiple search filters.</remarks>
        /// <returns>A deconstructed object with: 
        /// - Include filters as a text (ok with file search patterns)
        /// - Exclude filters as a text (ok for checks on code)
        /// - A Regex filter to be applied while inspecting files
        /// </returns>
        private static (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>) buildFilter(string filters)
        {
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

            return (include, exclude, rxfilters);
        }
    }
}
