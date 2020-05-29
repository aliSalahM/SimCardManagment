using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class Device
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Clan { get; set; }
		public DateTime Birthdate { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public string NearPoint { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string Work { get; set; }
		public string IdCardNumber { get; set; }
		public string Email { get; set; }
		public string DeviceName { get; set; }
		public string UsageType { get; set; }
		public string IMEI { get; set; }
		[ForeignKey("SimCardId")]
		public Guid SimCardId { get; set; }
		public SimCard SimCard { get; set; }
		public string CarType { get; set; }
		public string CarColor { get; set; }
		public string CarNumber { get; set; }
		public string Model { get; set; }
		public string SanaweiaNumber { get; set; }
		public string Vin { get; set; }


		public static explicit operator Device(DeviceModelView mv)
		{
			return new Device()
			{
				SimCard = mv.SimCard,
				Address = mv.Address,
				Birthdate = mv.Birthdate,
				CarColor = mv.CarColor,
				CarNumber = mv.CarNumber,
				CarType = mv.CarType,
				City = mv.City,
				Clan = mv.Clan,
				DeviceName = mv.DeviceName,
				Email = mv.Email,
				Id = mv.Id,
				IdCardNumber = mv.IdCardNumber,
				IMEI = mv.IMEI,
				Model = mv.Model,
				Name = mv.Name,
				NearPoint = mv.NearPoint,
				Phone1 = mv.Phone1,
				Phone2 = mv.Phone2,
				SanaweiaNumber = mv.SanaweiaNumber,
				SimCardId = mv.SimCardId,
				UsageType = mv.UsageType,
				Vin = mv.Vin,
				Work = mv.Work
			};
		}

	}
}
