using System;
using System.IO;

namespace FileWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users/cavva/Desktop/sss";
            DeleteCatalog(path);
        }
        static public void DeleteCatalog(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                if (dirInfo.Exists)
                {
                    var files = dirInfo.GetFiles();
                    var directories = dirInfo.GetDirectories();

                    foreach (var directory in directories)
                    {
                        if (directory.LastAccessTime.AddMinutes(30) < DateTime.Now)
                        {
                            directory.Delete(true);
                        }
                    }
                    foreach (var file in files)
                    {
                        if (file.LastAccessTime.AddMinutes(30) < DateTime.Now)
                        {
                            file.Delete();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Папки по данному пути не существует, проверьте правильность ввода!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

