using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ICourseTable : ITable
    {
        IEnumerable<ICourse> Records { get; }
        IEnumerable<int> DistanceList(int trackID, int trackTypeID);
    }
}
