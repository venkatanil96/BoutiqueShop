using Boutiquedress.Models;
using BoutiqueShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutiqueShop.Controllers
{
    public class DressController : Controller
    {
        public ActionResult AddNewDress()
        {
            var con = new DataComponent();

            return View(new Dress());
        }
        [HttpPost]
        public ActionResult AddNewDress(Dress dress)
        {
            var con = new DataComponent();
            try
            {
                con.AddNewDress(dress);
                return View(new Dress());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Dress());
            }
        }
        public ActionResult GetAllDresses()
        {
            var con = new DataComponent();
            var dresss = con.GetAllDresses();
            return View(dresss);
        }
        public ActionResult FindDress(string id)
        {
            int dressId = Convert.ToInt32(id);
            var con = new DataComponent();
            try
            {
                var dress = con.FindDress(dressId);
                return View(dress);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult UpdateDress(string id)
        {
            int dressId = Convert.ToInt32(id);
            var con = new DataComponent();
            try
            {
                var dress = con.FindDress(dressId);
                return View(dress);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateDress(Dress dress)
        {

            var con = new DataComponent();
            try
            {
                con.UpdateDress(dress);

                return RedirectToAction("GetAllDresses");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult DeleteDress(string id)
        {
            var con = new DataComponent();
            int dressId = Convert.ToInt32(id);
            try
            {
                con.DeleteDress(dressId);
                return RedirectToAction("GetAllDresses");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}