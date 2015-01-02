using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class CategoryTests : TestFixtureBase
    {
        [Test]
        public async Task Category_Get_Should_Return_Something()
        {
            var categories = await this.Client.GetCategoriesAsync();

            Assert.IsNotNull(categories);
        }

        [Test]
        public async Task Category_Get_Single_Without_NominalCode_Should_Return_Null()
        {
            // arrange
            var source = new Category();

            // act
            var result = await this.Client.GetCategoryAsync(source);

            // assert
            Assert.IsNull(result);
        }


        [Test]
        public async Task Category_Get_Single_Should_Return_Category()
        {
            // arrange
            var nominalCode = "285"; //TODO - make this more robust??

            // act - get the one just created by number
            var category = await this.Client.GetCategoryAsync(nominalCode);

            // assert
            Assert.IsNotNull(category);
            Assert.AreEqual("Accommodation and Meals", category.Description);
            Assert.AreEqual("285", category.NominalCode);
            Assert.AreEqual(true, category.AllowableForTax);
            Assert.AreEqual("Travel and subsistence expenses", category.TaxReportingName);
            Assert.AreEqual("Standard rate", category.AutoSalesTaxRate);
        }

        [Test]
        public void Category_Get_Single_With_Dummy_Code_Should_Throw()
        {
            // arrange
            var nominalCode = "8777"; //TODO - make this more robust??

            // act
            var exResult = Helper.RecordException(() => this.Client.GetCategoryAsync(nominalCode));

            // assert
            Assert.IsInstanceOf<FreeAgentException>(exResult);
            var freeAgentException = exResult as FreeAgentException;
            Assert.IsNotNull(freeAgentException);
            Assert.IsNotNull(freeAgentException.InnerException);
            Assert.IsInstanceOf<Refit.ApiException>(freeAgentException.InnerException); //TODO - surface this info 

            var refitException = freeAgentException.InnerException as Refit.ApiException;
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, refitException.StatusCode);
        }       
    }
}
