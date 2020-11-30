using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface ICourseTable : ITable
    {
        IEnumerable<ICourseRecord> Records { get; }
        IEnumerable<int> DistanceList(int trackID, int trackTypeID);
        int CourseID(int trackID, int trackTypeID, int distance);
    }
}
