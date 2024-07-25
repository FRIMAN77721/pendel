using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace pendel
{
    class DownLoadsTable
    {
        public static void ImportTableDO(string Name,string pathFile )
        {
            //инициализация соединения с БД  
            DB_ENGINE.DB_ENGINE DB = new DB_ENGINE.DB_ENGINE();
            DB.Open();
            SQLiteTransaction Transact = DB.Conn.BeginTransaction();
            // инциальзация считывания файла
            StreamReader SR = new StreamReader(pathFile, Encoding.GetEncoding(1251));
            string tmp = "";
            // цикл считывания строк
            while ( (tmp = SR.ReadLine()) != null)
            {
                //первая строка
                string[] stmp = tmp.Split(';');


                SQLiteCommand cmd = new SQLiteCommand(DB.Conn)
                {

                    CommandText = "INSERT INTO " + Name +" (Fa,Im,Snils,Ot,Ra,Date,Id,Np) VALUES(@Fa,@Im,@Snils,@Ot,@Ra,@Date,@Id,@Np)"

                };
                cmd.Parameters.Add("@Fa", DbType.String).Value = stmp[0];
                cmd.Parameters.Add("@Im", DbType.String).Value = stmp[1];
                cmd.Parameters.Add("@Snils", DbType.String).Value = stmp[2];
                cmd.Parameters.Add("@Ot", DbType.String).Value = stmp[3];
                cmd.Parameters.Add("@Ra", DbType.String).Value = stmp[4];
                cmd.Parameters.Add("@Date", DbType.String).Value = stmp[5];
                cmd.Parameters.Add("@Id", DbType.String).Value = stmp[6];
                cmd.Parameters.Add("@Np", DbType.String).Value = stmp[7];

                //cmd.Parameters.Add("@BIRTHPLACE", DbType.String).Value = String.Join(" ", stmp[29], stmp[30], stmp[31], stmp[32]);// объединение строк в одну колонку через пробел

                cmd.ExecuteNonQuery();




            }
            Transact.Commit();
            DB.Close();

           
        }
        
        public static void SelTable(string Name )
        {
            // выборка по Москве 
            List<Person> ResultP = new List<Person>();
            List<Person> ResultG = new List<Person>();
            List<Person> ResultG_MO = new List<Person>();
            List<Person> ResultP_MO = new List<Person>();
            DB_ENGINE.DB_ENGINE DB = new DB_ENGINE.DB_ENGINE();
            DB.Open();
            SQLiteCommand cmd = new SQLiteCommand(DB.Conn) { CommandText = "SELECT popen_do_m.Snils, popen_do_m.Fa, popen_do_m.Im, popen_do_m.Ot, popen_do_m.Ra, popen_do_m.Date, popen_do_m.Id, popen_do_m.Np FROM popen_do_m LEFT JOIN popen_po_m ON popen_do_m.Id=popen_po_m.Id WHERE popen_po_m.Id IS NULL " };
            SQLiteDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {

                var rec = new Person
                {
                    SNILS = reader.GetValue(0).ToString(),
                    FA = reader.GetValue(1).ToString(),
                    IM = reader.GetValue(2).ToString(),
                    OT = reader.GetValue(3).ToString(),
                    RA = reader.GetValue(4).ToString(),
                    DATE = reader.GetValue(5).ToString(),
                    ID = reader.GetValue(6).ToString(),
                    NP = reader.GetValue(7).ToString()

                };
                ResultP.Add(rec);
            }
            
            SQLiteCommand cmdG = new SQLiteCommand(DB.Conn) { CommandText = "SELECT gsp_do_m.Snils, gsp_do_m.Fa, gsp_do_m.Im, gsp_do_m.Ot, gsp_do_m.Ra, gsp_do_m.Date, gsp_do_m.Id, gsp_do_m.Np FROM gsp_do_m LEFT JOIN gsp_po_m ON gsp_do_m.Id=gsp_po_m.Id WHERE gsp_po_m.Id IS NULL " };
            SQLiteDataReader reader2 = cmdG.ExecuteReader();

            while (reader2.Read())
            {

                var rec = new Person
                {
                    SNILS = reader2.GetValue(0).ToString(),
                    FA = reader2.GetValue(1).ToString(),
                    IM = reader2.GetValue(2).ToString(),
                    OT = reader2.GetValue(3).ToString(),
                    RA = reader2.GetValue(4).ToString(),
                    DATE = reader2.GetValue(5).ToString(),
                    ID = reader2.GetValue(6).ToString(),
                    NP = reader2.GetValue(7).ToString()

                };
                ResultG.Add(rec);
            }
            
            GenerateXlsx.CreateResultsU(ResultP,ResultG);

            
            SQLiteCommand Cmd = new SQLiteCommand(DB.Conn) { CommandText = "SELECT popen_do_mo.Snils, popen_do_mo.Fa, popen_do_mo.Im, popen_do_mo.Ot, popen_do_mo.Ra, popen_do_mo.Date, popen_do_mo.Id, popen_do_mo.Np FROM popen_do_mo LEFT JOIN popen_po_mo ON popen_do_mo.Id=popen_po_mo.Id WHERE popen_po_mo.Id IS NULL " };
            SQLiteDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {

                var rec = new Person
                {
                    SNILS = Reader.GetValue(0).ToString(),
                    FA = Reader.GetValue(1).ToString(),
                    IM = Reader.GetValue(2).ToString(),
                    OT = Reader.GetValue(3).ToString(),
                    RA = Reader.GetValue(4).ToString(),
                    DATE = Reader.GetValue(5).ToString(),
                    ID = Reader.GetValue(6).ToString(),
                    NP = Reader.GetValue(7).ToString()

                };
                ResultP_MO.Add(rec);
            }
           
            SQLiteCommand CmdG_MO = new SQLiteCommand(DB.Conn) { CommandText = "SELECT gsp_do_mo.Snils, gsp_do_mo.Fa, gsp_do_mo.Im, gsp_do_mo.Ot, gsp_do_mo.Ra, gsp_do_mo.Date, gsp_do_mo.Id, gsp_do_mo.Np FROM gsp_do_mo LEFT JOIN gsp_po_mo ON gsp_do_mo.Id=gsp_po_mo.Id WHERE gsp_po_mo.Id IS NULL " };
            SQLiteDataReader Reader2 = CmdG_MO.ExecuteReader();

            while (Reader2.Read())
            {

                var rec = new Person
                {
                    SNILS = Reader2.GetValue(0).ToString(),
                    FA = Reader2.GetValue(1).ToString(),
                    IM = Reader2.GetValue(2).ToString(),
                    OT = Reader2.GetValue(3).ToString(),
                    RA = Reader2.GetValue(4).ToString(),
                    DATE = Reader2.GetValue(5).ToString(),
                    ID = Reader2.GetValue(6).ToString(),
                    NP = Reader2.GetValue(7).ToString()

                };
                ResultG.Add(rec);
            }
            
            GenerateXlsx.CreateResultsU(ResultP_MO, ResultG_MO);
            List<Person> DoblesP = new List<Person>();
            List<Person> DoblesG = new List<Person>();
            var CMD = new SQLiteCommand(DB.Conn) { CommandText = "SELECT popen_po_m.Fa, popen_po_m.Im, popen_po_m.Ot, popen_po_m.Snils, popen_po_m.Ra, popen_po_mo.Ra, popen_po_m.Np, popen_po_mo.Np FROM popen_po_m INNER JOIN popen_po_mo ON popen_po_m.Snils = popen_po_mo.Snils WHERE popen_po_m.Snils >'000-000-000 02' AND ((popen_po_m.Np<>'ПРЕ' AND popen_po_m.Np<>'СНЯ') AND (popen_po_mo.Np<>'ПРЕ' AND popen_po_mo.Np<>'СНЯ'))" };
            var reaD = CMD.ExecuteReader();
            while (reaD.Read()) 
            {
                var rec = new Person
                {
                    FA = reaD.GetValue(0).ToString(),
                    IM = reaD.GetValue(1).ToString(),
                    OT = reaD.GetValue(2).ToString(),
                    SNILS = reaD.GetValue(3).ToString(),
                    RA = reaD.GetValue(4).ToString(),
                    // RA второе поле () 
                    RA2 = reaD.GetValue(5).ToString(),
                    NP = reaD.GetValue(6).ToString(),
                    // второе поле операции
                    NP2 = reaD.GetValue(7).ToString()
                };
                DoblesP.Add(rec);
            
            
            
            } 
            var CmD = new SQLiteCommand(DB.Conn) { CommandText = "SELECT gsp_po_m.Fa, gsp_po_m.Im, gsp_po_m.Ot, gsp_po_m.Snils, gsp_po_m.Ra, gsp_po_mo.Ra, gsp_po_m.Np, gsp_po_mo.Np FROM gsp_po_m INNER JOIN gsp_po_mo ON gsp_po_m.Snils = gsp_po_mo.Snils WHERE gsp_po_m.Snils >'000-000-000 02' AND  ((gsp_po_m.Np<>'ПРЕ' AND gsp_po_m.Np<>'СНЯ') AND (gsp_po_mo.Np<>'ПРЕ' AND gsp_po_mo.Np<>'СНЯ'))" };
            var reaDG = CmD.ExecuteReader();
            while (reaDG.Read())
            {
                var rec = new Person
                {
                    FA = reaDG.GetValue(0).ToString(),
                    IM = reaDG.GetValue(1).ToString(),
                    OT = reaDG.GetValue(2).ToString(),
                    SNILS = reaDG.GetValue(3).ToString(),
                    RA = reaDG.GetValue(4).ToString(),
                    // RA второе поле () 
                    RA2 = reaDG.GetValue(5).ToString(),
                    NP = reaDG.GetValue(6).ToString(),
                    // второе поле операции
                    NP2 = reaDG.GetValue(7).ToString()
                };
                DoblesG.Add(rec);



            }
            GenerateXlsx.CreateXlsxD(DoblesP,DoblesG);
            DB.Close();
        }

    }
    public class Person
    {
        public string SNILS { get; set; }
        public string FA { get; set; }
        public string IM { get; set; }
        public string OT { get; set; }
        public string RA { get; set; }
        public string DATE { get; set; }
        public string ID { get; set; }
        public string NP { get; set; }
        public string RA2 { get; set; }
        public string NP2 { get; set; }
    }
}
