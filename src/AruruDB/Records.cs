namespace AruruDB
{
    public struct BakenTypeTableRecord {
        public int ID;
        public string Name;
    }

    public struct CourseTableRecord {
        public int ID;
        public int TrackID;
        public int TrackTypeID;
        public int Distance;
    }

    public struct RaceClassTableRecord {
        public int ID;
        public string Name;
    }

    public struct TrackTableRecord{
        public int ID;
        public string Name;
    }

    public struct TrackConditionTableRecord {
        public int ID;
        public string Name;
    }

    public struct TrackTypeTableRecord {
        public int ID;
        public string Name;
    }

    public struct RaceTableRecord {
        public int ID;
        public string Date;
        public int TrackID;
        public int RaceNumber;
        public string RaceName;
        public int TrackTypeID;
        public int Distance;
        public int RaceClassID;
        public int TrackConditionID;
        public int IsHandicap;
        public int IsOnlyFemale;
        public int IsOnlyYouth;
    }

    public struct BakenTableRecord {
        public int BakenID;
        public int RaceID;
        public int BakenTypeID;
        public int Investment;
        public int Payout;
    }    
}
