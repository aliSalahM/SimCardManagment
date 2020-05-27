using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class GroupSubscripModelView
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		[Display(Name="إسم ألمجموعة")]
		public Guid GroupId { get; set; }
		public Group Group { get; set; }
		[Display(Name = "من تاريخ")]
		public DateTime FromDate { get; set; }
		[Display(Name = "ألى تاريخ")]
		public DateTime ToDate { get; set; }
		[Display(Name = "ألسعة")]
		public int Limit { get; set; }
		[Display(Name = "ألحالة")]
		public string Status { get; set; }

		public static explicit operator GroupSubscripModelView(GroupSubscrip model)
		{
			return new GroupSubscripModelView()
			{
				Group = model.Group,
				FromDate = model.FromDate,
				GroupId = model.GroupId,
				Id = model.Id,
				Limit = model.Limit,
				Status = model.Status,
				ToDate = model.ToDate
			};
		}

	}
}
