using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ITrackTable : ITable
    {
        IEnumerable<ITrack> Records { get; }
    }
}
