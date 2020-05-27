using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class GroupSubscrip
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		public Guid GroupId { get; set; }
		public Group Group { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public int Limit { get; set; }
		public string Status { get; set; }

		public static explicit operator GroupSubscrip(GroupSubscripModelView mv)
		{
			return new GroupSubscrip()
			{
				Group = mv.Group,
				FromDate = mv.FromDate,
				GroupId = mv.GroupId,
				Id = mv.Id,
				Limit = mv.Limit,
				Status = mv.Status,
				ToDate = mv.ToDate
			};
		}
	}
}
