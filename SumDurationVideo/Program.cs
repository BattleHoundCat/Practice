using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaToolkit;

namespace VideoFileDurationFramework
{
    class Program
    {
       public static  int sumhours; //здесь подсчитывается,итоговое время в часах
       public static int summinutes; // здесь подсчитывается, сколько минут еще сверху часов
        static double sumDuration;
        private static void PrintResult()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Итоговая длительность в минутах= {sumDuration}");
            Console.WriteLine($"Итоговая длительность в часах и минутах= {sumhours} ч. {summinutes} мин.");
        }
        static void Main(string [] args)
        {
            string[] videoformats = new[] { ".mp4", ".avi", ".mkv" , ".mov" , ".mpeg4" };
             

            string startFolder = @"E:\Documents\English structure\Rest\toFlashTestSum\";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            IEnumerable<System.IO.FileInfo> fileQuery =
               (from file in fileList
                select file).Where(p => p.Extension.Contains(videoformats[0]) || p.Extension.Contains(videoformats[1]) || p.Extension.Contains(videoformats[2]) || p.Extension.Contains(videoformats[3]) || p.Extension.Contains(videoformats[4]));

           sumDuration = 0;//вот здесь будем подсчитывать общую сумму длительностей видеофайлов
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                Console.WriteLine(fi.FullName);
                MediaToolkit.Model.MediaFile myfile = new MediaToolkit.Model.MediaFile { Filename = fi.FullName };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(myfile);

                }
                Console.WriteLine(myfile.Metadata.Duration.TotalMinutes);
                sumDuration += myfile.Metadata.Duration.TotalMinutes;
            }
            
            sumhours = (int)sumDuration / 60;
            summinutes = (int)sumDuration - sumhours * 60;
            
            if(sumhours> 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                PrintResult();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                PrintResult();
            }
            Console.WriteLine("Конец приложения");
            Console.ReadLine();
        }      
    }
}
