using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimCardManagement.Models;

namespace SimCardManagement.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<ApplicationUser> User { get; set; }
		public DbSet<SimCard> SimCard { get; set; }
		public DbSet<Group> Group { get; set; }
		public DbSet<GroupSimCards> GroupSimCards { get; set; }
		public DbSet<ReportCDR> ReportCDR { get; set; }
		public DbSet<CDR> CDR { get; set; }
		public DbSet<CDR_Date> CDR_Date { get; set; }
		public DbSet<GroupSubscrip> GroupSubscrip { get; set; }


	}
}
