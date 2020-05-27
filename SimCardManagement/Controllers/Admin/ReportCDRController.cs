using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimCardManagement.Data;
using SimCardManagement.Models;
using SimCardManagement.ModelView;

namespace SimCardManagement.Controllers.Admin
{
    public class ReportCDRController : Controller
    {
        private readonly ApplicationDbContext db;

        public ReportCDRController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Guid id)
        {
            if (id != Guid.Empty)
            {
                ViewBag.groupId = id;
                List<ReportCDRModelView> list = new List<ReportCDRModelView>();
                db.ReportCDR.Include(s => s.Group).Where(s => s.GroupId.Equals(id)).ToList().ForEach(x => { list.Add((ReportCDRModelView)x); });
                return View(list);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReportCDRModelView mv,Guid id)
        {
            if (ModelState.IsValid)
            {
                mv.GroupId = id;
                mv.Group = db.Group.Find(id);
                //ReportCDR cdr = new ReportCDR();
                //cdr.Date = mv.Date;
                //cdr.Amount = mv.Amount;
                //cdr.GroupId = id;
                //cdr.Group = db.Group.Find(id);
                db.ReportCDR.Add((ReportCDR)mv);
                db.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = id });
            }
            
            return View();
        }




    }
}