using SimCardManagement.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.Models
{
	public class GroupSimCards
	{
		public Guid Id { get; set; }
		[ForeignKey("GroupId")]
		public Guid GroupId { get; set; }
		public Group Group { get; set; }
		[ForeignKey("SimCardId")]
		public Guid SimCardId { get; set; }
		public SimCard SimCard { get; set; }


		public static explicit operator GroupSimCards(GroupSimCardsModelView mv)
		{
			return new GroupSimCards()
			{
				Id = mv.Id,
				Group = mv.Group,
				GroupId = mv.GroupId,
				SimCard = mv.SimCard,
				SimCardId=mv.SimCardId
			};
		}





	}
}
