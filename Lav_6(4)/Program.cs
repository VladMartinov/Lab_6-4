using System;
using System.IO;
class Lab6
{
    static void Main()
    {
        string path1 = @"C:\Lab6_Temp";
        string path2 = @"C:\SomeDir3\lab.dat";
        string path3 = @"C:\Lab6_Temp\lab_backup.dat";
        DirectoryInfo dirInfo = new DirectoryInfo(path1);
        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }
        using (StreamReader fs = new StreamReader(path2, System.Text.Encoding.Default))
        using (FileStream fs1 = File.Create(path3))
        {
            string line;
            while ((line = fs.ReadLine()) != null)
            {
                foreach (char c in line)
                {
                    fs1.WriteByte((byte)c);
                }
            }
        }
        Console.WriteLine("Информация о фале lab.dat");
        FileInfo file = new FileInfo(@"C:\SomeDir3\lab.dat");
        Console.WriteLine($"Размер : {file.Length} байт");
        Console.WriteLine($"Время последнего изменения : {file.LastWriteTime}");
        Console.WriteLine($"Время последнего доступа : {file.LastAccessTime}");
    }
}