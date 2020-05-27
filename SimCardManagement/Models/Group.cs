using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class Group
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("BelongToId")]
		public ApplicationUser BelongTo { get; set; }
		public string BelongToId { get; set; }

		public static explicit operator Group(GroupModelView mv)
		{
			return new Group()
			{
				Id = mv.Id,
				Name = mv.Name,
				BelongTo = mv.BelongTo,
				BelongToId = mv.BelongToId,
			};
		}
	}
}
