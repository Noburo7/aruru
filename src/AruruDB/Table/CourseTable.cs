using System;
using System.Collections.Generic;

namespace AruruDB
{
    public class CourseTable : Table
    {
        public List<CourseTableRecord> Records { get; private set; }

        public CourseTable(string dbNm) {
            TableName = "t_course";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            Records = new List<CourseTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var course = new CourseTableRecord();
                    course.ID = int.Parse(row[0]);
                    course.TrackID = int.Parse(row[1]);
                    course.TrackTypeID = int.Parse(row[2]);
                    course.Distance = int.Parse(row[3]);
                    Records.Add(course);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
