using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTools.ROPGadgetFinder
{
    public class FilePathResolver
    {
        /// <summary>
        /// Returns a list of file paths matching the provided path.
        /// The path can be:
        /// - A wildcard pattern (e.g. "C:\Logs\*.txt")
        /// - A directory (e.g. "C:\Logs")
        /// - A single file path (e.g. "C:\Logs\log.txt")
        /// </summary>
        public static IEnumerable<string> GetMatchingFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path), "Path cannot be null or empty.");

            if (path.Contains("*") || path.Contains("?"))
            {
                string directory = Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(directory))
                {
                    directory = Directory.GetCurrentDirectory();
                }

                string searchPattern = Path.GetFileName(path);

                if (!Directory.Exists(directory))
                    return Enumerable.Empty<string>();

                return Directory.GetFiles(directory, searchPattern, SearchOption.TopDirectoryOnly);
            }
            else if (Directory.Exists(path))
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            }
            else if (File.Exists(path))
            {
                return new List<string> { path };
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
