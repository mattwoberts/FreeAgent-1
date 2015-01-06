using FreeAgent.Helpers;
using FreeAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeAgent
{
    public static class BankAccountExtensions
    {
        public static Task<IEnumerable<BankAccount>> GetBankAccountsAsync(this FreeAgentClient client, BankAccountFilter filterBy = BankAccountFilter.All)
        {
            var view = filterBy.GetMemberValue();

            return client.GetOrCreateAsync(c => c.BankAccountList(client.Configuration.CurrentHeader, view), r => r.BankAccounts); 
        }

        public static Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            var id = client.ExtractId(account);
            return client.GetBankAccountAsync(id);
        }

        public static Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, Uri url)
        {
            var id = client.ExtractId(url);
            return client.GetBankAccountAsync(id);
        }

        public static Task<BankAccount> GetBankAccountAsync(this FreeAgentClient client, int accountId)
        {
            return client.GetOrCreateAsync(c => c.GetBankAccount(client.Configuration.CurrentHeader, accountId), r => r.BankAccount); 
        }

        public static Task<BankAccount> CreateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            return client.GetOrCreateAsync(c => c.CreateBankAccount(client.Configuration.CurrentHeader, account.Wrap()), r => r.BankAccount); 
        }

        public static Task UpdateBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            return client.UpdateOrDeleteAsync(account, (c, id) => c.UpdateBankAccount(client.Configuration.CurrentHeader, id, account.Wrap()));
        }

        public static Task DeleteBankAccountAsync(this FreeAgentClient client, BankAccount account)
        {
            return client.UpdateOrDeleteAsync(account, (c, id) => c.DeleteBankAccount(client.Configuration.CurrentHeader, id));
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
