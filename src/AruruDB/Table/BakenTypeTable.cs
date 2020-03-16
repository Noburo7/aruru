using System;
using System.Collections.Generic;

namespace AruruDB
{
    internal class BakenTypeTable
    {
        public string TableName { get; } = "t_baken_type";
        public string DBName { get; }

        public BakenTypeTable(string dbNm)
        {
            DBName = dbNm;
        }

        public IEnumerable<IBakenType> LoadTable()
        {
            var records = new List<IBakenType>();
            var db = new SQLiteDB(DBName);
            try
            {
                var table = db.Execute($"SELECT * FROM {TableName}");
                foreach (var row in table)
                {
                    var bakenType = new BakenTypeTableRecord
                    {
                        ID = int.Parse(row[0]),
                        Name = row[1]
                    };
                    records.Add(bakenType);
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
