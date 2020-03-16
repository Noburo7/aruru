using System;
using System.Collections.Generic;

namespace AruruDB
{
    internal class TrackConditionTable
    {
        public string TableName { get; } = "t_track_condition";
        public string DBName { get; }

        public TrackConditionTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<ITrackCondition> LoadTable()
        {
            var records = new List<ITrackCondition>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var condition = new TrackConditionTableRecord();
                    condition.ID = int.Parse(row[0]);
                    condition.Name = row[1];
                    records.Add(condition);
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
