﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class BakenTypeTable : IBakenTypeTable
    {
        private static readonly string _bakenTypeTableNm = "t_baken_type";

        public ISQLiteDB SQLiteDB { get; }
        public IEnumerable<IBakenTypeRecord> Records { get; private set; }

        public BakenTypeTable(SQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\01_T_Baken_Type.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\01_T_Baken_Type_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<IBakenTypeRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_bakenTypeTableNm}");
                foreach (var row in table)
                {
                    var bakenType = new BakenTypeRecord
                    {
                        ID = int.Parse(row[0]),
                        Name = row[1]
                    };
                    records.Add(bakenType);
                }

                Records = records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BakenTypeID(string bakenTypeNm)
        {
            return Records.Where(o => o.Name == bakenTypeNm).First().ID;
        }

        public string BakenType(int bakenTypeID)
        {
            return Records.Where(o => o.ID == bakenTypeID).First().Name;
        }
    }
}
