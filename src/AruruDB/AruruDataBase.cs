using System;
using System.IO;
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
        /// 備考テーブル
        /// </summary>
        public IRemarkTable RemarkTable { get; }

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
                (BakenTable = new BakenTable(_DB)),
                (RemarkTable = new RemarkTable(_DB))
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
            return CourseTable.DistanceList(TrackTable.TrackID(trackNm), TrackTypeTable.TrackTypeID(trackTypeNm));
        }

        /// <summary>
        /// レース・馬券を登録する
        /// </summary>
        /// <param name="baken"></param>
        public void InsertBakenResult(IRace raceInfo, IEnumerable<IBaken> bakens, string remark)
        {
            var trackID = TrackTable.TrackID(raceInfo.TrackNm);
            var trackTypeID = TrackTypeTable.TrackTypeID(raceInfo.TrackTypeNm);
            var trackConditionID = TrackConditionTable.TrackConditionID(raceInfo.TrackConditionNm);
            var classID = RaceClassTable.ClassID(raceInfo.RaceClassNm);

            if (RaceTable.ExistRecord(raceInfo.Date, trackID, raceInfo.RaceNum))
            {
                //テーブル更新
            }
            else
            {
                //レーステーブル新規登録
                var raceRecord = new RaceRecord();
                raceRecord.Date = raceInfo.Date;
                raceRecord.TrackID = trackID;
                raceRecord.TrackTypeID = trackTypeID;
                raceRecord.RaceNumber = raceInfo.RaceNum;
                raceRecord.RaceName = raceInfo.RaceNm;
                raceRecord.Distance = raceInfo.Distance;
                raceRecord.RaceClassID = classID;
                raceRecord.TrackConditionID = trackConditionID;
                raceRecord.IsHandicap = raceInfo.IsHandicap ? 1 : 0;
                raceRecord.IsOnlyFemale = raceInfo.IsOnlyFemale ? 1 : 0;
                raceRecord.IsOnlyYouth = raceInfo.IsOnlyYouth ? 1 : 0;
                RaceTable.InsertRecord(raceRecord);

                //レースID取得
                var raceID = RaceTable.RaceID(raceRecord.Date, raceRecord.TrackID, raceRecord.RaceNumber);

                //馬券登録
                foreach (var baken in bakens)
                {
                    var bakenRecord = new BakenRecord();
                    bakenRecord.RaceID = raceID;
                    bakenRecord.BakenTypeID = BakenTypeTable.BakenTypeID(baken.BakenTypeNm);
                    bakenRecord.Investment = baken.Investment;
                    bakenRecord.Payout = baken.Payout;
                    BakenTable.InsertRecord(bakenRecord);
                }

                //備考登録
                RemarkTable.InsertRecord(raceID, remark);
            }
        }

        /// <summary>
        /// レースIDを返す
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="trackNm">競馬場名</param>
        /// <param name="raceNum">レース番号</param>
        /// <returns>レースID</returns>
        public int GetRaceID(string date, string trackNm, int raceNum)
        {
            return RaceTable.RaceID(date, TrackTable.TrackID(trackNm), raceNum);
        }

        public void DeleteRaceBakenRecord(string date, string trackNm, int raceNum)
        {
            var raceID = GetRaceID(date, trackNm, raceNum);
            RemarkTable.DeleteRecord(raceID);
            BakenTable.DeleteRecords(raceID);
            RaceTable.DeleteRecord(raceID);
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
