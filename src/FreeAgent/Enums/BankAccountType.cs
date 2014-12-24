using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum BankAccountType
    {
        [EnumMember(Value = "StandardBankAccount")] StandardBankAccount,
        [EnumMember(Value = "PaypalAccount")] PaypalAccount,
        [EnumMember(Value = "CreditCardAccount")] CreditCardAccount
    }
}



