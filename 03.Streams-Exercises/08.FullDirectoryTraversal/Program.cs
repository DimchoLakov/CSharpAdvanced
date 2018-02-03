using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();
            
            List<FileInfo> fileInfoList = new List<FileInfo>();

            List<string> directoryList = new List<string>();

            directoryList.Add(path);

            while (directoryList.Count > 0)
            {
                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                { 
                    FileInfo fileInfo = new FileInfo(file);
                    
                    fileInfoList.Add(fileInfo);
                }

                string[] directories = Directory.GetDirectories(path);

                foreach (string directory in directories)
                {
                    directoryList.Add(directory);
                }
                path = directoryList.LastOrDefault();
                directoryList.RemoveAt(directoryList.Count - 1);
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            desktop += "\\result.txt";

            using (StreamWriter writeStream = new StreamWriter(desktop))
            {
                var sortedFiles = fileInfoList.GroupBy(x => x.Extension).OrderByDescending(group => group.Count())
                    .ThenBy(group => group.Key).ToList();

                foreach (var group in sortedFiles)
                {
                    writeStream.WriteLine(group.Key);

                    foreach (var fileInfo in group)
                    {
                        writeStream.WriteLine($"--{fileInfo.Name} - {fileInfo.Length / 1024}kb");
                    }
                }
            }
        }
    }
}
