using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models;
using MVCExample.Repository;

namespace MVCExample.Controllers
{
    public class MatchesController : Controller
    {
        // Initiate Repository
        IRepository _repo;
        public MatchesController(IRepository repo)
        {
            _repo = repo;
        }
        
        // GET: MatchesController
        public ActionResult Index()
        {
            var ss = _repo.DisplayMatches();
            return View(ss);
        }

        // GET: MatchesController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: MatchesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Match m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Collect maximum MatchID
                    int mID = 0;
                    var ss = _repo.DisplayMatches();
                    mID = ss.Count()+1;
                    m.MatchID = mID;

                    // Add Match to repo
                    _repo.AddMatch(m);

                    // Return to Index page
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(m);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MatchesController/Edit/5
        public ActionResult Edit(int id)
        {
            var m = _repo.FindMatch(id);
            return View(m);
        }

        // POST: MatchesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Match m)
        {
            try
            {
                _repo.EditMatch(m);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MatchesController/Delete/5
        public ActionResult Delete(int id)
        {
            var m = _repo.FindMatch(id);
            return View(m);
        }

        // POST: MatchesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Match m)
        {
            try
            {
                _repo.DeleteMatch(m);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
