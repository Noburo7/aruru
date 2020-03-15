using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class TrackTypeTable : Table
    {
        public List<TrackTypeTableRecord> Records { get; private set; }

        public TrackTypeTable(string dbNm) {
            TableName = "t_track_type";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            Records = new List<TrackTypeTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var trackType = new TrackTypeTableRecord();
                    trackType.ID = int.Parse(row[0]);
                    trackType.Name = row[1];
                    Records.Add(trackType);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public string ReturnNameFor(int id) {
            return Records.Where(o => o.ID == id).First().Name;
        }
    }
}
