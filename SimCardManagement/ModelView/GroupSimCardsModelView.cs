using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class GroupSimCardsModelView
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		public Guid GroupId { get; set; }
		public Group Group { get; set; }
		[ForeignKey("SimCardId")]
		public Guid SimCardId { get; set; }
		public SimCard SimCard { get; set; }
		public bool Selected { get; set; }


		public static explicit operator GroupSimCardsModelView(GroupSimCards model)
		{
			return new GroupSimCardsModelView()
			{
				Id = model.Id,
				Group = model.Group,
				GroupId = model.GroupId,
				SimCard = model.SimCard,
				SimCardId = model.SimCardId
			};
		}

	}
}
