using System;
using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public interface IRaceTable : ITable
    {
        IEnumerable<IRaceRecord> Records { get; }

        /// <summary>
        /// RaceTableにrecordをINSERTする。
        /// </summary>
        /// <param name="record">INSERT対象</param>
        void InsertRecord(IRaceRecord record);

        void DeleteRecord(int raceID);

        /// <summary>
        /// レースIDを返す
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="courseID">コースID</param>
        /// <param name="raceNumber">レース番号</param>
        /// <returns>レースID</returns>
        int RaceID(string date, int courseID, int raceNumber);

        IRaceRecord GetRaceRecord(int raceID);

        bool ExistRecord(string date, int trackID, int raceNumber);
    }
}
