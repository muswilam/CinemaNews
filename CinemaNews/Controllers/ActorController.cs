using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaNews.Models;

namespace CinemaNews.Controllers
{
    public class ActorController : Controller
    {
        private DBHollywoodContext db = new DBHollywoodContext();
        public ActionResult List()
        {
            return View(db.Actors.ToList());
        }

        //Add new actor 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}