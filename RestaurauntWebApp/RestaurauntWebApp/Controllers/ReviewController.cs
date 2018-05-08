using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurauntLibrary;

namespace RestaurauntWebApp.Controllers
{
    public class ReviewController : Controller
    {
        RestaurauntLibrary.BusinessLogic bl;
      public ReviewController()
        {
            bl = new RestaurauntLibrary.BusinessLogic();
        }
        // GET: Review
        public ActionResult RevIndex(int searchId)
        {
            // result = new List<Review>();
            var result = bl.GetReviews(searchId);

            return View(result);
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View(id);
        }

        // GET: Review/Create
        public ActionResult CreateRev(int id)
        {

            return View("RevCreate");
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult CreateRev(int id,Review rev)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    rev.RestID = id;
                    bl.AddReview(rev);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Review/Edit/5
        public ActionResult EditRev(int id)
        {
            Review toEdit = bl.GetReviewById(id);
            return View(toEdit);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult EditRev(Review rev)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    bl.UpdateReview(rev);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(rev);
                }
                    
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Review/Delete/5
        public ActionResult DeleteRev(int id)
        {
            Review toDel = bl.GetReviewById(id);
           return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult DeleteRev(Review toDel)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    bl.DeleteReview(toDel.ID);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(toDel);
                }
                    
                
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
