using System;
using System.Collections.Generic;

namespace AruruDB
{
    public class BakenTable : Table
    {
        public List<BakenTableRecord> Records { get; private set; }

        public BakenTable(string dbNm) {
            TableName = "t_baken";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            Records = new List<BakenTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var baken = new BakenTableRecord();
                    baken.BakenID = int.Parse(row[0]);
                    baken.RaceID = int.Parse(row[1]);
                    baken.BakenTypeID = int.Parse(row[2]);
                    baken.Investment = int.Parse(row[3]);
                    baken.Payout = int.Parse(row[4]);
                    Records.Add(baken);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
