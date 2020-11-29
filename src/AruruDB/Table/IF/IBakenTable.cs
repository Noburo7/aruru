using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IBakenTable : ITable
    {
        IEnumerable<IBaken> Records { get; }
    }
}
