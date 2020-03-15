using System;
using System.Collections.Generic;

namespace AruruDB
{
    public class RaceTable : Table
    {
        public List<RaceTableRecord> Records { get; private set; }

        public RaceTable(string dbNm) {
            TableName = "t_race";
            DBName = dbNm;
        }

        public override bool LoadTable() {
            Records = new List<RaceTableRecord>();
            var db = new SQLiteDB(DBName);
            try {
                var table = db.Execute(CreateSQLForLoad());
                foreach (var row in table) {
                    var race = new RaceTableRecord();
                    race.ID                 = int.Parse(row[0]);
                    race.Date               = row[1];
                    race.TrackID            = int.Parse(row[2]);
                    race.RaceNumber         = int.Parse(row[3]);
                    race.RaceName           = row[4];
                    race.TrackTypeID        = int.Parse(row[5]);
                    race.Distance           = int.Parse(row[6]);
                    race.RaceClassID        = int.Parse(row[7]);
                    race.TrackConditionID   = int.Parse(row[8]);
                    race.IsHandicap         = int.Parse(row[9]);
                    race.IsOnlyFemale       = int.Parse(row[10]);
                    race.IsOnlyYouth        = int.Parse(row[11]);
                    Records.Add(race);
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
