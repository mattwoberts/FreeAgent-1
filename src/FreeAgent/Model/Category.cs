using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Category : IUrl
	{
        public Uri Url { get; set; }
        public string Description { get; set; }
		public string NominalCode { get; set; }
		public bool AllowableForTax { get; set; }
		public string TaxReportingName { get; set; }
		public string AutoSalesTaxRate { get; set; }
	}

	public class Categories
	{
		public List<Category> AdminExpensesCategories { get; set; }
		public List<Category> CostOfSalesCategories { get; set; }
		public List<Category> IncomeCategories { get; set; }
		public List<Category> GeneralCategories { get; set; }
	}
}

