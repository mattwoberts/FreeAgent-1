using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
    public class User : IUrl
	{
        public Uri Url { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public UserRole Role { get; set; }
		public UserPermission PermissionLevel { get; set; }
		public double OpeningMileage { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
	}

	public enum UserPermission 
	{
		NoAccess = 0,
		Time = 1,
		MyMoney = 2,
		ContactsAndProjects = 3,
		InvoicesEstimatesAndFiles = 4,
		Bills = 5,
		Banking = 6,
		TaxAccountingAndUsers = 7,
		Full = 8
	}

    public enum UserRole
    {
        [EnumMember(Value = "Director")] Director,
        [EnumMember(Value = "Accountant")] Accountant,
        [EnumMember(Value = "Company Secretary")] CompanySecretary,
        [EnumMember(Value = "Employee")] Employee,
        [EnumMember(Value = "Shareholder")] Shareholder
    }

    public class UserWrapper
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}

