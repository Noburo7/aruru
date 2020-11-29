using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using AruruDB.Table;

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
                (BakenTable = new BakenTable(_DB)),
                (BakenTypeTable = new BakenTypeTable(_DB)),
                (CourseTable = new CourseTable(_DB)),
                (RaceClassTable = new RaceClassTable(_DB)),
                (RaceTable = new RaceTable(_DB)),
                (TrackConditionTable = new TrackConditionTable(_DB)),
                (TrackTable = new TrackTable(_DB)),
                (TrackTypeTable = new TrackTypeTable(_DB))
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
        public void InsertBakenResult(IRace raceInfo, IEnumerable<IBaken> baken)
        {
            //TODO:Implement
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
