using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class TrackTypeTable : Table
    {
        private List<TrackTypeTableRecord> records;

        public TrackTypeTable(string dbNm) {
            TableName = "t_track_type";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            records = new List<TrackTypeTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var trackType = new TrackTypeTableRecord();
                    trackType.ID = int.Parse(row[0]);
                    trackType.Name = row[1];
                    records.Add(trackType);
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
