using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class CDRModelView
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

		public static explicit operator CDRModelView(CDR model)
		{
			return new CDRModelView()
			{
				SimCard = model.SimCard,
				CONTRNO = model.CONTRNO,
				Id = model.Id,
				MSISDN = model.MSISDN,
				PREPAID_FLAG = model.PREPAID_FLAG,
				REASON = model.REASON,
				SimCardId = model.SimCardId,
				STATUS = model.STATUS,
				TARIFF_PROFILE = model.TARIFF_PROFILE,
				USAGE_STATE = model.USAGE_STATE
			};
		}

	}
}
