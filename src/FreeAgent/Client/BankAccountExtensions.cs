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
            var filter = viewFilter ?? BankAccountViewFilter.All();

            var result = await client.Execute(c =>
            {
                return c.BankAccountList(client.Configuration.CurrentHeader, filter.FilterValue);
            });

            return result.BankAccounts;
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);

            var result = await client.Execute(c =>
            {
                return c.BankAccount(client.Configuration.CurrentHeader, id);
            });

            return result.BankAccount;
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, int accountId)
        {
            var result = await client.Execute(c =>
            {
                return c.BankAccount(client.Configuration.CurrentHeader, accountId);
            });

            return result.BankAccount;
        }

        public static async Task<BankAccount> CreateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            //TODO - safety stuff here...
            var result = await client.Execute(c =>
            {
                return c.CreateBankAccount(client.Configuration.CurrentHeader, account.Wrap());
            });

            return result.BankAccount;
        }

        public static async Task<bool> DeleteBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var id = client.ExtractId(account);

            await client.Execute(c =>
            {
                //TODO - safety stuff here??
                return c.DeleteBankAccount(client.Configuration.CurrentHeader, id);
            });

            return true;
        }

        internal static BankAccountWrapper Wrap(this BankAccount account)
        {
            return new BankAccountWrapper { BankAccount = account };
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
