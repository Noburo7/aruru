using System;
using System.Linq;
using System.Collections.Generic;
using AruruDB;

namespace Aruru
{
    public class AruruDataBase
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

        public List<Baken> GenerateBakenList() {
            var bakenList = new List<Baken>();
            foreach (var record in RaceTable.Records) {
                var baken = new Baken();
                baken.RaceID = record.ID;
                baken.Date = DateTime.Parse(record.Date);
                baken.TrackName = TrackTable.ReturnNameFor(record.TrackID);
                baken.RaceNum = record.RaceNumber;
                baken.RaceName = record.RaceName;
                baken.TrackType = TrackTypeTable.ReturnNameFor(record.TrackTypeID);
                baken.Distance = record.Distance;
                baken.Class = RaceClassTable.ReturnNameFor(record.RaceClassID);
                baken.TrackCondition = TrackConditionTable.ReturnNameFor(record.TrackConditionID);
                baken.IsHandicap = record.IsHandicap == 1;
                baken.IsOnlyFemale = record.IsOnlyFemale == 1;
                baken.IsOnlyYouth = record.IsOnlyYouth == 1;

                baken.Bettings = new List<Betting>();
                var targetList = BakenTable.Records.Select(o => o.RaceID == record.ID) as List<BakenTableRecord>;
                foreach (var item in targetList) {
                    var betting = new Betting();
                    betting.ID = item.BakenID;
                    betting.TypeID = item.BakenTypeID;
                    betting.Investment = item.Investment;
                    betting.Payout = item.Payout;
                    baken.Bettings.Add(betting);
                }

                bakenList.Add(baken);
            }

            return bakenList;
        }
    }
}
