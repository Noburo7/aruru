using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    internal class TrackTable
    {
        public string TableName { get; } = "t_track";
        public string DBName { get; }

        public TrackTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<ITrack> LoadTable()
        {
            var records = new List<ITrack>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var track = new TrackTableRecord();
                    track.ID = int.Parse(row[0]);
                    track.Name = row[1];
                    records.Add(track);
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
