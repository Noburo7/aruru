using System;
using System.Collections.Generic;
using System.IO;
using AruruDB.Table.Record;

namespace AruruDB.Table
{
    public class CourseTable : ICourseTable
    {
        public IEnumerable<ICourseRecord> Records { get; private set; }
        public ISQLiteDB SQLiteDB { get; }

        private static readonly string _courseTableNm = "t_course";

        public CourseTable(ISQLiteDB sqliteDB)
        {
            SQLiteDB = sqliteDB;
        }

        public void Init()
        {
            try
            {
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Table\08_T_Course.sql"));
                SQLiteDB.ExecuteSql(File.ReadAllText(@"Sql\Record\08_T_Course_Record.sql"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadTable()
        {
            var records = new List<ICourseRecord>();
            try
            {
                var table = SQLiteDB.ExecuteSql($"SELECT * FROM {_courseTableNm}");
                foreach (var row in table)
                {
                    var courseTableRecord = new CourseRecord();
                    courseTableRecord.ID = int.Parse(row[0]);
                    courseTableRecord.TrackID = int.Parse(row[1]);
                    courseTableRecord.TrackTypeID = int.Parse(row[2]);
                    courseTableRecord.Distance = int.Parse(row[3]);
                    records.Add(courseTableRecord);
                }
                Records = records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public IEnumerable<int> DistanceList(int trackID, int trackTypeID)
        {
            var list = new List<int>();
            var sql = $"SELECT distance FROM {_courseTableNm}" + Environment.NewLine
                        + $"WHERE track_id = {trackID} AND track_type_id = {trackTypeID}" + Environment.NewLine
                        + "ORDER BY distance";
            try
            {
                var result = SQLiteDB.ExecuteSql(sql);
                foreach (var row in result)
                {
                    list.Add(int.Parse(row[0]));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
