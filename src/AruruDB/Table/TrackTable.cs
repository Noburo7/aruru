using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class TrackTable : Table
    {
        private List<TrackTableRecord> records;

        public TrackTable(string dbNm) {
            TableName = "t_track";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            records = new List<TrackTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var track = new TrackTableRecord();
                    track.ID = int.Parse(row[0]);
                    track.Name = row[1];
                    records.Add(track);
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
