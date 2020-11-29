using System;
using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRaceTable : ITable
    {
        IEnumerable<IRace> Records { get; }
    }
}
