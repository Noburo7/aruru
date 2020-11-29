﻿using System;
using System.Collections.Generic;

namespace AruruDB
{
    public class AruruDatabase : IAruruDatabase
    {
        private static readonly string _bakenTableNm = "t_baken";
        private static readonly string _bakenTypeTableNm = "t_baken_type";
        private static readonly string _courseTableNm = "t_course";
        private static readonly string _classTableNm = "t_race_class";
        private static readonly string _raceTableNm = "t_race";
        private static readonly string _trackConditionTableNm = "t_track_condition";
        private static readonly string _trackTableNm = "t_track";
        private static readonly string _trackTypeTableNm = "t_track_type";
        private SQLiteDB sqliteDB;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbName"></param>
        public bool Init(string dbName)
        {
            //TODO: ファイルチェック
            sqliteDB = new SQLiteDB(dbName);
            return true;
        }

        /// <summary>
        /// 馬券種別テーブルをリードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBakenType> ReadBakenTypeTable()
        {
            var records = new List<IBakenType>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_bakenTypeTableNm}");
                foreach (var row in table)
                {
                    var bakenType = new BakenTypeTableRecord
                    {
                        ID = int.Parse(row[0]),
                        Name = row[1]
                    };
                    records.Add(bakenType);
                }

                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// レースクラステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRaceClass> ReadRaceClassTable()
        {
            var records = new List<IRaceClass>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_classTableNm}");
                foreach (var row in table)
                {
                    var raceClass = new RaceClassTableRecord();
                    raceClass.ID = int.Parse(row[0]);
                    raceClass.Name = row[1];
                    records.Add(raceClass);
                }
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 馬場状態テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackCondition> ReadTrackConditionTable()
        {
            var records = new List<ITrackCondition>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_trackConditionTableNm}");
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

        /// <summary>
        /// 競馬場テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrack> ReadTrackTable()
        {
            var records = new List<ITrack>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_trackTableNm}");
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

        /// <summary>
        /// トラックタイプテーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackType> ReadTrackTypeTable()
        {
            var records = new List<ITrackType>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_trackTypeTableNm}");
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

        /// <summary>
        /// レーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRace> ReadRaceTable()
        {
            var records = new List<IRace>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_raceTableNm}");
                foreach (var row in table)
                {
                    var race = new RaceTableRecord();
                    race.ID                 = int.Parse(row[0]);
                    race.Date               = row[1];
                    race.TrackID            = int.Parse(row[2]);
                    race.RaceNumber         = int.Parse(row[3]);
                    race.RaceName           = row[4];
                    race.TrackTypeID        = int.Parse(row[5]);
                    race.Distance           = int.Parse(row[6]);
                    race.RaceClassID        = int.Parse(row[7]);
                    race.TrackConditionID   = int.Parse(row[8]);
                    race.IsHandicap         = int.Parse(row[9]);
                    race.IsOnlyFemale       = int.Parse(row[10]);
                    race.IsOnlyYouth        = int.Parse(row[11]);
                    records.Add(race);
                }
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 馬券テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBaken> ReadBakenTable()
        {
            var records = new List<IBaken>();
            try
            {
                var table = sqliteDB.Execute($"SELECT * FROM {_bakenTableNm}");
                foreach (var row in table)
                {
                    var baken = new BakenTableRecord();
                    baken.BakenID = int.Parse(row[0]);
                    baken.RaceID = int.Parse(row[1]);
                    baken.BakenTypeID = int.Parse(row[2]);
                    baken.Investment = int.Parse(row[3]);
                    baken.Payout = int.Parse(row[4]);
                    records.Add(baken);
                }
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 競馬場・トラックタイプに対する距離リストを返す。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> ReadDistanceList(int trackID, int trackTypeID)
        {
            var list = new List<int>();
            var sql = $"SELECT distance FROM {_courseTableNm}" + Environment.NewLine
                        + $"WHERE track_id = {trackID} AND track_type_id = {trackTypeID}" + Environment.NewLine
                        + "ORDER BY distance";
            try
            {
                var result = sqliteDB.Execute(sql);
                foreach (var row in result)
                {
                    list.Add(int.Parse(row[0]));
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}