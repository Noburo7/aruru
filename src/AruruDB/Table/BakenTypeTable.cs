using System;
using System.Collections.Generic;

namespace AruruDB
{
    public class BakenTypeTable : Table
    {
        private List<BakenTypeTableRecord> records;

        public BakenTypeTable(string dbNm) {
            TableName = "t_baken_type";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            records = new List<BakenTypeTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var bakenType = new BakenTypeTableRecord {
                        ID = int.Parse(row[0]),
                        Name = row[1]
                    };
                    records.Add(bakenType);
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
