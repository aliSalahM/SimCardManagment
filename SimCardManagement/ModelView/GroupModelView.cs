using Microsoft.AspNetCore.Mvc;
using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class GroupModelView
	{
		public Guid Id { get; set; }
		[Required]
		[Display(Name="إسم ألمجموعة")]
		[Remote(action: "IsNameInUse",controller:"Group",AdditionalFields = "Id")]
		public string Name { get; set; }
		
		[ForeignKey("BelongToId")]
		public ApplicationUser BelongTo { get; set; }
		[Display(Name = "ينتمي ألى")]
		public string BelongToId { get; set; }

		public static explicit operator GroupModelView(Group model)
		{
			return new GroupModelView()
			{
				Id = model.Id,
				Name = model.Name,
				BelongTo = model.BelongTo,
				BelongToId = model.BelongToId,
			};
		}

	}
}
