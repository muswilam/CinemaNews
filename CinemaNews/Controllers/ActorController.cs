using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaNews.Models;
using PagedList;
using PagedList.Mvc;

namespace CinemaNews.Controllers
{

    public class ActorController : Controller
    {
        private DBHollywoodContext db = new DBHollywoodContext();
        public ActionResult List(string search , string searchBy , int? page)
        {
            List<Actor> actors = new List<Actor>();
            if(string.IsNullOrWhiteSpace(search))
            {
                actors = db.Actors.ToList();
            }
            else
            {
                if(searchBy == "Name")
                {
                    actors = db.Actors.Where(act => act.FirstName.StartsWith(search) || act.LastName.StartsWith(search) || act.FirstName + " " + act.LastName == search).ToList();
                }
                else
                {
                    actors = db.Actors.Where(act => act.Gender.StartsWith(search)).ToList();
                }
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(actors.ToPagedList(pageNumber, pageSize));
        }

        //filter searchng functionality
        //[HttpPost , ActionName("List")]
        //public ActionResult ListPost(string search, string searchBy , int? page)
        //{
        //    List<Actor> actors = new List<Actor>();
        //    if (string.IsNullOrWhiteSpace(search))
        //    {
        //        actors = db.Actors.ToList();
        //    }
        //    else
        //    {
        //        if (searchBy == "Name")
        //        {
        //            actors = db.Actors.Where(act => act.FirstName.StartsWith(search) || act.LastName.StartsWith(search)).ToList();
        //        }
        //        else
        //        {
        //            actors = db.Actors.Where(act => act.Gender.StartsWith(search)).ToList();
        //        }
        //    }
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(actors.ToPagedList(pageNumber , pageSize));
        //}


        // autocomplete search text
        public JsonResult GetCompletedSearch(string term )
        {
            List<string> actorComplete = db.Actors.Where(act => act.FirstName.StartsWith(term) || act.LastName.StartsWith(term))
                                           .Select(act => act.FirstName + " " + act.LastName).ToList();
            return Json(actorComplete, JsonRequestBehavior.AllowGet);
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
            Actor actor = db.Actors.Single(act => act.Actor_Id == id);
            db.Actors.Remove(actor);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete more than one Actor 
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(IEnumerable<int> CheckDelete)
        {
            db.Actors.Where(act => CheckDelete.Contains(act.Actor_Id)).ToList().ForEach(delAct => db.Actors.Remove(delAct));
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Edit one Actor Info 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int? id)
        {
            if(id == null)
                throw new Exception();
            else
            return View(db.Actors.Single(act => act.Actor_Id== id));
        }

        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                Actor actorFromDb = db.Actors.Find(actor.Actor_Id);
                actorFromDb.Awards = actor.Awards;
                actorFromDb.IMDb = actor.IMDb;
                actorFromDb.Profile = actor.Profile;

                db.Entry(actorFromDb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View(actor);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                throw new Exception();
            else
            return View(db.Actors.Single(act => act.Actor_Id == id));
        }
    }
}