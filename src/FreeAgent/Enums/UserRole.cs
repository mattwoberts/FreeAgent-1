using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public enum UserRole
    {
        [EnumMember(Value = "Director")] Director,
        [EnumMember(Value = "Accountant")] Accountant,
        [EnumMember(Value = "Company Secretary")] CompanySecretary,
        [EnumMember(Value = "Employee")] Employee,
        [EnumMember(Value = "Shareholder")] Shareholder
    }
}

