using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class TrackConditionTable : Table
    {
        public List<TrackConditionTableRecord> records;

        public TrackConditionTable(string dbNm) {
            TableName = "t_track_condition";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            records = new List<TrackConditionTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var condition = new TrackConditionTableRecord();
                    condition.ID = int.Parse(row[0]);
                    condition.Name = row[1];
                    records.Add(condition);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public string ReturnNameFor(int id) {
            return records.Where(o => o.ID == id).First().Name;
        }
    }
}
