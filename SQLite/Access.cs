using System;
using Data.Model;
using Data.Repository;

namespace SQLite
{
    public class Access : IAccess
    {

        public void InsertPrices(Viewer viewerResult)
        {
            try
            {
                using (var context = new SQLiteContext()) // or whatever your context is
                {
                    context.Add(viewerResult);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public PriceInfo GetPrices()
        {
            return null;
        }
    }
}
