using System;
using System.Collections.Generic;

namespace AruruDB
{
    internal class BakenTable
    {
        public string TableName { get; } = "t_baken";
        public string DBName { get; }

        public BakenTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<IBaken> LoadTable()
        {
            var records = new List<IBaken>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var baken = new BakenTableRecord();
                    baken.BakenID = int.Parse(row[0]);
                    baken.RaceID = int.Parse(row[1]);
                    baken.BakenTypeID = int.Parse(row[2]);
                    baken.Investment = int.Parse(row[3]);
                    baken.Payout = int.Parse(row[4]);
                    records.Add(baken);
                }
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
