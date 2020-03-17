using System.Collections.Generic;
using AruruDB;

namespace Aruru
{
    public class DBController : IDBController
    {
        private static readonly string DBNAME = "AruruDB.sqlite";
        private AruruDatabase Database;
        private IEnumerable<IBakenType> BakenTypeTable;
        private IEnumerable<ICourse> CourseTable;
        private IEnumerable<IRaceClass> ClassTable;
        private IEnumerable<ITrackCondition> TrackConditionTable;
        private IEnumerable<ITrack> TrackTable;
        private IEnumerable<ITrackType> TrackTypeTable;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DBController()
        {
            Database = new AruruDatabase(DBNAME);
            LoadMasterTables();
        }

        /// <summary>
        /// 馬券種別名を列挙する。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> EnumerateBakenTypeNames()
        {
            var list = new List<string>();
            foreach (var record in BakenTypeTable)
            {
                list.Add(record.Name);
            }
            return list;
        }

        /// <summary>
        /// クラス名を列挙する。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> EnumerateClassNames()
        {
            var list = new List<string>();
            foreach (var record in ClassTable)
            {
                list.Add(record.Name);
            }
            return list;
        }

        /// <summary>
        /// 馬場状態名を列挙する。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> EnumerateTrackConditionNames()
        {
            var list = new List<string>();
            foreach (var record in TrackConditionTable)
            {
                list.Add(record.Name);
            }
            return list;
        }

        /// <summary>
        /// 競馬場名を列挙する。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> EnumerateTrackNames()
        {
            var list = new List<string>();
            foreach (var record in TrackTable)
            {
                list.Add(record.Name);
            }
            return list;
        }

        /// <summary>
        /// トラックタイプ名を列挙する。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> EnumerateTrackTypeNames()
        {
            var list = new List<string>();
            foreach (var record in TrackTypeTable)
            {
                list.Add(record.Name);
            }
            return list;
        }
         
        private void LoadMasterTables()
        {
            BakenTypeTable = Database.LoadBakenTypeTable();
            CourseTable = Database.LoadCourseTable();
            ClassTable = Database.LoadRaceClassTable();
            TrackConditionTable = Database.LoadTrackConditionTable();
            TrackTable = Database.LoadTrackTable();
            TrackTypeTable = Database.LoadTrackTypeTable();
        }
        
    }
}
