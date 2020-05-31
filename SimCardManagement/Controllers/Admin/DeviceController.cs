using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimCardManagement.Data;
using SimCardManagement.Models;
using SimCardManagement.ModelView;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace SimCardManagement.Controllers.Admin
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext db;
        public DeviceController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(string filter, int page = 1)
        {
            List<DeviceModelView> list = new List<DeviceModelView>();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                list.Clear();
                db.Device.Where(s=>s.DeviceName.Contains(filter)).Include(s => s.SimCard).ToList().ForEach(x => { list.Add((DeviceModelView)x); });

            }
            else
            {
                db.Device.Include(s => s.SimCard).ToList().ForEach(x => { list.Add((DeviceModelView)x); });
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
            ViewBag.sims = db.SimCard;
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeviceModelView mv)
        {
            if (ModelState.IsValid)
            {
                db.Device.Add((Device)mv);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.alertMsg = "تمت ألعملية بنجاح";
            }
            ViewBag.sims = db.SimCard;
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                ViewBag.sims = db.SimCard;
                return View((DeviceModelView)db.Device.Include(s=>s.SimCard).SingleOrDefault(s=>s.Id.Equals(id)));
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(DeviceModelView mv)
        {
            if (ModelState.IsValid)
            {
                db.Device.Update((Device)mv);
                db.SaveChanges();
                ViewBag.alertMsg = "تمت ألعملية بنجاح";
            }
            ViewBag.sims = db.SimCard;
            return View();
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id != Guid.Empty)
            {
                return View((DeviceModelView)db.Device.Include(s => s.SimCard).SingleOrDefault(s => s.Id.Equals(id)));
            }
            return View();
        }
        public void Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                db.Device.Remove(db.Device.Find(id));
                db.SaveChanges();
            }
        }

    }
}