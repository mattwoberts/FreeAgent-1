using System;

namespace FreeAgent.Model
{
	public class InvoiceItem
	{
		public int Position { get; set; }
        public InvoiceItemType ItemType { get; set; }
		public double Quantity { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public double SalesTaxRate { get; set; }
		public double SecondSalesTaxRate { get; set; }
		public Uri Category { get; set; }
	}
}




