using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class DeviceModelView
	{
		public Guid Id { get; set; }
		[Required]
		[Display(Name="الأسم ألرباعي/ألجهة ألمستفيدة")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "أللقب")]
		public string Clan { get; set; }
		[Required]
		[Display(Name = "ألتولد")]
		public DateTime Birthdate { get; set; }
		[Required]
		[Display(Name = "محل ألولادة")]
		public string City { get; set; }
		[Required]
		[Display(Name = "عنوان السكن")]
		public string Address { get; set; }
		[Required]
		[Display(Name = "اقرب نقطة دالة")]
		public string NearPoint { get; set; }
		[Required]
		[Display(Name = "الهاتف الأول")]
		public string Phone1 { get; set; }
		[Required]
		[Display(Name = " الهاتف الثاني")]
		public string Phone2 { get; set; }
		[Required]
		[Display(Name = " ألعمل")]
		public string Work { get; set; }
		[Required]
		[Display(Name = "رقم ألهوية/ألبطافة ألموحدة")]
		public string IdCardNumber { get; set; }
		[Required]
		[Display(Name = "ألبريد الألكتروني")]
		public string Email { get; set; }
		[Required]
		[Display(Name = "إسم ألجهاز")]
		public string DeviceName { get; set; }
		[Required]
		[Display(Name = "نوع الأستخدام")]
		public string UsageType { get; set; }
		[Required]
		[Display(Name = "ألرقم ألتسلسلي")]
		public string IMEI { get; set; }
		[ForeignKey("SimCardId")]
		[Required]
		[Display(Name = "ألشريحة")]
		public Guid SimCardId { get; set; }
		public SimCard SimCard { get; set; }
		[Required]
		[Display(Name = "نوع ألعجلة")]
		public string CarType { get; set; }
		[Required]
		[Display(Name = "لون ألعجلة")]
		public string CarColor { get; set; }
		[Required]
		[Display(Name = "رقم ألعجلة")]
		public string CarNumber { get; set; }
		[Required]
		[Display(Name = "موديل ألعجلة")]
		public string Model { get; set; }
		[Required]
		[Display(Name = "رقم ألسنوية")]
		public string SanaweiaNumber { get; set; }
		[Required]
		[Display(Name = "رقم ألشاصي")]
		public string Vin { get; set; }


		public static explicit operator DeviceModelView(Device model)
		{
			return new DeviceModelView()
			{
				SimCard = model.SimCard,
				Address = model.Address,
				Birthdate = model.Birthdate,
				CarColor = model.CarColor,
				CarNumber = model.CarNumber,
				CarType = model.CarType,
				City = model.City,
				Clan = model.Clan,
				DeviceName = model.DeviceName,
				Email = model.Email,
				Id = model.Id,
				IdCardNumber = model.IdCardNumber,
				IMEI = model.IMEI,
				Model = model.Model,
				Name = model.Name,
				NearPoint = model.NearPoint,
				Phone1 = model.Phone1,
				Phone2 = model.Phone2,
				SanaweiaNumber = model.SanaweiaNumber,
				SimCardId = model.SimCardId,
				UsageType = model.UsageType,
				Vin = model.Vin,
				Work = model.Work
			};
		}

	}
}
