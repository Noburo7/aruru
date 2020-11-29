using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class TrackTypeTable : ITrackTypeTable
    {
        public IEnumerable<ITrackType> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _trackTypeTableNm = "t_track_type";

        public TrackTypeTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\03_T_Track_Type.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\03_T_Track_Type_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<ITrackType>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_trackTypeTableNm}");
                foreach (var row in table)
                {
                    var trackType = new TrackType();
                    trackType.ID = int.Parse(row[0]);
                    trackType.Name = row[1];
                    records.Add(trackType);
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
