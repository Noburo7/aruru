using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ITrackTypeTable : ITable
    {
        IEnumerable<ITrackTypeRecord> Records { get; }
        int TrackTypeID(string trackTypeNm);
    }
}
