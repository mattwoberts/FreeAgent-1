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
        public async Task CanRetrieveCompanyDetails()
        {
            // arrange

            // act             
            var company = await this.Client.GetCompanyAsync();

            // assert
            Assert.IsNotNull(company);
            Assert.IsNotNullOrEmpty(company.Name);
        }

        [Test]
        public async Task GetTaxTimelinesReturnsListWithContent()
        {
            // arrange

            // act 
            var timelines = await this.Client.GetTaxTimelinesAsync();

            // assert 
            Assert.IsNotNull(timelines);
            CollectionAssert.IsNotEmpty(timelines);

            foreach (TaxTimeline item in timelines)
            {
                Assert.IsNotNullOrEmpty(item.Description);
                Assert.IsNotNull(item.DatedOn);
            }
        }

    }
}
