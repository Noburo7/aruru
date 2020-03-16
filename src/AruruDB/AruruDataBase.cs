using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class AruruDatabase : IAruruDatabase
    {
        public string DBName { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbName"></param>
        public AruruDatabase(string dbName)
        {
            DBName = dbName;
        }

        /// <summary>
        /// AruruDBテーブルを作成する。
        /// </summary>
        public void CreateTable()
        {
            new SQLiteDB(DBName).CreateTable();
        }

        /// <summary>
        /// AruruDBに対しSQLコマンドを実行する。
        /// </summary>
        /// <param name="sql"></param>
        public IEnumerable<string[]> ExecuteSql(string sql)
        {
            return new SQLiteDB(DBName).Execute(sql);
        }

        /// <summary>
        /// 馬券種別テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBakenType> LoadBakenTypeTable()
        {
            return new BakenTypeTable(DBName).LoadTable();
        }

        /// <summary>
        /// レースクラステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRaceClass> LoadRaceClassTable()
        {
            return new RaceClassTable(DBName).LoadTable();
        }

        /// <summary>
        /// 馬場状態テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackCondition> LoadTrackConditionTable()
        {
            return new TrackConditionTable(DBName).LoadTable();
        }

        /// <summary>
        /// 競馬場テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrack> LoadTrackTable()
        {
            return new TrackTable(DBName).LoadTable();
        }

        /// <summary>
        /// トラックタイプテーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackType> LoadTrackTypeTable()
        {
            return new TrackTypeTable(DBName).LoadTable();
        }

        /// <summary>
        /// コーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICourse> LoadCourseTable()
        {
            return new CourseTable(DBName).LoadTable();
        }

        /// <summary>
        /// レーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRace> LoadRaceTable()
        {
            return new RaceTable(DBName).LoadTable();
        }

        /// <summary>
        /// 馬券テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBaken> LoadBakenTable()
        {
            return new BakenTable(DBName).LoadTable();
        }

    }
}
