using FreeAgent.Model;
using System;
using System.Threading.Tasks;
using FreeAgent.Helpers;

namespace FreeAgent
{
    public static class CategoryExtensions
    {
        public static async Task<Categories> GetCategoriesAsync(this FreeAgentClient client)
        {
            var result = await client.Execute(c => c.CategoryList(client.Configuration.CurrentHeader));
            return result;
        }

        public static async Task<Category> GetCategoryAsync(this FreeAgentClient client, Category category)
        {
            if (category == null || category.NominalCode.IsNullOrEmpty())
                return null;

            return await client.GetCategoryAsync(category.NominalCode);
        }

        public static async Task<Category> GetCategoryAsync(this FreeAgentClient client, string nominalCode)
        {
            var result = await client.Execute(c => c.GetCategory(client.Configuration.CurrentHeader, nominalCode));

            if (result != null)
            {
                if (result.AdminExpensesCategories != null)
                    return result.AdminExpensesCategories;

                if (result.CostOfSalesCategories != null)
                    return result.CostOfSalesCategories;

                if (result.GeneralCategories != null)
                    return result.GeneralCategories;

                if (result.IncomeCategories != null)
                    return result.IncomeCategories;
            }
 
            return null; //TODO - make this work like a true fail (ie wrong nominal code)
        }
    }
}
