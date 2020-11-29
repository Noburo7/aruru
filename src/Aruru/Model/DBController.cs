using System.Collections.Generic;
using System.Linq;
using AruruDB;

namespace Aruru
{
    public class DBController : IDBController
    {
        private static readonly string DBNAME = "AruruDB.sqlite";
        private readonly AruruDatabase _db;
        public IEnumerable<IBakenType> BakenTypeTable { get; private set; }
        public IEnumerable<IRaceClass> ClassTable { get; private set; }
        public IEnumerable<ITrackCondition> TrackConditionTable { get; private set; }
        public IEnumerable<ITrack> TrackTable { get; private set; }
        public IEnumerable<ITrackType> TrackTypeTable { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DBController()
        {
            _db = new AruruDatabase();
            LoadMasterTables();
        }

        private void LoadMasterTables()
        {
            BakenTypeTable = _db.ReadBakenTypeTable();
            ClassTable = _db.ReadRaceClassTable();
            TrackConditionTable = _db.ReadTrackConditionTable();
            TrackTable = _db.ReadTrackTable();
            TrackTypeTable = _db.ReadTrackTypeTable();
        }

        /// <summary>
        /// 距離リストを返す
        /// </summary>
        /// <param name="trackName">競馬場名</param>
        /// <param name="trackTypeName">トラックタイプ名</param>
        /// <returns></returns>
        public IEnumerable<int> EnumerateDistance(string trackName, string trackTypeName)
        {
            var trackID = TrackTable.Where(o => o.Name == trackName).First().ID;
            var trackTypeID = TrackTypeTable.Where(o => o.Name == trackTypeName).First().ID;
            return _db.ReadDistanceList(trackID, trackTypeID);
        }
    }
}
