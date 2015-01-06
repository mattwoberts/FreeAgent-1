using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FreeAgent.Model;
using System.Threading.Tasks;

namespace FreeAgent.Tests
{
    public class AttachmentTests : TestFixtureBase
    {
        //TODO - implement setup and teardown to create an expense with an attachment so we can test these...

        [Test]
        public void Attachments_Get_Single_With_No_Url_Should_Throw()
        {
            // arrange
     //       var source = Helper.NewStandardBankAccount();

            // act
   //         var exResult = Helper.RecordException(() => this.Client.GetBankAccountAsync(source.Url));

            // assert
 //           Assert.IsInstanceOf<FreeAgentException>(exResult);
//            Assert.AreEqual("Cannot extract ID from blank Url", exResult.Message);
        }

        [Test]
        public async Task Attachments_Get_Single_Show_Return_Data()
        {
            // arrange

            // act             
//            var company = await this.Client.GetCompanyAsync();

            // assert
  //          Assert.IsNotNull(company);
    //        Assert.IsNotNullOrEmpty(company.Name);
        }

        [Test]
        public async Task Attachments_Delete_Single_Should_Succeed()
        {
            //// arrange

            //// act 
            //var timelines = await this.Client.GetTaxTimelinesAsync();

            //// assert 
            //Assert.IsNotNull(timelines);
            //CollectionAssert.IsNotEmpty(timelines);

            //foreach (TaxTimeline item in timelines)
            //{
            //    Assert.IsNotNullOrEmpty(item.Description);
            //    Assert.IsNotNull(item.DatedOn);
            //}
        }

    }
}
