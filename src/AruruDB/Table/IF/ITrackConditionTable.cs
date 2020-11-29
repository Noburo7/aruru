using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ITrackConditionTable : ITable
    {
        IEnumerable<ITrackCondition> Records { get; }
    }
}
