using FreeAgent.Helpers;
using FreeAgent.Model;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class CategoryExtensions
    {
        public static Task<Categories> GetCategoriesAsync(this FreeAgentClient client)
        {
            return client.GetOrCreateAsync(c => c.CategoryList(client.Configuration.CurrentHeader), r => r); 
        }

        public static async Task<Category> GetCategoryAsync(this FreeAgentClient client, Category category)
        {
            if (category == null || category.NominalCode.IsNullOrEmpty())
                return null;

            return await client.GetCategoryAsync(category.NominalCode);
        }

        public static Task<Category> GetCategoryAsync(this FreeAgentClient client, string nominalCode)
        {
            return client.GetOrCreateAsync(
                c => c.GetCategory(client.Configuration.CurrentHeader, nominalCode),
                r =>
                {
                    if (r != null)
                    {
                        if (r.AdminExpensesCategories != null)
                            return r.AdminExpensesCategories;

                        if (r.CostOfSalesCategories != null)
                            return r.CostOfSalesCategories;

                        if (r.GeneralCategories != null)
                            return r.GeneralCategories;

                        if (r.IncomeCategories != null)
                            return r.IncomeCategories;
                    }

                    return null; //TODO - make this work like a true fail (ie wrong nominal code)
                });
        }
    }
}
