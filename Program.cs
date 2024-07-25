using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using pendel.PTK_NVP;

namespace pendel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПОЕХАЛИ...");
            string file_path_arh = Environment.CurrentDirectory + @"\arh";
            string file_path = Environment.CurrentDirectory + @"\DO";
            string file_path2 = Environment.CurrentDirectory + @"\PO";
            var files = Directory.GetFiles(file_path, "*.csv");
            var files1 = Directory.GetFiles(file_path2, "*.csv");
            //перемещение и переименование файлов из DO=>ARH и из PO=>DO
            Console.WriteLine("из ДО в АРХИВ");
            foreach (string file in files)
            {


                File.Move(file, Path.Combine(file_path_arh, Path.GetFileName(file.Replace(".csv", " " + DateTime.Now.ToString("dd.MM.yyyy") + ".csv"))));


            }

            Console.WriteLine("из ПО в ДО");
            foreach (string file in files1)
            {


                File.Move(file, Path.Combine(file_path, Path.GetFileName(file.Replace("_po_", "_do_"))));


            }
            //Console.ReadLine();
            Console.WriteLine("отработано в папках");
            Console.WriteLine("ВЫборка попен и гсп по Москве");
            //Console.ReadLine();
            Servers_nvp.Serv_val(179);
            new PTK_NVP.TASK.PENDEL().DoWork();
            Console.WriteLine("Выборка попен и гсп по Московской области");

            Servers_nvp.Serv_val(209);
            new PTK_NVP.TASK.PENDEL().DoWork();
            Console.WriteLine("Выборки завершены");

            //загрузка файлов в БД
            Console.WriteLine("Загрузка таблиц в БД");
            FileInfo[] fileInfodo = new DirectoryInfo(file_path).GetFiles("*.csv");
            foreach (FileInfo item in fileInfodo)
            {
                string Name = item.Name.Replace(".csv", "");
                DownLoadsTable.ImportTableDO(Name, item.FullName);
                Console.WriteLine(Name);
            }
            FileInfo[] fileInfopo = new DirectoryInfo(file_path2).GetFiles("*.csv");
            foreach (FileInfo item in fileInfopo)
            {
                string Name = item.Name.Replace(".csv", "");
                DownLoadsTable.ImportTableDO(Name, item.FullName);
                Console.WriteLine(Name);
            }
            Console.WriteLine("загружено");
            // выборка из БД
            DownLoadsTable.SelTable(file_path);
            //очистка БД 
            DB_ENGINE.DB_ENGINE DB = new DB_ENGINE.DB_ENGINE();
            DB.Open();
            DB.CleanUP();
            DB.Close();
            Console.WriteLine("Готово");
            //DownLoadsTable.ImportTablePO(file_path2);
            Console.ReadLine();

        }
    }
}
