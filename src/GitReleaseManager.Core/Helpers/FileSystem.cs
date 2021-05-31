using System;
using System.Collections.Generic;
using System.IO;
using GitReleaseManager.Core.Options;

namespace GitReleaseManager.Core.Helpers
{
    public class FileSystem : IFileSystem
    {
        private readonly BaseSubOptions options;

        public FileSystem(BaseSubOptions options)
        {
            this.options = options;
        }

        public void Copy(string @source, string destination, bool overwrite)
        {
            File.Copy(@source, destination, overwrite);
        }

        public void Move(string @source, string destination)
        {
            File.Move(@source, destination);
        }

        public bool Exists(string file)
        {
            return File.Exists(file);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public string ResolvePath(string path)
        {
            if (Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(options.TargetDirectory ?? Environment.CurrentDirectory, path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(string file, string fileContents)
        {
            File.WriteAllText(file, fileContents);
        }

        public IEnumerable<string> DirectoryGetFiles(string directory, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(directory, searchPattern, searchOption);
        }

        public Stream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}