using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class TrackTable : ITrackTable
    {
        public IEnumerable<ITrack> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }
        private static readonly string _trackTableNm = "t_track";

        public TrackTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\02_T_Track.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\02_T_Track_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<ITrack>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_trackTableNm}");
                foreach (var row in table)
                {
                    var track = new Track();
                    track.ID = int.Parse(row[0]);
                    track.Name = row[1];
                    records.Add(track);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
