﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace AruruDB
{
    public class RaceClassTable : Table
    {
        public List<RaceClassTableRecord> records;

        public RaceClassTable(string dbNm) {
            TableName = "t_race_class";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            records = new List<RaceClassTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var raceClass = new RaceClassTableRecord();
                    raceClass.ID = int.Parse(row[0]);
                    raceClass.Name = row[1];
                    records.Add(raceClass);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public string ReturnNameFor(int id) {
            return records.Where(o => o.ID == id).First().Name;
        }
    }
}