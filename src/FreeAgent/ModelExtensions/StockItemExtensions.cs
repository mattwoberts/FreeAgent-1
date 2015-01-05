using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class StockItemExtensions
    {
        public static Task<List<StockItem>> GetStockItemsAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.StockItemList(client.Configuration.CurrentHeader), r => r.StockItems);
        }

        public static Task<StockItem> GetStockItemAsync(this FreeAgentClient client, StockItem stockItem)
        {
            var id = client.ExtractId(stockItem);
            return client.GetStockItemAsync(id);
        }

        public static Task<StockItem> GetStockItemAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetStockItemAsync(id);
        }

        public static Task<StockItem> GetStockItemAsync(this FreeAgentClient client, int stockItemId)
        {
            return client.GetOrCreateAsync(c => c.GetStockItem(client.Configuration.CurrentHeader, stockItemId), r => r.StockItem); 
        }

        internal static StockItemWrapper Wrap(this StockItem stockItem)
        {
            return new StockItemWrapper { StockItem = stockItem };
        }
    }
}
