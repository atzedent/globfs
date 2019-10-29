using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Globkit;

namespace globfs
{
    static class Program
    {
        static void Main(string[] args)
        {
            var searchTree = new FilesystemSearchTree();
            var search = new Search(searchTree);
            var result = search.FindLeaves(args.FirstOrDefault());
            foreach (var file in result)
                Console.WriteLine(file);
        }
    }
    class FilesystemSearchTree : ISearchTree
    {
        public char PathSeparator => Path.DirectorySeparatorChar;
        public bool BranchExists(string path)
        {
            try { return Directory.Exists(path); }
            catch { return false; }
        }
        public string CombinePaths(string first, string second)
        {
            return Path.Combine(first, second);
        }
        public IEnumerable<string> GetBranches(string path)
        {
            try { return Directory.EnumerateDirectories(path); }
            catch { return Enumerable.Empty<string>(); }
        }
        public IEnumerable<string> GetBranches(string path, string filter)
        {
            try { return Directory.EnumerateDirectories(path, filter); }
            catch { return Enumerable.Empty<string>(); }
        }
        public IEnumerable<string> GetLeaves(string path)
        {
            try { return Directory.EnumerateFiles(path); }
            catch { return Enumerable.Empty<string>(); }
        }
        public IEnumerable<string> GetLeaves(string path, string filter)
        {
            try { return Directory.EnumerateFiles(path, filter); }
            catch { return Enumerable.Empty<string>(); }
        }
        public string GetPathRoot(string path)
        {
            return Path.GetPathRoot(path);
        }
        public IEnumerable<string> GetTreeRoots()
        {
            return Environment.GetLogicalDrives();
        }
        public bool IsPathRooted(string path)
        {
            return Path.IsPathRooted(path);
        }
    }
}
