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

        public IEnumerable<int> LoadDistance(int trackID, int trackTypeID)
        {
            var list = new List<int>();
            var db = new SQLiteDB(DBName);
            try
            {
                var result = db.Execute(GenerateSQLForDistanceLoading(trackID, trackTypeID));
                foreach (var row in result)
                {
                    list.Add(int.Parse(row[0]));
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        private string GenerateSQLForDistanceLoading(int trackID, int trackTypeID)
        {
            string sql = $"SELECT distance FROM {TableName}" + Environment.NewLine;
            sql += $"WHERE track_id = {trackID} AND track_type_id = {trackTypeID}" + Environment.NewLine;
            sql += "ORDER BY distance";
            return sql;
        }
    }
}
