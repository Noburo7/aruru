using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

using System;

namespace AruruDB
{
    public class AruruDBGenerator
    {
        private string _dbName;
        private Progress _progress;
        private List<string> _TableFilePathList;
        private List<string> _RecordFilePathList;

        public AruruDBGenerator(string dbName, Progress progress) {
            _dbName = dbName;
            _progress = progress;
            InitTableFilePathList();
            InitRecordFilePathList();
        }

        private void InitTableFilePathList() {
            _TableFilePathList = new List<string>();
            _TableFilePathList.Add(@"Sql\Table\01_T_Baken_Type.sql");
            _TableFilePathList.Add(@"Sql\Table\02_T_Track.sql");
            _TableFilePathList.Add(@"Sql\Table\03_T_Track_Type.sql");
            _TableFilePathList.Add(@"Sql\Table\04_T_Race_Class.sql");
            _TableFilePathList.Add(@"Sql\Table\05_T_Track_Condition.sql");
            _TableFilePathList.Add(@"Sql\Table\06_T_Race.sql");
            _TableFilePathList.Add(@"Sql\Table\07_T_Baken.sql");
        }

        private void InitRecordFilePathList() {
            _RecordFilePathList = new List<string>();
            _RecordFilePathList.Add(@"Sql\Record\01_T_Baken_Type_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\02_T_Track_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\03_T_Track_Type_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\04_T_Race_Class_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\05_T_Track_Condition_Record.sql");
        }

        public bool Run() {
            if (!CreateDB()) return false;
            if (!CreateTable()) return false;
            if (!InsertRecord()) return false;
            _progress.AddProgress($"{_dbName} was generated successfully.");
            return true;
        }

        private bool CreateDB() {
            try {
                SQLiteConnection.CreateFile(_dbName);
                _progress.AddProgress($"Created database file:{_dbName}");
                return true;
            }
            catch (Exception ex) {
                _progress.AddProgress("DB file creation was failed.");
                _progress.AddProgress(ex.ToString());
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool CreateTable() {
            try {
                foreach (var path in _TableFilePathList) {
                    new SQL(Path.Combine(Directory.GetCurrentDirectory(), path), _dbName).Execute();
                    _progress.AddProgress($"Created table by {path}.");
                }
                return true;
            }
            catch (Exception ex) {
                _progress.AddProgress("Table creation was failed.");
                _progress.AddProgress(ex.ToString());
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool InsertRecord() {
            try {
                foreach (var path in _RecordFilePathList) {
                    new SQL(Path.Combine(Directory.GetCurrentDirectory(), path), _dbName).Execute();
                    _progress.AddProgress($"Inserted record by {path}.");
                }
                return true;
            }
            catch (Exception ex) {
                _progress.AddProgress("Record Insert was failed.");
                _progress.AddProgress(ex.ToString());
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
