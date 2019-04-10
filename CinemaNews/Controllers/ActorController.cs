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
    }
}