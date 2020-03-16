using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    internal class TrackTypeTable
    {
        public string TableName { get; } = "t_track_type";
        public string DBName { get; }

        public TrackTypeTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<ITrackType> LoadTable()
        {
            var records = new List<ITrackType>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var trackType = new TrackTypeTableRecord();
                    trackType.ID = int.Parse(row[0]);
                    trackType.Name = row[1];
                    records.Add(trackType);
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
