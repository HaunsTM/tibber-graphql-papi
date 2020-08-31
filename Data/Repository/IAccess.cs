using System.Threading.Tasks;
using Data.Model;

namespace Data.Repository
{
    public interface IAccess
    {
        Task InsertViewerResultAsync(Viewer viewerResult);
        PriceInfo GetPrices();
    }
}
