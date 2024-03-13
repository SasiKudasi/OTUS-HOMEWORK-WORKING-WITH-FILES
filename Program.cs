using System.IO;

namespace HW7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathOne = "C:\\Otus\\TestDir1\\";
            var pathTwo = "C:\\Otus\\TestDir2\\";
            Command(pathOne);
            Command(pathTwo);
        }

        static void Command(string path)
        {
            var dir = CreatADir(path);
            CreatAFile(dir);
            WriteIntoFile(dir);
            ReadAllFiles(dir);
        }

        static DirectoryInfo CreatADir(string path)
        {
            var dir = new DirectoryInfo(path);
            dir.Create();
            return dir;
        }
        static void CreatAFile(DirectoryInfo dir)
        {
            FileStream file;

            for (int i = 1; i <= 10; i++)
            {
                file = File.Create(dir.FullName + "File" + i);
                file.Close();
            }
        }
        static void WriteIntoFile(DirectoryInfo dir)
        {
            var files = dir.GetFiles();
            DateTime dateTime = DateTime.Now;
            foreach (var f in files)
            {
                if (f.Exists)
                {
                    using (StreamWriter sw = File.CreateText(f.FullName))
                    {
                        sw.Write(f.Name);
                        sw.Write($" {dateTime}");
                        sw.WriteLine();
                        sw.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Файла не существует");
                }
            }
        }

        static void ReadAllFiles(DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
            {
                using (StreamReader stream = File.OpenText(f.FullName))
                {
                    Console.WriteLine($"{f} : {stream.ReadToEnd()}");
                }
            }
        }
    }
}