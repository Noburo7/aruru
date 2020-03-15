using System;
using System.Collections.Generic;

namespace Aruru
{
    public struct Baken {
        public int RaceID;
        public DateTime Date;
        public string TrackName;
        public int RaceNum;
        public string RaceName;
        public string TrackType;
        public int Distance;
        public string Class;
        public string TrackCondition;
        public bool IsHandicap;
        public bool IsOnlyFemale;
        public bool IsOnlyYouth;
        public List<Betting> Bettings;
    }

    public struct Betting {
        public int ID;
        public int TypeID;
        public int Investment;
        public int Payout;
    }
}
