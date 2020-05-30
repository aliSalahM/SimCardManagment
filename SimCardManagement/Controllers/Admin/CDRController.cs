using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SimCardManagement.Data;
using SimCardManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace SimCardManagement.Controllers.Admin
{
	public class CDRController : Controller
	{
		private readonly ApplicationDbContext db;
		private readonly IHostingEnvironment _hostingEnvironment;

		public CDRController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
		{
			this.db = db;
			_hostingEnvironment = hostingEnvironment;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Details(Guid id)
		{
			if (id != Guid.Empty)
			{
				var sims = db.GroupSimCards.Include(s=>s.SimCard).Where(s=>s.GroupId.Equals(id));

			}
			return View();
		}
		public IActionResult AddCDRs()
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

						var item = db.CDR.Where(s => s.MSISDN.Equals(row.GetCell(1).ToString())).Count();

						if (item == 0)
						{
							CDR cdr = new CDR();
							cdr.CONTRNO = row.GetCell(0).ToString();
							cdr.MSISDN = row.GetCell(1).ToString();
							cdr.SimCardId = db.SimCard.SingleOrDefault(s => s.SimCardNumber.Equals(row.GetCell(1).ToString())).Id;
							cdr.SimCard = db.SimCard.SingleOrDefault(s => s.SimCardNumber.Equals(row.GetCell(1).ToString()));
							cdr.PREPAID_FLAG = row.GetCell(3).ToString();
							cdr.STATUS = row.GetCell(4).ToString();
							cdr.REASON = row.GetCell(5).ToString();
							cdr.TARIFF_PROFILE = row.GetCell(6).ToString();
							cdr.USAGE_STATE = row.GetCell(7).ToString();

							db.CDR.Add(cdr);
							db.SaveChanges();

							IRow header = sheet.GetRow(0);
							for (int j = header.FirstCellNum + 8; j < cellCount - 1; j++)
							{
								CDR_Date date = new CDR_Date();
								date.CDR_ID = cdr.Id;
								date.CDR = cdr;

								try
								{
									string[] sdate = header.GetCell(j).DateCellValue.ToShortDateString().Split("/");
									date.Date = sdate[1] + "/" + sdate[0] + "/" + sdate[2];
									//date.Date = header.GetCell(j).DateCellValue.ToShortDateString();
								}
								catch (Exception)
								{

									string[] sdate = header.GetCell(j).ToString().Split("/");
									date.Date = sdate[1] + "/" + sdate[0] + "/" + sdate[2];
								}

								date.Ammount = Convert.ToDouble(row.GetCell(j).ToString());
								db.CDR_Date.Add(date);
								db.SaveChanges();
							}
						}
						else
						{
							var cdr = db.CDR.SingleOrDefault(s => s.MSISDN.Equals(row.GetCell(1).ToString()));
							IRow header = sheet.GetRow(0);
							for (int j = header.FirstCellNum + 8; j < cellCount - 1; j++)
							{
								var x = header.GetCell(j).DateCellValue.ToShortDateString();
								var a = db.CDR_Date.Where(s => s.CDR_ID.Equals(cdr.Id) && s.Date.Equals(x));
								if (a.Count() == 0)
								{
									CDR_Date date = new CDR_Date();
									date.CDR_ID = cdr.Id;
									date.CDR = cdr;

									try
									{
										string[] sdate = header.GetCell(j).DateCellValue.ToShortDateString().Split("/");
										date.Date = sdate[1] + "/" + sdate[0] + "/" + sdate[2];
										//date.Date = header.GetCell(j).DateCellValue.ToShortDateString();
									}
									catch (Exception)
									{

										string[] sdate = header.GetCell(j).ToString().Split("/");
										date.Date = sdate[1] + "/" + sdate[0] + "/" + sdate[2];
									}

									date.Ammount = Convert.ToDouble(row.GetCell(j).ToString());
									db.CDR_Date.Add(date);
									db.SaveChanges();
								}


							}
						}

						
					}
				}
			}
			return View();
		}
	}
}