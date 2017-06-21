using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class BankAccountTests : TestFixtureBase
    {
        [Test]
        public async Task BankAccount_GetAll_Should_Return_List()
        {
            var accounts = await this.Client.GetBankAccountsAsync();

            Assert.IsNotNull(accounts);
        }

        [Test]
        public async Task BankAccount_Create_Will_Return_Url_And_Dates()
        {
            // arrange
            var source = Helper.NewStandardBankAccount();

            // act
            var result = await this.Client.CreateBankAccountAsync(source);

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.AreEqual(source.OpeningBalance, result.OpeningBalance);
            Assert.AreEqual(source.Type, result.Type);
            Assert.AreEqual(source.Name, result.Name);
            Assert.AreEqual(source.BankName, result.BankName);
            Assert.IsNotNull(result.CreatedAt);
            Assert.IsNotNull(result.UpdatedAt);
        }

        [Test]
        public void BankAccount_Get_Single_With_No_Url_Should_Throw()
        {
            // arrange
            var source = Helper.NewStandardBankAccount();

            // act
            var exResult = Helper.RecordException(() => this.Client.GetBankAccountAsync(source.Url));

            // assert
            Assert.IsInstanceOf<FreeAgentException>(exResult);
            Assert.AreEqual("Cannot extract ID from blank Url", exResult.Message);
        }


        [Test]
        public async Task BankAccount_Get_Single_Should_Return_Account()
        {
            // arrange
            // - create a new account to retrieve
            var source = Helper.NewStandardBankAccount();
            var account = await this.Client.CreateBankAccountAsync(source);

            Assert.IsNotNull(account.Url);

            // act
            // - get the one just created by number
            var result = await this.Client.GetBankAccountAsync(account.Url);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(account.Url, result.Url);
            Assert.AreEqual(account.CreatedAt.GetValueOrDefault(DateTime.MinValue).Date, result.CreatedAt.GetValueOrDefault(DateTime.MinValue).Date);

        }

        [Test]
        public async Task BankAccount_Update_Should_Store_Updated_Details()
        {
            // arrange
            var source = Helper.NewStandardBankAccount();
            var account = await this.Client.CreateBankAccountAsync(source);

            Assert.IsNotNull(account.Url);

            // act - update the one just created
            account.BankName = "*UPDATED*";
            await this.Client.UpdateBankAccountAsync(account);

            // assert
            var account2 = await this.Client.GetBankAccountAsync(account);

            Assert.AreEqual(account.Url, account2.Url);
            Assert.AreEqual(account.CreatedAt.GetValueOrDefault(DateTime.MinValue).Date, account2.CreatedAt.GetValueOrDefault(DateTime.MinValue).Date);
            Assert.AreEqual(account.BankName, account2.BankName);
            Assert.LessOrEqual(account.UpdatedAt, account2.UpdatedAt);
        }
        [Test]
        public async Task BankAccount_Delete_Should_Remove_All_Test_Accounts()
        {
            // arrange
            var accounts = await this.Client.GetBankAccountsAsync();

            var deleteThese = accounts.Where(a => a.Name.StartsWith(Helper.AccountNamePrefix)).ToList();
            var deleteCount = deleteThese.Count();
            var remainingCount = accounts.Count() - deleteCount;

            // act 
            foreach (var item in deleteThese)
            {
                await this.Client.DeleteBankAccountAsync(item);
            }

            // assert
            var remaining = await this.Client.GetBankAccountsAsync();

            Assert.AreEqual(remainingCount, remaining.Count());
        }

        [Test]
        public async Task BankAccount_Should_Only_Be_One_Primary_Account()
        {
            // arrange
            var accounts = await this.Client.GetBankAccountsAsync();

            // act 
            var primaryAccounts = accounts.Count(a => a.IsPrimary);

            // assert
            Assert.IsTrue(primaryAccounts <= 1);
        }

        [Test]
        public async Task BankAccount_Shouldnt_Be_Able_To_Delete_Primary_Account()
        {
            // arrange
            var accounts = await this.Client.GetBankAccountsAsync();
            var item = accounts.FirstOrDefault(a => a.IsPrimary);

            // act - but only if we got a primary account 
            if (item != null)
            {
                var exResult = Helper.RecordException(() => this.Client.DeleteBankAccountAsync(item));
 
                // assert - but only if we had a primary account
                // - we should have the same number of accounts
                // - we should have got an exception saying 209 conflict.
                var remaining = await this.Client.GetBankAccountsAsync();

                Assert.AreEqual(accounts.Count(), remaining.Count());

                Assert.IsInstanceOf<FreeAgentException>(exResult);

                var freeAgentException = exResult as FreeAgentException;
                Assert.IsNotNull(freeAgentException);
                Assert.IsNotNull(freeAgentException.InnerException);
                Assert.IsInstanceOf<Refit.ApiException>(freeAgentException.InnerException); //TODO - surface this info 

                var refitException = freeAgentException.InnerException as Refit.ApiException;
                Assert.AreEqual(System.Net.HttpStatusCode.Conflict, refitException.StatusCode);
            }
        }

    }
}
