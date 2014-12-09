using BlogRoll.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogRoll.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieDB db = new MovieDB();
        //
        // GET: /Home/

        public ActionResult Index(string sortOrder)
        {
            ViewBag.PageTitle = "List of Movies (" + db.Movies.Count() + " Films in Database)";
            if (sortOrder == null) sortOrder = "ascNumber";
            ViewBag.numberOrder = (sortOrder == "ascNumber") ? "descNumber" : "ascNumber";
            ViewBag.dateOrder = (sortOrder == "ascDate") ? "descDate" : "ascDate";
            //ViewBag.Count = "+ db.Movies.Count()";

            IQueryable<Movie> movies = db.Movies;
            switch (sortOrder)
            {
                case "descDate":
                    ViewBag.dateOrder = "ascDate";
                    movies = movies.OrderByDescending(c => c.ReleaseDate);
                    break;
        
                case "ascDate":
                    ViewBag.dateOrder = "descDate";
                    movies = movies.OrderBy(c => c.ReleaseDate);
                    break;
           
            }
            return View(db.Movies.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int? id)
        {
            var film = db.Movies.Find(id);
            if (film == null) return View();
            else
            return View(film);
        }

        //
        // GET: /Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var newmovie = new MovieDB())
                    {
                        newmovie.Movies.Add(newMovie);
                        db.Entry(newMovie).Entity.MovieImage = "content/images/unavailable.jpg";
                        newmovie.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            //Movie editMovie = db.Movies.Find(id);
            //return PartialView(editMovie);
            return View(db.Movies.Find(id));
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {
                
                db.Entry(editMovie).State = EntityState.Modified;
                db.Entry(editMovie).Entity.MovieImage = "content/images/unavailable.jpg";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.Movies.Find(id));
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteMovie(int id)
        {
                db.Movies.Remove(db.Movies.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        [HttpPost, ActionName("DeleteActor")]
        public PartialViewResult DeleteActor(int id, int movieid)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return PartialView("_ActorsInMovie", db.Movies.Find(movieid).Actors);
        }
        }
    }

