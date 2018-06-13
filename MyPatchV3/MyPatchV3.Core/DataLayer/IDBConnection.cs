namespace MyPatchV3.DL
{
    using SQLite;

    public interface IDBConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}

