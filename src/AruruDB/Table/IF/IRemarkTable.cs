using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRemarkTable : ITable
    {
        IEnumerable<IRemarkRecord> Records { get; }

        void InsertRecord(int raceID, string remark);

        void DeleteRecord(int raceID);
    }
}
