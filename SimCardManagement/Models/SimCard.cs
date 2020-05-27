using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class SimCard
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string SimCardNumber { get; set; }
		public string IMEI { get; set; }
		public string SimIP { get; set; }
		public string SimType { get; set; }
		public string Server { get; set; }
		public string ServerIp { get; set; }
		public string ServerLocation { get; set; }
		public string ServerLink { get; set; }
		public string ServerOS { get; set; }
		public string DevaiceName { get; set; }
		public string DeviceType { get; set; }
		public string DeviceModal { get; set; }
		public string DeviceLocation { get; set; }
		public string DeviceIMEI { get; set; }
		public string ACCT_CODE { get; set; }


		public static explicit operator SimCard(SimCardModelView mv)
		{
			return new SimCard()
			{
				Id = mv.Id,
				Code = mv.Code,
				SimCardNumber = mv.SimCardNumber,
				IMEI = mv.IMEI,
				SimIP = mv.SimIP,
				SimType = mv.SimType,
				Server = mv.Server,
				ServerIp = mv.ServerIp,
				ServerLocation = mv.ServerLocation,
				ServerLink = mv.ServerLink,
				ServerOS = mv.ServerOS,
				DevaiceName = mv.DevaiceName,
				DeviceType = mv.DeviceType,
				DeviceModal = mv.DeviceModal,
				DeviceLocation = mv.DeviceLocation,
				DeviceIMEI = mv.DeviceIMEI,
				ACCT_CODE = mv.ACCT_CODE
			};
		}
	}
}
