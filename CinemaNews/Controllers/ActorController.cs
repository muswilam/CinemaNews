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

        //Delete one Atcor 
        [HttpPost , ActionName("Delete_One")]
        public ActionResult Delete_One(int id)
        {
            Actor actor = db.Actors.Single(act => act.Id == id);
            db.Actors.Remove(actor);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete more than one Actor 
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(IEnumerable<int> CheckDelete)
        {
            db.Actors.Where(act => CheckDelete.Contains(act.Id)).ToList().ForEach(delAct => db.Actors.Remove(delAct));
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}