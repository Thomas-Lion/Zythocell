using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zythocell.Common.Interfaces;
using Zythocell.Common.Interfaces.IUsesCases;
using Zythocell.Common.TransferObject;
using Zythocell.DAL.Extensions;
using Zythocell.Identity;
using Zythocell.Web.Models;

namespace Zythocell.Web.Controllers
{
    [Route("api/[Controller]")]
    public class CellarController : Controller
    {
        private readonly ILogger<CellarController> _logger;
        private readonly ICellarUsesCases _cellarUsesCases;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CellarController(ILogger<CellarController> logger, ICellarUsesCases cellarUsesCases, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _cellarUsesCases = cellarUsesCases;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: CellarController
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _cellarUsesCases.GetAllCellar(_userManager.GetUserAsync(User).Result.Id);
                var resultVM = new List<CellarVM>();

                foreach (var item in result)
                {
                    var beverage = _cellarUsesCases.GetABeverage(item.BeverageId);
                    var vm = new CellarVM
                    {
                        BeverageId = item.BeverageId,
                        CellarId = item.Id,
                        NameBeverage = beverage.Name,
                        Alcohol = beverage.Alcohol,
                        SizeBottle = beverage.Size,
                        DateBotteling = item.AgeBeverage,
                        QuantityBeverage = item.Quantity
                    };

                    resultVM.Add(vm);
                }

                return View(resultVM);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: CellarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CellarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CellarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CellarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CellarController/Edit/5
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

        // GET: CellarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CellarController/Delete/5
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
