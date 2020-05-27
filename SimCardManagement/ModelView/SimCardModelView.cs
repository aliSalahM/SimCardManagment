using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class SimCardModelView
	{
		public Guid Id { get; set; }
		[Display(Name ="ألرمز")]
		public string Code { get; set; }
		[Display(Name = "رقم ألشريحة")]
		public string SimCardNumber { get; set; }
		[Display(Name = "ألرقم ألتسلسلي")]
		public string IMEI { get; set; }
		[Display(Name = "ألشريحة IP")]
		public string SimIP { get; set; }
		[Display(Name = "نوع ألشريحة")]
		public string SimType { get; set; }
		[Display(Name = "ألخادم")]
		public string Server { get; set; }
		[Display(Name = "ألخادم IP")]
		public string ServerIp { get; set; }
		[Display(Name = "موقع ألخادم")]
		public string ServerLocation { get; set; }
		[Display(Name = "رابط ألخادم")]
		public string ServerLink { get; set; }
		[Display(Name = "نظام تشغيل ألخادم")]
		public string ServerOS { get; set; }
		[Display(Name = "إسم ألجهاز")]
		public string DevaiceName { get; set; }
		[Display(Name = "نوع ألجهاز")]
		public string DeviceType { get; set; }
		[Display(Name = "موديل ألجهاز")]
		public string DeviceModal { get; set; }
		[Display(Name = "موقع ألجهاز")]
		public string DeviceLocation { get; set; }
		[Display(Name = "ألرقم ألتسلسلي للجهاز")]
		public string DeviceIMEI { get; set; }
		[Display(Name = "رقم ألعقد")]
		public string ACCT_CODE { get; set; }


		public static explicit operator SimCardModelView(SimCard model)
		{
			return new SimCardModelView()
			{
				Id = model.Id,
				Code = model.Code,
				SimCardNumber = model.SimCardNumber,
				IMEI = model.IMEI,
				SimIP = model.SimIP,
				SimType = model.SimType,
				Server = model.Server,
				ServerIp = model.ServerIp,
				ServerLocation = model.ServerLocation,
				ServerLink = model.ServerLink,
				ServerOS = model.ServerOS,
				DevaiceName = model.DevaiceName,
				DeviceType = model.DeviceType,
				DeviceModal = model.DeviceModal,
				DeviceLocation = model.DeviceLocation,
				DeviceIMEI = model.DeviceIMEI,
				ACCT_CODE = model.ACCT_CODE
			};
		}

	}
}
