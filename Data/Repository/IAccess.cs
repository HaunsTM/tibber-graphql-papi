using Data.Model;

namespace Data.Repository
{
    public interface IAccess
    {
        void InsertPrices(Viewer viewerResult);
        PriceInfo GetPrices();
    }
}
