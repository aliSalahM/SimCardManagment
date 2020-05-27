using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class CDR
	{
		public Guid Id { get; set; }
		public string CONTRNO { get; set; }
		public string MSISDN { get; set; }
		[ForeignKey("SimCardId")]
		public Guid SimCardId { get; set; }
		public SimCard SimCard { get; set; }
		public string PREPAID_FLAG { get; set; }
		public string STATUS { get; set; }
		public string REASON { get; set; }
		public string TARIFF_PROFILE { get; set; }
		public string USAGE_STATE { get; set; }

		public static explicit operator CDR(CDRModelView mv)
		{
			return new CDR()
			{
				SimCard = mv.SimCard,
				CONTRNO = mv.CONTRNO,
				Id = mv.Id,
				MSISDN = mv.MSISDN,
				PREPAID_FLAG = mv.PREPAID_FLAG,
				REASON = mv.REASON,
				SimCardId = mv.SimCardId,
				STATUS = mv.STATUS,
				TARIFF_PROFILE = mv.TARIFF_PROFILE,
				USAGE_STATE = mv.USAGE_STATE
			};
		}
	}
}
