using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class ChangePasswordModelView
	{
		[Required(ErrorMessage ="هذا ألحقل مطلوب")]
		[DataType(DataType.Password)]
		[Display(Name = "ألرقم ألسري ألقديم")]
		public string CurrentPassword { get; set; }
		[Required(ErrorMessage = "هذا ألحقل مطلوب")]
		[DataType(DataType.Password)]
		[Display(Name = "ألرقم ألسري ألجديد")]
		public string NewPassword { get; set; }
		[Required(ErrorMessage = "هذا ألحقل مطلوب")]
		[DataType(DataType.Password)]
		[Display(Name = "تأكيد ألرقم ألسري ألجديد")]
		[Compare("NewPassword" ,ErrorMessage ="ألرقم ألسري غير متطابق")]
		public string ConfirmPassword { get; set; }
	}
}
