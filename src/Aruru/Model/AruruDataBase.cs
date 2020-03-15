using System;
using System.Linq;
using System.Collections.Generic;
using AruruDB;

namespace Aruru
{
    public class AruruDataBase : IAruruDB
    {
        public BakenTypeTable BakenTypeTable { get; private set; }
        public RaceClassTable RaceClassTable { get; private set; }
        public TrackConditionTable TrackConditionTable { get; private set; }
        public TrackTable TrackTable { get; private set; }
        public TrackTypeTable TrackTypeTable { get; private set; }
        public CourseTable CourseTable { get; private set; }
        public RaceTable RaceTable { get; private set; }
        public BakenTable BakenTable { get; private set; }

        public AruruDataBase(string dbName) {
            BakenTypeTable = new BakenTypeTable(dbName);
            RaceClassTable = new RaceClassTable(dbName);
            TrackConditionTable = new TrackConditionTable(dbName);
            TrackTable = new TrackTable(dbName);
            TrackTypeTable = new TrackTypeTable(dbName);
            CourseTable = new CourseTable(dbName);
            RaceTable = new RaceTable(dbName);
            BakenTable = new BakenTable(dbName);
        }

        /// <summary>
        /// すべてのテーブルをロードする。
        /// </summary>
        public void LoadAruruDB() {
            BakenTypeTable.LoadTable();
            RaceClassTable.LoadTable();
            TrackConditionTable.LoadTable();
            TrackTable.LoadTable();
            TrackTypeTable.LoadTable();
            CourseTable.LoadTable();
            RaceTable.LoadTable();
            BakenTable.LoadTable();
        }

        /// <summary>
        /// DBに登録されている馬券情報リストを返す。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBaken> GenerateBakenList()
        {
            var bakenList = new List<IBaken>();
            foreach (var record in RaceTable.Records)
            {
                var baken = new Baken
                {
                    RaceID = record.ID,
                    Date = DateTime.Parse(record.Date),
                    TrackName = TrackTable.ReturnNameFor(record.TrackID),
                    RaceNum = record.RaceNumber,
                    RaceName = record.RaceName,
                    TrackType = TrackTypeTable.ReturnNameFor(record.TrackTypeID),
                    Distance = record.Distance,
                    Class = RaceClassTable.ReturnNameFor(record.RaceClassID),
                    TrackCondition = TrackConditionTable.ReturnNameFor(record.TrackConditionID),
                    IsHandicap = record.IsHandicap == 1,
                    IsOnlyFemale = record.IsOnlyFemale == 1,
                    IsOnlyYouth = record.IsOnlyYouth == 1
                };

                var bettings = new List<IBet>();
                var targetList = BakenTable.Records.Select(o => o.RaceID == record.ID) as List<BakenTableRecord>;
                foreach (var item in targetList)
                {
                    var betting = new Bet
                    {
                        ID = item.BakenID,
                        TypeID = item.BakenTypeID,
                        Investment = item.Investment,
                        Payout = item.Payout
                    };
                    bettings.Add(betting);
                }
                baken.Bettings = bettings;
                bakenList.Add(baken);
            }

            return bakenList;
        }
    }
}
