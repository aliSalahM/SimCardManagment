﻿using System;
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
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext db;
        public GroupController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<GroupModelView> list = new List<GroupModelView>();
            db.Group.Include(s=>s.BelongTo).ToList().ForEach(x => { list.Add((GroupModelView)x); });
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.users = db.User;
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupModelView mv)
        {
            if (ModelState.IsValid)
            {
                db.Group.Add((Group)mv);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.alertMsg = "تمت ألعملية بنجاح";
            }
            ViewBag.users = db.User;
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                ViewBag.users = db.User;
                return View((GroupModelView)db.Group.Find(id));
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(GroupModelView vm)
        {
            if (ModelState.IsValid)
            {
                db.Group.Update((Group)vm);
                db.SaveChanges();
                ViewBag.alertMsg = "تمت ألعملية بنجاح";
            }
            ViewBag.users = db.User;
            return View();
        }
        [HttpGet]
        public IActionResult AddSimCardToGroup(Guid id, string filter, int page = 1)
        {
            List<GroupSimCardsModelView> list = new List<GroupSimCardsModelView>();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                list.Clear();
                foreach (var item in db.SimCard.Where(s=>s.SimCardNumber.Contains(filter)))
                {
                    if (!db.GroupSimCards.Include(s => s.SimCard).Any(s => s.SimCardId.Equals(item.Id) && s.GroupId.Equals(id)))
                    {
                        GroupSimCardsModelView mv = new GroupSimCardsModelView();
                        mv.SimCardId = item.Id;
                        mv.SimCard = item;
                        mv.GroupId = id;
                        mv.Selected = false;
                        list.Add(mv);
                    }
                }
            }
            else
            {
                foreach (var item in db.SimCard)
                {
                    if (!db.GroupSimCards.Any(s => s.SimCardId.Equals(item.Id) && s.GroupId.Equals(id)))
                    {
                        GroupSimCardsModelView mv = new GroupSimCardsModelView();
                        mv.SimCardId = item.Id;
                        mv.SimCard = item;
                        mv.GroupId = id;
                        mv.Selected = false;
                        list.Add(mv);
                    }
                }
            }


            var model = PagingList.Create(list, 10, page);
            model.Action = "AddSimCardToGroup";
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddSimCardToGroup(List<GroupSimCardsModelView> mv,Guid id,int page = 1)
        {
            foreach (var item in mv.Where(s=>s.Selected))
            {
                var x = db.GroupSimCards.Where(s => s.SimCardId == item.SimCardId && s.GroupId.Equals(item.GroupId));
                if (x.Count() == 0)
                {
                    GroupSimCards groupSimCards = new GroupSimCards();
                    groupSimCards.SimCardId = item.SimCardId;
                    groupSimCards.GroupId = item.GroupId;
                    db.GroupSimCards.Add(groupSimCards);
                    db.SaveChanges();
                    ViewBag.alertMsg = "تمت ألعملية بنجاح";
                }
                
            }
            foreach (var item in mv.Where(s => !s.Selected))
            {
                var x = db.GroupSimCards.Where(s => s.SimCardId == item.SimCardId && s.GroupId.Equals(item.GroupId));
                if (x.Count() != 0)
                {
                    db.GroupSimCards.Remove(db.GroupSimCards.SingleOrDefault(s => s.GroupId.Equals(item.GroupId) && s.SimCardId.Equals(item.SimCardId)));
                    db.SaveChanges();
                    ViewBag.alertMsg = "تمت ألعملية بنجاح";
                }
               
            }
            return RedirectToAction(nameof(AddSimCardToGroup));
        }
        [HttpGet]
        public IActionResult GetSimsForGroup(Guid id)
        {
            if (id != Guid.Empty)
            {
                List<GroupSimCardsModelView> list = new List<GroupSimCardsModelView>();
                db.GroupSimCards.Include(s=>s.SimCard).Where(s => s.GroupId.Equals(id)).ToList().ForEach(x => { list.Add((GroupSimCardsModelView)x); });
                return View(list);
            }
            return View();
        }
        public void DeleteSimFromGroup(Guid id)
        {
            if (id != Guid.Empty)
            {
                db.GroupSimCards.Remove(db.GroupSimCards.Find(id));
                db.SaveChanges();
            }
        }


        [AcceptVerbs("Get","Post")]
        public JsonResult IsNameInUse(string Name,Guid Id)
        {
            var nameG = db.Group.Where(s => s.Name.Equals(Name)&&s.Id != Id).Count();
            if (nameG != 0)
            {
                return Json($" ({Name}) هذا الأسم مستخدم بالفعل ");               
            }
            else
            {
                return Json("true");
            }
        }
    }
}