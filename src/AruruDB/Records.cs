namespace AruruDB
{
    public class BakenTypeTableRecord {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CourseTableRecord {
        public int ID { get; set; }
        public int TrackID { get; set; }
        public int TrackTypeID { get; set; }
        public int Distance { get; set; }
    }

    public class RaceClassTableRecord {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class TrackTableRecord{
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class TrackConditionTableRecord {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class TrackTypeTableRecord {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class RaceTableRecord {
        public int ID { get; set; }
        public string Date { get; set; }
        public int TrackID { get; set; }
        public int RaceNumber { get; set; }
        public string RaceName { get; set; }
        public int TrackTypeID { get; set; }
        public int Distance { get; set; }
        public int RaceClassID { get; set; }
        public int TrackConditionID { get; set; }
        public int IsHandicap { get; set; }
        public int IsOnlyFemale { get; set; }
        public int IsOnlyYouth { get; set; }
    }

    public class BakenTableRecord {
        public int BakenID { get; set; }
        public int RaceID { get; set; }
        public int BakenTypeID { get; set; }
        public int Investment { get; set; }
        public int Payout { get; set; }
    }    
}
