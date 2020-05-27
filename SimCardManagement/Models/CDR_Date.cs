using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class CDR_Date
	{
		public Guid Id { get; set; }
		[ForeignKey("CDR_ID")]
		public Guid CDR_ID { get; set; }
		public CDR CDR { get; set; }
		public string Date { get; set; }
		public double Ammount { get; set; }

		public static explicit operator CDR_Date(CDR_DateModelView mv)
		{
			return new CDR_Date()
			{
				Ammount = mv.Ammount,
				CDR = mv.CDR,
				CDR_ID = mv.CDR_ID,
				Date = mv.Date,
				Id = mv.Id
			};
		}

	}
}
