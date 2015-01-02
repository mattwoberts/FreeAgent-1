using FreeAgent.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using System;
using System.Runtime.Serialization;

namespace FreeAgent
{
    public static class BankAccountExtensions
    {
        public static async Task<List<BankAccount>> GetBankAccountsAsync(this FreeAgentClient client, BankAccountFilter filterBy = BankAccountFilter.All)
        {
            var view = filterBy.GetMemberValue();

            var result = await client.Execute(c => c.BankAccountList(client.Configuration.CurrentHeader, view));
            return result.BankAccounts;
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var id = client.ExtractId(account);
            return await client.GetBankAccountAsync(id);
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return await client.GetBankAccountAsync(id);
        }

        public static async Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, int accountId)
        {
            var result = await client.Execute(c => c.BankAccount(client.Configuration.CurrentHeader, accountId));
            return result.BankAccount;
        }

        public static async Task<BankAccount> CreateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            //TODO - safety stuff here...
            var result = await client.Execute(c => c.CreateBankAccount(client.Configuration.CurrentHeader, account.Wrap()));
            return result.BankAccount;
        }

        public static async Task<bool> UpdateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var id = client.ExtractId(account);

            await client.Execute(c => c.UpdateBankAccount(client.Configuration.CurrentHeader, id, account.Wrap()));
            return true;
        }

        public static async Task<bool> DeleteBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var id = client.ExtractId(account);

            //TODO - safety stuff here??
            await client.Execute(c => c.DeleteBankAccount(client.Configuration.CurrentHeader, id));
            return true;
        }

        internal static BankAccountWrapper Wrap(this BankAccount account)
        {
            return new BankAccountWrapper { BankAccount = account };
        }
    }

    public enum BankAccountFilter
    {
        [EnumMember(Value = null)] All,
        [EnumMember(Value = "standard_bank_accounts")] StandardBankAccounts,
        [EnumMember(Value = "credit_card_accounts")] CreditCardAccounts,
        [EnumMember(Value = "paypal_accounts")] PayPalAccounts
    }
}
