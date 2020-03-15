namespace AruruDB
{
    abstract public class Table
    {
        protected string DBName;
        protected string TableName;

        abstract public bool LoadTable();

        protected string CreateSQLForLoad() {
            var sql = $"SELECT * FROM {TableName}";
            return sql;
        }
    }
}
