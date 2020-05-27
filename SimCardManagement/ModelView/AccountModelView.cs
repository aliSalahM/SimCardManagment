using Microsoft.AspNetCore.Http;
using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimCardManagement.ModelView
{
	public class AccountModelView
	{
        [DataType(DataType.Password), Display(Name = "تأكيد ألرقم ألسري"), Compare("Password", ErrorMessage = "ألرقم ألسري غير متطابق")]
        public string ConfirmPassword { get; set; }

        [Required, EmailAddress, Display(Name = "ألبريد الألكتروني")]
        public string Email { get; set; }

        [Required, Display(Name = "إسم ألمستخدم")]
        public string Name { get; set; }
        [Display(Name = "ألصورة")]
        public IFormFile Photo { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "ألرقم ألسري")]
        public string Password { get; set; }

        [Display(Name = "ألصلاحية")]
        public string Role { get; set; }
        [Display(Name = "نوع ألحساب")]
        public AccountType AccountType { get; set; }
        [Display(Name = "ألموقع")]
        public string Location { get; set; }
        [Display(Name = "رقم ألهوية")]
        public string IdCardNumber { get; set; }
        [Display(Name = "مكان ألعمل")]
        public string WorkPostion { get; set; }
        [Display(Name = "رقم ألهاتف")]
        public string PhoneNumber { get; set; }

    }
}
