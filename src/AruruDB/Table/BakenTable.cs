﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class BakenTable : IBakenTable
    {
        public IEnumerable<IBakenRecord> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _bakenTableNm = "t_baken";

        public BakenTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\08_T_Baken.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<IBakenRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_bakenTableNm}");
                foreach (var row in table)
                {
                    var baken = new BakenRecord();
                    baken.BakenID = int.Parse(row[0]);
                    baken.RaceID = int.Parse(row[1]);
                    baken.BakenTypeID = int.Parse(row[2]);
                    baken.Investment = int.Parse(row[3]);
                    baken.Payout = int.Parse(row[4]);
                    records.Add(baken);
                }

                Records = records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void InsertRecord(IBakenRecord record)
        {
            var sql = $"INSERT INTO {_bakenTableNm} "
                    + "VALUES(null, "
                    + $"{record.RaceID},"
                    + $"{record.BakenTypeID},"
                    + $"{record.Investment},"
                    + $"{record.Payout})";
            SQLiteDB.ExecuteSql(sql);
            ReadTable();
        }

        public void DeleteRecords(int raceID)
        {
            var sql = $"DELETE FROM {_bakenTableNm} WHERE race_id IS {raceID};";
            SQLiteDB.ExecuteSql(sql);
            ReadTable();
        }

        public IEnumerable<IBakenRecord> GetBakenList(int raceID)
        {
            return Records.Where(o => o.RaceID == raceID);
        }
    }
}
