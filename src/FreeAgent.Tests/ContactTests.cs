using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class ContactTests : TestFixtureBase
    {
        [Test]
        public async Task Contact_Get_Should_Return_Something()
        {
            var contacts = await this.Client.GetContactsAsync();

            Assert.IsNotNull(contacts);
            CollectionAssert.IsNotEmpty(contacts);
        }

        [Test]
        [Ignore("Only run this when you need loads of contacts")]
        public async Task Can_Insert_120_Contacts()
        {
            for (int i = 0; i < 120; i++)
            {
                var contact = Helper.NewContact();

                var result = await this.Client.CreateContactAsync(contact);
                
                // Rate limit throttle 
                await Task.Delay(900);
            }
            
        }
        
        [Test]
        public async Task CanGetPagesOfContacts()
        {
            //Set up your freeagent dev account with 100+ contacts (use the above test to do it)
            int pageNumber = 1;

            var contacts = await this.Client.GetContactsPageAsync(ContactFilter.All, ContactOrder.Name, pageNumber);
            
            Assert.That(contacts.Count(), Is.EqualTo(100)); //Make sure the per_page parameter is working

            pageNumber++;
            
             contacts = await this.Client.GetContactsPageAsync(ContactFilter.All, ContactOrder.Name, pageNumber);
            
            //Chances are you've got more than just the 120 we inserted
            Assert.That(contacts.Count(), Is.GreaterThanOrEqualTo(20));
 
        }

        [Test]
        public async Task Contact_Create_Should_Return_Same_With_Url()
        {
            // arrange
            var source = Helper.NewContact();

            // act
            var result = await this.Client.CreateContactAsync(source);

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.AreEqual(result.FirstName, source.FirstName);
            Assert.AreEqual(result.LastName, source.LastName);
            Assert.AreEqual(result.Address1, source.Address1);
            Assert.IsNotNull(result.CreatedAt);
            Assert.IsNotNull(result.UpdatedAt);
        }

        [Test]
        public void Contact_Get_Single_Without_Url_Should_Throw()
        {
            // arrange
            var source = Helper.NewContact();

            // act
            var exResult = Helper.RecordException(() => this.Client.GetContactAsync(source.Url));

            // assert
            Assert.IsInstanceOf<FreeAgentException>(exResult);
            Assert.AreEqual("Cannot extract ID from blank Url", exResult.Message);
        }


        [Test]
        public async Task Contact_Get_Single_Should_Return_Contact()
        {
            // arrange
            var source = Helper.NewContact();
            var contact = await this.Client.CreateContactAsync(source);

            Assert.IsNotNull(contact.Url);

            // act - get the one just created by number
            var contactByUrl = await this.Client.GetContactAsync(contact.Url);
            var contactByObject = await this.Client.GetContactAsync(contact.Url);

            // assert
            Assert.IsNotNull(contactByUrl);
            Assert.AreEqual(contact.Url, contactByUrl.Url);
            Assert.AreEqual(contact.Url, contactByObject.Url);
            Assert.AreEqual(contact.CreatedAt.Value.ToString("g"), contactByUrl.CreatedAt.Value.ToString("g"));
            Assert.AreEqual(contact.CreatedAt.Value.ToString("g"), contactByObject.CreatedAt.Value.ToString("g"));
        }

        [Test]
        public async Task Contact_Update_Should_Store_Updated_Details()
        {
            // arrange
            var source = Helper.NewContact();
            var contact = await this.Client.CreateContactAsync(source);

            Assert.IsNotNull(contact.Url);

            // act - update the one just created
            contact.Address2 = "*UPDATED*";
            await this.Client.UpdateContactAsync(contact);

            // assert
            var contact2 = await this.Client.GetContactAsync(contact);

            Assert.AreEqual(contact.Url, contact2.Url);
            Assert.AreEqual(contact.CreatedAt.Value.ToString("g"), contact2.CreatedAt.Value.ToString("g"));
            Assert.AreEqual(contact.Address2, contact2.Address2);
            Assert.LessOrEqual(contact.UpdatedAt.Value.ToString("g"), contact2.UpdatedAt.Value.ToString("g"));
        }

        [Test]
        public async Task Contact_Delete_Should_Delete_All_Test_Contacts()
        {
            // arrange
            var contacts = await this.Client.GetContactsAsync();

            var deleteThese = contacts
                                .Where(a => string.IsNullOrWhiteSpace(a.Address1) 
                                                ? false 
                                                : a.Address1.StartsWith(Helper.ContactAddress1Prefix))   
                                 .ToList();
            var deleteCount = deleteThese.Count();
            var remainingCount = contacts.Count() - deleteCount;

            // act 
            foreach (var item in deleteThese)
            {
                await this.Client.DeleteContactAsync(item);
            }

            // assert
            var remaining = await this.Client.GetContactsAsync();

            Assert.AreEqual(remainingCount, remaining.Count());
        }

    }
}
