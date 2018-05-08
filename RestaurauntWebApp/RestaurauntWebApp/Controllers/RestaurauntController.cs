using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurauntLibrary;


namespace RestaurauntWebApp.Controllers
{
    public class RestaurauntController : Controller
    {
        //RestaurauntDataLayer.RestaurauntCRUD crud;
        //use interfaces
        //constructor
        RestaurauntLibrary.BusinessLogic bl;
       
        public RestaurauntController()
        {
            bl = new RestaurauntLibrary.BusinessLogic();
        }
        //fakedb constructor


        public ActionResult GetAll(string searchStr)
        {
            if (searchStr != null)
            {
                var result = bl.SearchRestaraunts(searchStr);
                return View(result);
            }
            else
            return View(bl.GetRestauraunts());
        }
        public ActionResult GetByName()
        {
            return View(bl.SortByName());
        }
        public ActionResult TopThree()
        {
            var rests = bl.GetRestauraunts();
            var tops = RestaurauntLibrary.BusinessLogic.TopThree(rests);
            return View(tops);
        }


        // GET: Restauraunt
        [HttpGet]
        public ActionResult Index()
        {
            List < RestaurauntLibrary.Restauraunt > rests  = bl.GetRestauraunts();
            return View("GetAll");
        }

        // GET: Restauraunt/Details/5
        public ActionResult Details(int? id)
        {
            
            return View(  bl.GetRestauraunt(id));//needs web model 
        }

        // GET: Restauraunt/Create
        public ActionResult Create()
        {
            return View();//fix later
        }

        // POST: Restauraunt/Create
        [HttpPost]
        public ActionResult Create(Restauraunt rest)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    bl.AddRestauraunt(rest);
                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View(rest);
                }
                
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Restauraunt/Edit/5
        public ActionResult Edit(int id)
        {
            Restauraunt toEdit = bl.GetRestauraunt(id);
            return View(toEdit);
        }

        // POST: Restauraunt/Edit/5
        [HttpPost]
        public ActionResult Edit( Restauraunt rest)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    
                    bl.UpdateRestauraunt(rest);
                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View(rest);
                }
                    
                //parameter
                
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Restauraunt/Delete/5
        public ActionResult Delete(int id)
        {
            Restauraunt toDel = bl.GetRestauraunt(id);
            return View(toDel);
        }

        // POST: Restauraunt/Delete/5
        [HttpPost]
        public ActionResult Delete(Restauraunt rest)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    bl.DeleteRestauraunt(rest);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(rest);
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
