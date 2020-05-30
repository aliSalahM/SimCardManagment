using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;
using SimCardManagement.Data;
using SimCardManagement.Models;

namespace SimCardManagement.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext db;

		public HomeController(ApplicationDbContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy(int page = 1)
		{
			var query = db.SimCard;
			var model = PagingList.Create(query, 10, page);
			model.Action = "Privacy";
			return View(model);
		}

		
	}
}
