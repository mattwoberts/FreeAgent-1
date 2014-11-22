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
        public async Task GetContacts()
        {
            var contacts = await this.Client.GetContactsAsync();

            Assert.IsNotNull(contacts);
            CollectionAssert.IsNotEmpty(contacts);
        }

        [Test]
        public async Task CreateContact()
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
        public void GetSingleContactWithNoUrlShouldThrow()
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
        public async Task GetSingleContactShouldReturnAccount()
        {
            // arrange
            var source = Helper.NewContact();
            var contact = await this.Client.CreateContactAsync(source);

            Assert.IsNotNull(contact.Url);

            // act - get the one just created by number
            var result = await this.Client.GetContactAsync(contact.Url);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(contact.Url, result.Url);
            Assert.AreEqual(contact.CreatedAt, result.CreatedAt);
        }

        [Test]
        public async Task ShouldDeleteAllTestAccounts()
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
