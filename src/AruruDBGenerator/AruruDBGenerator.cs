using System.IO;
using System.Collections.Generic;
using AruruDB.DBCreator;

using System;

namespace AruruDBGenerator
{
    public class AruruDBGenerator
    {
        private string _dbName;
        private Progress _progress;
        private List<string> _TableFilePathList;
        private List<string> _RecordFilePathList;
        private ICreator _dbCreator;

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
            _TableFilePathList.Add(@"Sql\Table\08_T_Course.sql");
        }

        private void InitRecordFilePathList() {
            _RecordFilePathList = new List<string>();
            _RecordFilePathList.Add(@"Sql\Record\01_T_Baken_Type_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\02_T_Track_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\03_T_Track_Type_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\04_T_Race_Class_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\05_T_Track_Condition_Record.sql");
            _RecordFilePathList.Add(@"Sql\Record\08_T_Course_Record.sql");
        }

        public bool Run() {
            _dbCreator = new Creator(_dbName);
            if (!CreateDB()) return false;
            if (!CreateTable()) return false;
            if (!InsertRecord()) return false;
            _progress.AddProgress($"{ _dbName} was generated successfully.");
            return true;
        }

        private bool CreateDB() {
            try {
                _dbCreator.CreateTable();
                _progress.AddProgress($"Created database file:{_dbName}");
                return true;
            }
            catch (Exception ex){
                _progress.AddProgress($"[Error]Creation database {_dbName} was failed.");
                _progress.AddProgress(ex.ToString());
                return false;
            }
        }

        private bool CreateTable() {
            try {
                foreach (var path in _TableFilePathList) {
                    var sql = File.ReadAllText(path);
                    _dbCreator.ExecuteSql(sql);
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
                    var sql = File.ReadAllText(path);
                    _dbCreator.ExecuteSql(sql);
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
