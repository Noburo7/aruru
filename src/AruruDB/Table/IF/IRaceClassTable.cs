using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRaceClassTable : ITable
    {
        IEnumerable<IClassRecord> Records { get; }
    }
}
