using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace pendel.DB_ENGINE
{
    class DB_ENGINE
    {

        #region TABLE_GENERATE 
        static readonly string Table_ = @"
CREATE TABLE IF NOT EXISTS popen_do_m (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
   
);
CREATE TABLE IF NOT EXISTS popen_po_m (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (32),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
   
);

CREATE TABLE IF NOT EXISTS gsp_do_m (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
  
);

CREATE TABLE IF NOT EXISTS gsp_po_m (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
   
);

CREATE TABLE IF NOT EXISTS popen_do_mo (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
    
);

CREATE TABLE IF NOT EXISTS popen_po_mo (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
    
);

CREATE TABLE IF NOT EXISTS gsp_do_mo (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (64),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
   
);

CREATE TABLE IF NOT EXISTS gsp_po_mo (
    
    Snils      TEXT (14),
    fa         TEXT (64),
    Im         TEXT (64),
    Ot         TEXT (64),
    Id         TEXT (32),
    Ra         TEXT (4),
    Date        TEXT (16),
    Np         TEXT (4)
    
);
";
        #endregion
        #region
        static readonly string FilePath = Environment.CurrentDirectory + @"\TEMP.db";
        public readonly SQLiteConnection Conn = new SQLiteConnection();
        private bool IsTemporary;
        static readonly string ConnString = " Data Source=" + FilePath;
        #endregion
        public SQLiteConnection Open(string _ConnString = null)
        {
            bool NeedInit = false;
            try
            {
                if (_ConnString == null)
                {
                    NeedInit = true;
                    IsTemporary = true;
                    _ConnString = ConnString;
                }
                Conn.ConnectionString = _ConnString;
                Conn.Open();
                if (NeedInit == true)
                {
                    Init();
                }

                return Conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Ошибка БД: {0} {1}", ex.Message.ToString(), Conn.ConnectionString));
                return null;
            }

        }

        private void RunSimpleCmd(string cmdtext)
        {
            SQLiteCommand cmd = new SQLiteCommand(Conn)
            {
                CommandText = cmdtext
            };
            cmd.ExecuteNonQuery();

        }
        public void Init()
        {

            RunSimpleCmd(Table_);
            RunSimpleCmd("PRAGMA synchronous = OFF");
            RunSimpleCmd("PRAGMA journal_mode = OFF");
            RunSimpleCmd("PRAGMA page_size = 10000");
           

        }
        public void Close()
        {
            try
            {
                Conn.Close();
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Ошибка БД: {0}", ex.Message.ToString()));
                return;
            }
        }
        public void CleanUP()
        {

            RunSimpleCmd("DELETE FROM popen_do_m; DELETE FROM popen_po_m; DELETE FROM popen_do_mo; DELETE FROM popen_po_mo; DELETE FROM gsp_do_m; DELETE FROM gsp_do_mo; DELETE FROM gsp_po_m; DELETE FROM gsp_po_mo; VACUUM;");

        }


    }
}
