using Data.Repository;

namespace SQLite
{
    public class Setup : ISetup
    {
        public void CreateDatabase()
        {
            using (var client = new SQLiteContext())
            {
                client.Database.EnsureCreated();
            }
        }
    }
}
