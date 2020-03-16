namespace AruruDB
{
    internal class BakenTypeTableRecord : IBakenType
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class CourseTableRecord : ICourse
    {
        public int ID { get; set; }
        public int TrackID { get; set; }
        public int TrackTypeID { get; set; }
        public int Distance { get; set; }
    }

    internal class RaceClassTableRecord : IRaceClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackTableRecord : ITrack
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackConditionTableRecord : ITrackCondition
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class TrackTypeTableRecord : ITrackType
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class RaceTableRecord : IRace
    {
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

    internal class BakenTableRecord : IBaken
    {
        public int BakenID { get; set; }
        public int RaceID { get; set; }
        public int BakenTypeID { get; set; }
        public int Investment { get; set; }
        public int Payout { get; set; }
    }    
}
