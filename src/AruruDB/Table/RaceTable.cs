using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class RaceTable : IRaceTable
    {
        public IEnumerable<IRaceRecord> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _raceTableNm = "t_race";

        public RaceTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\07_T_Race.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<IRaceRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_raceTableNm}");
                foreach (var row in table)
                {
                    var race = new RaceRecord();
                    race.ID = int.Parse(row[0]);
                    race.Date = row[1];
                    race.CourseID = int.Parse(row[2]);
                    race.RaceNumber = int.Parse(row[3]);
                    race.RaceName = row[4];
                    race.RaceClassID = int.Parse(row[5]);
                    race.TrackConditionID = int.Parse(row[6]);
                    race.IsHandicap = int.Parse(row[7]);
                    race.IsOnlyFemale = int.Parse(row[8]);
                    race.IsOnlyYouth = int.Parse(row[9]);
                    records.Add(race);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertRecord(IRaceRecord record)
        {
            var sql = $"INSERT INTO {_raceTableNm} "
                + "VALUES(null, "
                + $"'{record.Date}',"
                + $"{record.CourseID},"
                + $"{record.RaceNumber},"
                + $"'{record.RaceName}',"
                + $"{record.RaceClassID},"
                + $"{record.TrackConditionID},"
                + $"{record.IsHandicap},"
                + $"{record.IsOnlyFemale},"
                + $"{record.IsOnlyYouth})";
            SQLiteDB.ExecuteSql(sql);
        }
    }
}
