using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class CDRDateModelView
	{
		public CDRDateModelView()
		{
			Date = new List<DateInfo>();
		}
		public Guid Id { get; set; }
		[Display(Name ="رقم ألشريحة")]
		public string SimCardNumber { get; set; }
		[Display(Name = "ألتفاصيل")]
		public List<DateInfo> Date { get; set; }
		[Display(Name = "ألصرف ألكلي")]
		public double TotlalAmmount { get; set; }


		public class DateInfo
		{
			public string Date { get; set; }
			public double Ammount { get; set; }
		}

	}
}
