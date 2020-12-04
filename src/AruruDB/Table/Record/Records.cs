namespace AruruDB.Table.Record
{
    internal class BakenTypeRecord : IBakenTypeRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class CourseRecord : ICourseRecord
    {
        public int ID { get; set; }
        public int TrackID { get; set; }
        public int TrackTypeID { get; set; }
        public int Distance { get; set; }
    }

    internal class ClassRecord : IClassRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackRecord : ITrackRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackConditionRecord : ITrackCondition
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackTypeRecord : ITrackTypeRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class RaceRecord : IRaceRecord
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int CourseID { get; set; }
        public int RaceNumber { get; set; }
        public string RaceName { get; set; }
        public int RaceClassID { get; set; }
        public int TrackConditionID { get; set; }
        public int IsHandicap { get; set; }
        public int IsOnlyFemale { get; set; }
        public int IsOnlyYouth { get; set; }
    }

    internal class BakenRecord : IBakenRecord
    {
        public int BakenID { get; set; }
        public int RaceID { get; set; }
        public int BakenTypeID { get; set; }
        public int Investment { get; set; }
        public int Payout { get; set; }
    }
    
    internal class RemarkRecord : IRemarkRecord
    {
        public int RaceID { get; set; }
        public string Remark { get; set; }
    }
}
