using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace SQLite
{
    public class Access : IAccess
    {
        private async Task UpsertPriceInfoAsync(Price price)
        {
            using (var context = new SQLiteContext())
            {
                var currentPrice = await context.Prices.FirstOrDefaultAsync(p => p == price);

                if (currentPrice == null)
                {
                    await context.Prices.AddAsync(currentPrice);
                    await context.SaveChangesAsync();
                }
            }
        }

        private async Task UpsertSubscriptionAsync(Subscription subscription)
        {
            using (var context = new SQLiteContext())
            {
                var currentSubscription = await context.Subscriptions.FirstOrDefaultAsync(s => s == subscription);

                if (currentSubscription != null)
                {
                    var pricesTodays = subscription.priceInfo.today;
                    foreach (var priceToday in pricesTodays)
                    {
                        await this.UpsertPriceInfoAsync(priceToday);
                    }
                }
                else
                {
                    await context.Subscriptions.AddAsync(subscription);
                    await context.SaveChangesAsync();
                }
            }
        }

        private async Task UpsertHomeAsync(Home home)
        {
            using (var context = new SQLiteContext())
            {
                var currentHome = await context.Homes.FirstOrDefaultAsync(h => h == home);

                if (currentHome != null)
                {
                    var subscriptions = home.subscriptions;
                    foreach (var subscription in subscriptions)
                    {
                        await this.UpsertSubscriptionAsync(subscription);
                    }
                }
                else
                {
                    await context.Homes.AddAsync(home);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task InsertViewerResultAsync(Viewer viewerResult)
        {
            try
            {
                using (var context = new SQLiteContext())
                {
                    var currentViewer = await context.Viewers.FirstOrDefaultAsync(v => v.userId == viewerResult.userId);

                    if (currentViewer != null)
                    {
                        await this.UpsertHomeAsync(viewerResult.home);
                    }
                    else
                    {
                        context.Add(viewerResult);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /*****************************/
        public PriceInfo GetPrices()
        {
            return null;
        }
    }
}
