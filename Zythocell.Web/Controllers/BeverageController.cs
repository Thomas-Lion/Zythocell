using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zythocell.Common.TransferObject;

namespace Zythocell.Web.Controllers
{
    public class BeverageController : Controller
    {
        // GET: BeverageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BeverageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeverageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeverageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeverageTO beverage)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeverageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeverageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeverageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeverageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
