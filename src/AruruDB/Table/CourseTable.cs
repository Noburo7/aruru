using System;
using System.Collections.Generic;

namespace AruruDB
{
    internal class CourseTable
    {
        public string TableName { get; } = "t_course";
        public string DBName { get; }

        public CourseTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<ICourse> LoadTable()
        {
            var records = new List<ICourse>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var course = new CourseTableRecord();
                    course.ID = int.Parse(row[0]);
                    course.TrackID = int.Parse(row[1]);
                    course.TrackTypeID = int.Parse(row[2]);
                    course.Distance = int.Parse(row[3]);
                    records.Add(course);
                }
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
