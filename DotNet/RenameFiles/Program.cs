using System;
using System.IO;
using System.Linq;

namespace RenameFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:\Spiritual\Swami Rama Yoga Sutras";

            int i = 0;
            foreach(var file in Directory.GetFiles(path))
            {
                FileInfo fileInfo = new FileInfo(file);
                string parentFolder = fileInfo.DirectoryName;
                string sourceFileName = fileInfo.Name;
                string extension = fileInfo.Extension;

                var startIndex = sourceFileName.IndexOf("(") + 1;
                var endIndex = sourceFileName.IndexOf(" 85)");

                if (endIndex > startIndex)
                {
                    var numericPart = sourceFileName.Substring(startIndex, (endIndex - startIndex));
                    numericPart = numericPart.PadLeft(3, '0');
                    var newFileName = numericPart + extension;
                    string destinationFileName = Path.Combine(parentFolder, newFileName);

                    File.Move(file, destinationFileName);
                    Console.WriteLine($"{(++i).ToString("00")}. {destinationFileName}");
                }
            }

            Console.WriteLine($"\n({i} files renamed)\n");
        }
    }
}
