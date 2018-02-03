using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

            foreach (string file in files)
            {
                string[] tokens = file.Split(new string[] { ".\\" }, StringSplitOptions.RemoveEmptyEntries);

                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary.Add(extension, new List<FileInfo>());
                }
                filesDictionary[extension].Add(fileInfo);
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            desktop += "\\result.txt";

            using (StreamWriter writeStream = new StreamWriter(desktop))
            {
                var sortedFilesDict = filesDictionary.OrderByDescending(x => x.Value.Count).ToDictionary(k => k.Key, v => v.Value);

                foreach (KeyValuePair<string, List<FileInfo>> extFilesPair in filesDictionary.OrderByDescending(f => f.Value.Count))
                {
                    writeStream.WriteLine(extFilesPair.Key);
                    
                    var sortedFileInfos = extFilesPair.Value.OrderByDescending(f => f.Length).ToList();

                    foreach (FileInfo sortedFileInfo in sortedFileInfos.OrderBy(x => x.Name))
                    {
                        writeStream.WriteLine($"--{sortedFileInfo.Name} - {sortedFileInfo.Length / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
