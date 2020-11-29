using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ITrackTypeTable : ITable
    {
        IEnumerable<ITrackType> Records { get; }
    }
}
