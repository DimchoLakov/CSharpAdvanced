using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main()
        {
            using (Stream readStream = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (Stream writeStream = new FileStream("../Resources/copyOfCopyMe.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytesCount = readStream.Read(buffer, 0, buffer.Length);
                        if (readBytesCount == 0)
                        {
                            break;
                        }
                        writeStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
