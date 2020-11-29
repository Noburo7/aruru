using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class TrackConditionTable : ITrackConditionTable
    {
        public IEnumerable<ITrackCondition> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _trackConditionTableNm = "t_track_condition";

        public TrackConditionTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\05_T_Track_Condition.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\05_T_Track_Condition_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<ITrackCondition>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_trackConditionTableNm}");
                foreach (var row in table)
                {
                    var condition = new TrackConditionRecord();
                    condition.ID = int.Parse(row[0]);
                    condition.Name = row[1];
                    records.Add(condition);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
