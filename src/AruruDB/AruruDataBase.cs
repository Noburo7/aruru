using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using AruruDB.Table;
using AruruDB.Table.Record;

namespace AruruDB
{
    public class AruruDatabase : IAruruDatabase
    {
        private SQLiteDB _DB;

        /// <summary>
        /// 馬券テーブル
        /// </summary>
        public IBakenTable BakenTable { get; }

        /// <summary>
        /// 馬券種テーブル
        /// </summary>
        public IBakenTypeTable BakenTypeTable { get; }

        /// <summary>
        /// コーステーブル
        /// </summary>
        public ICourseTable CourseTable { get; }

        /// <summary>
        /// レースクラステーブル
        /// </summary>
        public IRaceClassTable RaceClassTable { get; }

        /// <summary>
        /// レーステーブル
        /// </summary>
        public IRaceTable RaceTable { get; }

        /// <summary>
        /// 馬場状態テーブル
        /// </summary>
        public ITrackConditionTable TrackConditionTable { get; }

        /// <summary>
        /// 競馬場テーブル
        /// </summary>
        public ITrackTable TrackTable { get; }

        /// <summary>
        /// コースタイプテーブル
        /// </summary>
        public ITrackTypeTable TrackTypeTable { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbName"></param>
        public AruruDatabase(string dbFile)
        {
            _DB = new SQLiteDB(dbFile);
            var tables = new List<ITable>
            {
                (BakenTypeTable = new BakenTypeTable(_DB)),
                (TrackTable = new TrackTable(_DB)),
                (TrackTypeTable = new TrackTypeTable(_DB)),
                (RaceClassTable = new RaceClassTable(_DB)),
                (TrackConditionTable = new TrackConditionTable(_DB)),
                (CourseTable = new CourseTable(_DB)),
                (RaceTable = new RaceTable(_DB)),
                (BakenTable = new BakenTable(_DB))
            };

            //SQLiteファイルがない場合は初期化する
            if (!File.Exists(dbFile))
            {
                CreateDB();
                foreach (var table in tables)
                {
                    table.Init();
                }
            }

            foreach (var table in tables)
            {
                table.ReadTable();
            }
        }

        /// <summary>
        /// コースの距離リストを返す
        /// </summary>
        /// <param name="trackNm">競馬場名</param>
        /// <param name="trackTypeNm">馬場タイプ</param>
        /// <returns>距離リスト</returns>
        public IEnumerable<int> DistanceList(string trackNm, string trackTypeNm)
        {
            var trackID = TrackTable.Records.Where(o => o.Name == trackNm).First().ID;
            var trackTypeID = TrackTypeTable.Records.Where(o => o.Name == trackTypeNm).First().ID;
            return CourseTable.DistanceList(trackID, trackTypeID);
        }

        /// <summary>
        /// レース・馬券を登録する
        /// </summary>
        /// <param name="baken"></param>
        public void InsertBakenResult(IRace raceInfo, IEnumerable<IBaken> bakens)
        {
            var trackID = TrackTable.Records.Where(o => o.Name == raceInfo.TrackNm).First().ID;
            var trackTypeID = TrackTypeTable.Records.Where(o => o.Name == raceInfo.TrackTypeNm).First().ID;
            var courseID = CourseTable.Records.Where(o => o.TrackID == trackID && o.TrackTypeID == trackTypeID && o.Distance == raceInfo.Distance).First().ID;
            var trackConditionID = TrackConditionTable.Records.Where(o => o.Name == raceInfo.TrackConditionNm).First().ID;
            var classID = RaceClassTable.Records.Where(o => o.Name == raceInfo.RaceClassNm).First().ID;

            if (RaceTable.Records.Any(o => o.Date == raceInfo.Date && o.CourseID == courseID && o.RaceNumber == raceInfo.RaceNum))
            {
                //テーブル更新
            }
            else
            {
                //レーステーブル新規登録
                var raceRecord = new RaceRecord();
                raceRecord.Date = raceInfo.Date;
                raceRecord.CourseID = courseID;
                raceRecord.RaceNumber = raceInfo.RaceNum;
                raceRecord.RaceName = raceInfo.RaceNm;
                raceRecord.RaceClassID = classID;
                raceRecord.TrackConditionID = trackConditionID;
                raceRecord.IsHandicap = raceInfo.IsHandicap ? 1 : 0;
                raceRecord.IsOnlyFemale = raceInfo.IsOnlyFemale ? 1 : 0;
                raceRecord.IsOnlyYouth = raceInfo.IsOnlyYouth ? 1 : 0;
                RaceTable.InsertRecord(raceRecord);

                //レースID取得
                RaceTable.ReadTable();
                var raceID = RaceTable.Records.Where(o => o.Date == raceRecord.Date && o.CourseID == raceRecord.CourseID && o.RaceNumber == raceRecord.RaceNumber).First().ID;

                //馬券登録
                foreach (var baken in bakens)
                {
                    var bakenRecord = new BakenRecord();
                    bakenRecord.RaceID = raceID;
                    bakenRecord.BakenTypeID = BakenTypeTable.Records.Where(o => o.Name == baken.BakenTypeNm).First().ID;
                    bakenRecord.Investment = baken.Investment;
                    bakenRecord.Payout = baken.Payout;
                    BakenTable.InsertRecord(bakenRecord);
                }
                BakenTable.ReadTable();
            }
        }

        /// <summary>
        /// AruruDBを作成する。
        /// </summary>
        private void CreateDB()
        {
            try
            {
                _DB.CreateDBFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
