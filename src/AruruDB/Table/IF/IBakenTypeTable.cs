using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IBakenTypeTable : ITable
    {
        IEnumerable<IBakenType> Records { get; }
    }
}
