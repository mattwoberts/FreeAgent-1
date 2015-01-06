using FreeAgent.Model;
using System;

namespace FreeAgent.Tests
{
    public static partial class Helper
    {
        public const string AccountNamePrefix = "Bank Account TEST ";

        public static BankAccount NewStandardBankAccount()
        {
            var source = new BankAccount
            {
                OpeningBalance = 100,
                Type = BankAccountType.StandardBankAccount,
                Name = AccountNamePrefix + Guid.NewGuid().ToString(),
                BankName = "Test Bank"
            };

            return source;
        }
    }
}
