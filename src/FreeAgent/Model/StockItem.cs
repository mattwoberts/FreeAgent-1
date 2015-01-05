using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class StockItem : IUrl
	{
        public Uri Url { get; set; }
		public string Description { get; set; }
		public double OpeningQuantity { get; set; }
		public double OpeningBalance { get; set; }
		public double StockOnHand { get; set; }
		public Uri CostOfSaleCategory { get; set; }
	}
	
	public class StockItemWrapper
	{
		public StockItem StockItem { get; set; }
        public List<StockItem> StockItems { get; set; }
    }
}