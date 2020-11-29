using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRaceClassTable : ITable
    {
        IEnumerable<IRaceClass> Records { get; }
    }
}
