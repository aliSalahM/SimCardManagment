using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimCardManagement.Data;
using SimCardManagement.Models;
using SimCardManagement.ModelView;
using Microsoft.EntityFrameworkCore;
using static SimCardManagement.ModelView.CDRDateModelView;

namespace SimCardManagement.Controllers.Admin
{
    public class GroupSubscripController : Controller
    {
        private readonly ApplicationDbContext db;
        public GroupSubscripController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(Guid GroupId)
        {
            ViewBag.groupId = GroupId;
            List<GroupSubscripModelView> list = new List<GroupSubscripModelView>();

            var currentDate = DateTime.Now;
            foreach (var item in db.GroupSubscrip.Where(s => s.GroupId.Equals(GroupId)))
            {
                if (item.FromDate <= currentDate && item.ToDate >= currentDate)
                {
                    item.Status = "فعال";
                    list.Add((GroupSubscripModelView)item);
                }
                else
                {
                    item.Status = "غير فعال";
                    list.Add((GroupSubscripModelView)item);
                }
            }
            db.SaveChanges();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create(Guid GroupId)
        {
            ViewBag.groupId = GroupId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupSubscripModelView mv)
        {
            if (ModelState.IsValid)
            {
                db.GroupSubscrip.Add((GroupSubscrip)mv);
                db.SaveChanges();
                return RedirectToAction(nameof(Index),new { GroupId = mv.GroupId});
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetSubscripDetails(Guid SubscribId , Guid GroupId)
        {
            List<CDRDateModelView> list = new List<CDRDateModelView>();
            if (SubscribId != Guid.Empty && GroupId != Guid.Empty)
            {
                var subscrib = db.GroupSubscrip.Find(SubscribId); // to get date
                ViewBag.groubLimit = subscrib.Limit;
                var sims = db.GroupSimCards.Where(s=>s.GroupId.Equals(GroupId)); // get simscard

                foreach (var item in sims)
                {
                    foreach (var item2 in db.CDR.Where(s => s.SimCardId.Equals(item.SimCardId)))
                    {
                        foreach (var item3 in db.CDR_Date.Include(s=>s.CDR).Where(s => s.CDR_ID.Equals(item2.Id)))
                        {
                            if (Convert.ToDateTime(item3.Date) >= Convert.ToDateTime(subscrib.FromDate.ToString("dd/MM/yyyy")) && Convert.ToDateTime(item3.Date) <= Convert.ToDateTime(subscrib.ToDate.ToString("dd/MM/yyyy")))
                            {
                                var a = list.Where(s => s.SimCardNumber.Equals(item3.CDR.MSISDN)).Count();
                                if (a == 0)
                                {
                                    CDRDateModelView cdrD = new CDRDateModelView();
                                    cdrD.Id = item3.Id;
                                    cdrD.SimCardNumber = item3.CDR.MSISDN;
                                    cdrD.Date.Add(new DateInfo { Date = item3.Date ,Ammount = item3.Ammount});
                                    cdrD.TotlalAmmount = item3.Ammount;
                                    list.Add(cdrD);
                                }
                                else
                                {
                                    var cdrD = list.SingleOrDefault(s => s.SimCardNumber.Equals(item3.CDR.MSISDN));
                                    cdrD.Date.Add(new DateInfo { Date = item3.Date, Ammount = item3.Ammount });
                                    cdrD.TotlalAmmount += item3.Ammount;
                                }
                                
                            }
                        }
                    }
                   
                }

            }
            return View(list);
        }
    }
}