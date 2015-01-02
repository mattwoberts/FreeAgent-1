using FreeAgent.Helpers;
using FreeAgent.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System;
using System.Linq;

namespace FreeAgent.Tests
{

    [TestFixture]
    public class SerializerTests
    {
        private const string _testString = @"{""url"":""https://api.freeagent.com/v2/company"",""name"":""My Company"",""subdomain"":""mycompany"",""type"":""UkLimitedCompany"",""currency"":""GBP"",""mileage_units"":""miles"",""company_start_date"":""2010-05-01"",""freeagent_start_date"":""2010-06-01"",""first_accounting_year_end"":""2011-05-01"",""company_registration_number"":""123456"",""sales_tax_registration_status"":""Registered"",""sales_tax_registration_number"":""987654""}";

        [TestFixtureSetUp]
        public void SetUp()
        {
            JsonConvert.DefaultSettings =
                () => new JsonSerializerSettings()
                {
                    ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };
        }


        [Test]
        public void Serializer_Company_Json_Result_Should_Deserialize_Correctly()
        {
            var company = JsonConvert.DeserializeObject<Company>(_testString);

            Assert.IsNotNull(company);
            Assert.AreEqual("My Company", company.Name);
            Assert.AreEqual("mycompany", company.Subdomain);
            Assert.AreEqual(CompanyType.UkLimitedCompany, company.Type);
            Assert.AreEqual("GBP", company.Currency);
            Assert.AreEqual(MileageUnits.Miles, company.MileageUnits);
            Assert.AreEqual(new DateTime(2010, 05, 01), company.CompanyStartDate);
            Assert.AreEqual(new DateTime(2010, 06, 01), company.FreeagentStartDate);
            Assert.AreEqual(new DateTime(2011, 05, 01), company.FirstAccountingYearEnd);
            Assert.AreEqual("123456", company.CompanyRegistrationNumber);
            Assert.AreEqual(SalesTaxRegistrationStatus.Registered, company.SalesTaxRegistrationStatus);
            Assert.AreEqual("987654", company.SalesTaxRegistrationNumber); 
        }

        [Test]
        public void Serializer_Company_Class_Should_Serialize_Correctly()
        {
            var testCompany = new Company
            {
                Url = new Uri("https://api.freeagent.com/v2/company"),
                Name = "My Company",
                Subdomain = "mycompany",
                Type = CompanyType.UkLimitedCompany,
                Currency = "GBP",
                MileageUnits = MileageUnits.Miles,
                CompanyStartDate = new DateTime(2010, 05, 01),
                FreeagentStartDate = new DateTime(2010, 06, 01),
                FirstAccountingYearEnd = new DateTime(2011, 05, 01),
                CompanyRegistrationNumber = "123456",
                SalesTaxRegistrationStatus = SalesTaxRegistrationStatus.Registered,
                SalesTaxRegistrationNumber = "987654"
            };

            var output = JsonConvert.SerializeObject(testCompany);

            Assert.IsNotNull(output);
            Assert.AreEqual(_testString, output);
        }

        [Test]
        public void ExtractId_Company_Url_Should_Throw_ID_Exception()
        {
            // arrange
            var client = new FreeAgentClient(Helper.Configuration());
            var test = new TestUrl 
            { 
                Url = new Uri("https://api.freeagent.com/v2/company")
            };

            // act
            var ex = Helper.RecordException(() => client.ExtractId(test));

            // assert
            Assert.AreEqual(3, test.Url.Segments.Length);
            Assert.AreEqual("company", test.Url.Segments.Last());
            Assert.IsNotNull(ex);
            Assert.IsInstanceOf<FreeAgentException>(ex);
            Assert.AreEqual("Cannot extract ID, expected an integer [https://api.freeagent.com/v2/company]", ex.Message);
        }

        public class TestUrl : IUrl
        {
            public Uri Url { get; set; }
        }
    }
}
