using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public enum AccountType
	{
		مؤسسة,
		شركة,
		وزارة,
		دائرة,
	}
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string Photo { get; set; }
		public AccountType AccountType { get; set; }
		public string Location { get; set; }
		public string IdCardNumber { get; set; }
		public string WorkPostion { get; set; }

	}
}
