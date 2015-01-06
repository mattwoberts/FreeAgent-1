using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public class BankAccount : IUrl
	{
        public Uri Url { get; set; }
		public double OpeningBalance { get; set; }
		public BankAccountType Type { get; set; }
		public string Name { get; set; }
		public bool IsPersonal { get; set; }
		public string BankName { get; set; }
		public string Currency { get; set; }
        public string AccountNumber { get; set; } 		//for standard ones - account_number also on CC
		public string SortCode { get; set; }
		public string SecondarySortCode { get; set; }
		public string Iban { get; set; }
		public string Bic { get; set; }
        public string Email { get; set; }		//for paypal
		public double CurrentBalance { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}

	public class BankAccountWrapper
	{
		public BankAccount BankAccount { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}



