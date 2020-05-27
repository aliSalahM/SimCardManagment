using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class ReportCDR
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		public Group Group { get; set; }
		public Guid GroupId { get; set; }
		public DateTime Date { get; set; }
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


		public static explicit operator ReportCDR(ReportCDRModelView mv)
		{
			return new ReportCDR()
			{
				Id = mv.Id,
				Date = mv.Date,
				Amount = mv.Amount,
				Group = mv.Group,
				GroupId = mv.GroupId,
				ActiveNotUsed = mv.ActiveNotUsed,
				ActiveUsed = mv.ActiveUsed,
				CONTRNO = mv.CONTRNO,
				Data_Usage_GB = mv.Data_Usage_GB,
				Data_Usage_KB = mv.Data_Usage_KB,
				Data_Usage_MB = mv.Data_Usage_MB,
				DeactiveNotUsed = mv.DeactiveNotUsed,
				DeactiveUsed = mv.DeactiveUsed,
				MSISDN_TOTAL = mv.MSISDN_TOTAL,
				Remaining_Quota_GB = mv.Remaining_Quota_GB,
				Remaining_Quota_KB = mv.Remaining_Quota_KB,
				Remaining_Quota_MB = mv.Remaining_Quota_MB,
				SuspendNotUsed = mv.SuspendNotUsed,
				SuspendUsed = mv.SuspendUsed,

			};
		}
	}
}
