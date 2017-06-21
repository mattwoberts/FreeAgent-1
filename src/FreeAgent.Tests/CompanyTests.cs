using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FreeAgent.Model;
using System.Threading.Tasks;

namespace FreeAgent.Tests
{
    public class CompanyTests : TestFixtureBase
    {
        [Test]
        public async Task Company_Can_Retrieve_Details()
        {
            // arrange

            // act             
            var company = await this.Client.GetCompanyAsync();

            // assert
            Assert.IsNotNull(company);
            Assert.IsNotEmpty(company.Name);
        }

        [Test]
        public async Task Company_Get_TaxTimelines_Returns_List_With_Content()
        {
            // arrange

            // act 
            var timelines = await this.Client.GetTaxTimelinesAsync();

            // assert 
            Assert.IsNotNull(timelines);
            CollectionAssert.IsNotEmpty(timelines);

            foreach (TaxTimeline item in timelines)
            {
                Assert.IsNotEmpty(item.Description);
                Assert.IsNotNull(item.DatedOn);
            }
        }

    }
}
