using System;
using System.Collections.Generic;

namespace AruruDB
{
    internal class RaceClassTable
    {
        public string TableName { get; } = "t_race_class";
        public string DBName { get; }
        public RaceClassTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<IRaceClass> LoadTable()
        {
            var records = new List<IRaceClass>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var raceClass = new RaceClassTableRecord();
                    raceClass.ID = int.Parse(row[0]);
                    raceClass.Name = row[1];
                    records.Add(raceClass);
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
