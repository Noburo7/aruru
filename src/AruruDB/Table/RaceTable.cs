using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    race.RaceNumber = int.Parse(row[2]);
                    race.RaceName = row[3];
                    race.TrackID = int.Parse(row[4]);
                    race.TrackTypeID = int.Parse(row[5]);
                    race.Distance = int.Parse(row[6]);
                    race.RaceClassID = int.Parse(row[7]);
                    race.TrackConditionID = int.Parse(row[8]);
                    race.IsHandicap = int.Parse(row[9]);
                    race.IsOnlyFemale = int.Parse(row[10]);
                    race.IsOnlyYouth = int.Parse(row[11]);
                    records.Add(race);
                }
                records = records.OrderBy(o => o.Date).ToList();
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
                + $"{record.RaceNumber},"
                + $"'{record.RaceName}',"
                + $"{record.TrackID},"
                + $"{record.TrackTypeID},"
                + $"{record.Distance},"
                + $"{record.RaceClassID},"
                + $"{record.TrackConditionID},"
                + $"{record.IsHandicap},"
                + $"{record.IsOnlyFemale},"
                + $"{record.IsOnlyYouth})";
            SQLiteDB.ExecuteSql(sql);
            ReadTable();
        }

        public void DeleteRecord(int raceID)
        {
            var sql = $"DELETE FROM {_raceTableNm} WHERE race_id IS {raceID};";
            SQLiteDB.ExecuteSql(sql);
            ReadTable();
        }

        /// <summary>
        /// レースIDを返す
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="trackID">コースID</param>
        /// <param name="raceNumber">レース番号</param>
        /// <returns>レースID</returns>
        public int RaceID(string date, int trackID, int raceNumber)
        {
            return Records.Where(o => o.Date == date && o.TrackID == trackID && o.RaceNumber == raceNumber).First().ID;
        }

        public IRaceRecord GetRaceRecord(int raceID)
        {
            return Records.Where(o => o.ID == raceID).First();
        }

        public bool ExistRecord(string date, int trackID, int raceNumber)
        {
            return Records.Any(o => o.Date == date && o.TrackID == trackID && o.RaceNumber == raceNumber);
        }
    }
}
