using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IBakenTable : ITable
    {
        IEnumerable<IBakenRecord> Records { get; }

        void InsertRecord(IBakenRecord record);

        void DeleteRecords(int raceID);
    }
}
