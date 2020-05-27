using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class CDR_DateModelView
	{
		public Guid Id { get; set; }
		[ForeignKey("CDR_ID")]
		public Guid CDR_ID { get; set; }
		public CDR CDR { get; set; }
		public string Date { get; set; }
		public double Ammount { get; set; }

		public static explicit operator CDR_DateModelView(CDR_Date model)
		{
			return new CDR_DateModelView()
			{
				Ammount = model.Ammount,
				CDR = model.CDR,
				CDR_ID = model.CDR_ID,
				Date = model.Date,
				Id = model.Id
			};
		}

	}
}
