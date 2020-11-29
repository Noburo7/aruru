using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class BakenTable : IBakenTable
    {
        public IEnumerable<IBaken> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _bakenTableNm = "t_baken";

        public BakenTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\07_T_Baken.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<IBaken>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_bakenTableNm}");
                foreach (var row in table)
                {
                    var baken = new Baken();
                    baken.BakenID = int.Parse(row[0]);
                    baken.RaceID = int.Parse(row[1]);
                    baken.BakenTypeID = int.Parse(row[2]);
                    baken.Investment = int.Parse(row[3]);
                    baken.Payout = int.Parse(row[4]);
                    records.Add(baken);
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
