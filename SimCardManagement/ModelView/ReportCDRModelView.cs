using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class ReportCDRModelView
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		public Group Group { get; set; }
		[Display(Name ="ألمجموعة")]
		public Guid GroupId { get; set; }
		[Display(Name = "ألتاريخ")]
		public DateTime Date { get; set; }
		[Display(Name = "ألكمية")]
		public double Amount { get; set; }

		public string CONTRNO { get; set; }
		public int ActiveUsed { get; set; }
		public int ActiveNotUsed { get; set; }
		public string SuspendUsed { get; set; }
		public string SuspendNotUsed { get; set; }
		public string DeactiveUsed { get; set; }
		public string DeactiveNotUsed { get; set; }
		public string MSISDN_TOTAL { get; set; }
		public string Data_Usage_KB { get; set; }
		public string Data_Usage_MB { get; set; }
		public string Data_Usage_GB { get; set; }
		public string Remaining_Quota_KB { get; set; }
		public string Remaining_Quota_MB { get; set; }
		public string Remaining_Quota_GB { get; set; }

		public static explicit operator ReportCDRModelView(ReportCDR model)
		{
			return new ReportCDRModelView()
			{
				Id = model.Id,
				Date = model.Date,
				Amount = model.Amount,
				Group = model.Group,
				GroupId = model.GroupId,
				ActiveNotUsed = model.ActiveNotUsed,
				ActiveUsed = model.ActiveUsed,
				CONTRNO = model.CONTRNO,
				Data_Usage_GB = model.Data_Usage_GB,
				Data_Usage_KB = model.Data_Usage_KB,
				Data_Usage_MB = model.Data_Usage_MB,
				DeactiveNotUsed = model.DeactiveNotUsed,
				DeactiveUsed = model.DeactiveUsed,
				MSISDN_TOTAL = model.MSISDN_TOTAL,
				Remaining_Quota_GB = model.Remaining_Quota_GB,
				Remaining_Quota_KB = model.Remaining_Quota_KB,
				Remaining_Quota_MB = model.Remaining_Quota_MB,
				SuspendNotUsed = model.SuspendNotUsed,
				SuspendUsed = model.SuspendUsed,
			};
		}

	}
}
