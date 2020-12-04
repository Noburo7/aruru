using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRemarkTable : ITable
    {
        IEnumerable<IRemarkRecord> Records { get; }
    }
}
