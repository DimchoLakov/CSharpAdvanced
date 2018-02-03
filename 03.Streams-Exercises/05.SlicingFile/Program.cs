using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class Program
    {
        static void Main()
        {
            string sourceFile = "../Resources/sliceMe.mp4";
            string destinationDirectorySliced = "../Resources/Sliced/";
            string destinationDirectoryAssembled = "../Resources/Assembled/";

            int n = 5;

            Slice(sourceFile, destinationDirectorySliced, n);

            List<string> filenamesList = new List<string>
            {
                "../Resources/Sliced/Part0.mp4",
                "../Resources/Sliced/Part1.mp4",
                "../Resources/Sliced/Part2.mp4",
                "../Resources/Sliced/Part3.mp4",
                "../Resources/Sliced/Part3.mp4",
                "../Resources/Sliced/Part4.mp4"
            };

            Assemble(filenamesList, destinationDirectoryAssembled);
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string[] tokens = files[0].Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            string extension = tokens[tokens.Length - 1];

            string fileNamePath = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writeStream = new FileStream(fileNamePath, FileMode.Create))
            {
                foreach (string file in files)
                {
                    using (FileStream readStream = new FileStream(file, FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];
                        int bufferSize = buffer.Length;
                        while (readStream.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writeStream.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            string[] tokens = sourceFile.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string extension = tokens[tokens.Length - 1];

            using (FileStream readStream = new FileStream(sourceFile, FileMode.Open))
            {
                long singlePartSize = (long)Math.Ceiling((double)readStream.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    string currentFileName = destinationDirectory + $"Part{i}.{extension}";

                    long currentPartSize = 0;

                    using (FileStream writeStream = new FileStream(currentFileName, FileMode.Create))
                    {
                        int bufferSize = 4096;
                        byte[] buffer = new byte[bufferSize];

                        while (readStream.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writeStream.Write(buffer, 0, bufferSize);
                            currentPartSize += bufferSize;
                            if (currentPartSize >= singlePartSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
