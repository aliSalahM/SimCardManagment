using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ReflectionIT.Mvc.Paging;
using SimCardManagement.Data;
using SimCardManagement.Models;
using SimCardManagement.ModelView;

namespace SimCardManagement.Controllers.Admin
{
	public class SimCardController : Controller
	{
		private readonly ApplicationDbContext db;
		private readonly IHostingEnvironment _hostingEnvironment;

		public SimCardController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
		{
			this.db = db;
			_hostingEnvironment = hostingEnvironment;
		}
		public IActionResult Index(string filter, int page = 1)
		{
			List<SimCardModelView> list = new List<SimCardModelView>();
			db.SimCard.ToList().ForEach(x => { list.Add((SimCardModelView)x); });

			if (!string.IsNullOrWhiteSpace(filter))
			{
				list.Clear();
				db.SimCard.Where(s => s.SimCardNumber.Contains(filter)).ToList().ForEach(x => { list.Add((SimCardModelView)x); });
			}
			var model = PagingList.Create(list, 10, page);
			model.RouteValue = new RouteValueDictionary {
				{ "filter", filter}
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(SimCardModelView mv)
		{
			if (ModelState.IsValid)
			{
				db.SimCard.Add((SimCard)mv);
				db.SaveChanges();
				ModelState.Clear();
				ViewBag.alertMsg = "تمت ألعملية بنجاح";
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddSimsCard()
		{
			return View();
		}
		public IActionResult Import()
		{
			IFormFile file = Request.Form.Files[0];
			string folderName = "UploadExcel";
			string webRootPath = _hostingEnvironment.WebRootPath;
			string newPath = Path.Combine(webRootPath, folderName);
			StringBuilder sb = new StringBuilder();
			if (!Directory.Exists(newPath))
			{
				Directory.CreateDirectory(newPath);
			}
			if (file.Length > 0)
			{
				string sFileExtension = Path.GetExtension(file.FileName).ToLower();
				ISheet sheet;
				string fullPath = Path.Combine(newPath, file.FileName);
				using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					file.CopyTo(stream);
					stream.Position = 0;
					if (sFileExtension == ".xls")
					{
						HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
						sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
					}
					else
					{
						XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
						sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
					}
					IRow headerRow = sheet.GetRow(0); //Get Header Row
					int cellCount = headerRow.LastCellNum;

					for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
					{
						IRow row = sheet.GetRow(i);
						if (row == null) continue;
						if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;


						if (!db.SimCard.Any(s => s.SimCardNumber.Equals(row.GetCell(1).ToString())))
						{
							SimCard sim = new SimCard();
							sim.SimCardNumber = row.GetCell(1).ToString();
							sim.ACCT_CODE = row.GetCell(2).ToString();
							db.SimCard.Add(sim);
							db.SaveChanges();
						}


					}
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult Details(Guid id)
		{
			return View((SimCardModelView)db.SimCard.Find(id));
		}
		public void Delete(Guid id)
		{
			db.SimCard.Remove(db.SimCard.Find(id));
			db.SaveChanges();
		}
		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			return View((SimCardModelView)db.SimCard.Find(id));
		}
		[HttpPost]
		public IActionResult Edit(SimCardModelView mv)
		{
			if (ModelState.IsValid)
			{
				db.SimCard.Update((SimCard)mv);
				db.SaveChanges();
				ViewBag.alertMsg = "تمت ألعملية بنجاح";
			}
			return View((SimCardModelView)db.SimCard.Find(mv.Id));
		}
	}
}