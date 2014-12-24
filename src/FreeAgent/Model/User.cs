using System;
using System.Collections.Generic;

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
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}

    public class UserWrapper
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}

