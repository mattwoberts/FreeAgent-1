using FreeAgent.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using System;

namespace FreeAgent
{
    public static class BankAccountExtensions
    {
        public static async Task<List<BankAccount>> GetBankAccountsAsync(this FreeAgentClient client, BankAccountViewFilter viewFilter = null)
        {
            var result = await client.Execute(async c =>
            {
                var filter = viewFilter ?? BankAccountViewFilter.All();

                return await c.BankAccountList(client.Configuration.CurrentHeader, filter.FilterValue);
            });

            return result.BankAccounts;
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, Uri url)
        {
            var result = await client.Execute(async c =>
            {
                var id = client.ExtractId(url);
                return await client.Client.BankAccount(client.Configuration.CurrentHeader, id);
            });

            return result.BankAccount;
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, int accountId)
        {
            var result = await client.Execute(async c =>
            {
                return await client.Client.BankAccount(client.Configuration.CurrentHeader, accountId);
            });

            return result.BankAccount;
        }

        public static async Task<BankAccount> CreateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            //TODO - safety stuff here...
            var result = await client.Execute(async c =>
            {
                var source = new BankAccountWrapper { BankAccount = account };

                return await client.Client.CreateBankAccount(client.Configuration.CurrentHeader, source);
            });

            return result.BankAccount;
        }

        public static async Task<bool> DeleteBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var result = await client.Execute(async c =>
            {
                //TODO - safety stuff here??

                var id = client.ExtractId(account);

                await client.Client.DeleteBankAccount(client.Configuration.CurrentHeader, id);
                return true;
            });

            return true;
        }
    }

    public class BankAccountViewFilter
    {
        internal string FilterValue { get; set; }

        // show all bank accounts 
        public static BankAccountViewFilter All()
        {
            return new BankAccountViewFilter { FilterValue = null };
        }

        // show only standard accounts 
        public static BankAccountViewFilter StandardBankAccounts()
        {
            return new BankAccountViewFilter { FilterValue = "standard_bank_accounts" };
        }

        // Show only credit card accounts
        public static BankAccountViewFilter CreditCardAccounts()
        {
            return new BankAccountViewFilter { FilterValue = "credit_card_accounts" };
        }

        // Show only paypal accounts.
        public static ProjectViewFilter PayPalAccounts()
        {
            return new ProjectViewFilter { FilterValue = "paypal_accounts" };
        }
    }

}
