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
        public IEnumerable<Category> AdminExpensesCategories { get; set; }
        public IEnumerable<Category> CostOfSalesCategories { get; set; }
        public IEnumerable<Category> IncomeCategories { get; set; }
        public IEnumerable<Category> GeneralCategories { get; set; }
	}

    public class CategoryWrapper
    {
        public Category AdminExpensesCategories { get; set; }
        public Category CostOfSalesCategories { get; set; }
        public Category IncomeCategories { get; set; }
        public Category GeneralCategories { get; set; }
    }
}

