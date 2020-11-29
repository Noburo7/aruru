using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class RaceClassTable : IRaceClassTable
    {
        public IEnumerable<IClassRecord> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _classTableNm = "t_race_class";

        public RaceClassTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\04_T_Race_Class.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\04_T_Race_Class_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<IClassRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_classTableNm}");
                foreach (var row in table)
                {
                    var raceClass = new ClassRecord();
                    raceClass.ID = int.Parse(row[0]);
                    raceClass.Name = row[1];
                    records.Add(raceClass);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
