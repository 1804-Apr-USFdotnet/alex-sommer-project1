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


        public ActionResult GetAll()
        {
            return View(bl.GetRestauraunts());
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
        public ActionResult Details(int id)
        {
            //bl logic details
            return View();//needs web model 
        }

        // GET: Restauraunt/Create
        //public ActionResult Create()
        //{
        //    return View();//fix later
        //}

        // POST: Restauraunt/Create
        [HttpPost]
        public ActionResult Create(Restauraunt rest)
        {
            try
            {
                // TODO: Add insert logic here
                //baton pass to bl add
                bl.AddRestauraunt(rest);
                return RedirectToAction("GetAll");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Restauraunt/Edit/5
        //public ActionResult Edit(int id)
        //{

        //    return View();
        //}

        // POST: Restauraunt/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Restauraunt rest)
        {
            try
            {
                // TODO: Add update logic here
                bl.UpdateRestauraunt();//parameter
                return RedirectToAction("GetAll");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Restauraunt/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Restauraunt/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
