using System;
using System.IO;
using System.Collections.Generic;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    internal class RemarkTable : IRemarkTable
    {
        public IEnumerable<IRemarkRecord> Records { get; private set; }

        /// <summary>
        /// SQLLiteDB
        /// </summary>
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _remarkTableNm = "t_remark";

        public RemarkTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        /// <summary>
        /// テーブルを初期化する
        /// </summary>
        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\09_T_Remark.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// テーブルを読み込む
        /// </summary>
        public void ReadTable()
        {
            var records = new List<IRemarkRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_remarkTableNm}");
                foreach (var row in table)
                {
                    var record = new RemarkRecord();
                    record.RaceID = int.Parse(row[0]);
                    record.Remark = row[1];
                    records.Add(record);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
