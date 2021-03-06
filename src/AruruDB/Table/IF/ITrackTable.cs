﻿using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ITrackTable : ITable
    {
        IEnumerable<ITrackRecord> Records { get; }
        int TrackID(string trackNm);
        bool UniqueTrack(string trackNm);
    }
}
