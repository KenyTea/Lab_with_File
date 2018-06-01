using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_with_File
{
    class Program
    {
        //      TNSShort
        //      Test


        static void Main(string[] args)
        {
            /*При запуске программы, необходимо предложить пользователю указать путь к папке в которой находятся файлы,
              после необходимо произвести следующие действия:*/

            Console.WriteLine("Please specify the path to the file: ");
            string path = Console.ReadLine();

            /*1.	Получить расширения всех файлов, и предложить пользователю выбрать необходимый формат,
              с которым нужно будет работать. При этом нужно учесть, что пользователь может выбрать больше одного формата или все.*/

            List<string> ListExtension = new List<string>();
            List<string> ListFileWhithoutExtension = new List<string>();
            string symbol = "";
            string symbol1 = "";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo item in dir.GetFiles())
            {
                if (ExtractSymbols(item.Name.Remove(item.Name.Length - 3))) // 1111111
                {
                    ListFileWhithoutExtension.Add(item.Name.Remove(item.Name.Length - 3)); // 1111111
                }
                if (!ListExtension.Contains(item.Extension))
                {
                    Console.Write(item.Extension + " | ");
                    ListExtension.Add(item.Extension);
                }
            }

            Console.WriteLine();
            List<string> ListFormatov = new List<string>();
            Console.WriteLine();
            string format = " ";
            do
            {
                Console.Write("Which format do you want to use?: ");
                format = Console.ReadLine();
                if (ListExtension.Contains(format))
                    ListFormatov.Add(format);
            }
            while (!string.IsNullOrEmpty(format));

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            foreach (FileInfo item in dir.GetFiles())
            {
                Console.WriteLine("Full path:  " + item.DirectoryName);
                Console.WriteLine("Size:  " + item.Length);
                Console.WriteLine("Name" + item.Name);
                Console.WriteLine("Date of creation" + item.CreationTime);
                Console.WriteLine("--------------------------------------------------");
            }

            foreach (string item in ListFileWhithoutExtension)
            {
                foreach (char i in item)
                {
                    if ((!(i >= 48 && i <= 57)) && (!(i >= 65 && i <= 90)) && (!(i >= 97 && i <= 122)))
                        symbol += i;
                }

            }
            foreach (char item in symbol)
            {
                if (!symbol1.Contains(item))
                    symbol1 += item;
            }

            Console.Write("Specify the path, the miracle will be copied information ");
            string path2 = Console.ReadLine();

            Console.Write("The name contains symbols: ");
            foreach (char item in symbol1)
            {
                Console.Write( item + " заменить "); string a = Console.ReadLine();
                foreach (FileInfo i in dir.GetFiles())
                {
                    if (item == 32)
                    {
                        foreach (char it in i.Name)
                        {
                            if (it >= 128 && it <= 175 || it >= 224 && it <= 241)
                                break;
                        }
                    }
                    i.MoveTo(path2 + @"\" + i.Name.Replace(item, a[0]));
                }
            }
        }



        static bool ExtractSymbols(string simb)
        {

            foreach (char item in simb)
            {
                if ((!(item >= 48 && item <= 57)) && (!(item >= 65 && item <= 90)) && (!(item >= 97 && item <= 122)))
                {
                    return true;
                }
            }
            return false;
        }



    }
}
