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
using Microsoft.AspNetCore.Authorization;

namespace Zythocell.Web.Controllers
{
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
        [Authorize]
        public IActionResult Index()
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
                        QuantityBeverage = item.Quantity,
                        SmallDescription = item.SmallDescription
                    };

                    resultVM.Add(vm);
                }

                return View(resultVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: CellarController/Details/5
        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
                var cellarResult = _cellarUsesCases.GetSpecificCellar(_userManager.GetUserAsync(User).Result.Id, id);
            try
            {
                var rateResult = _cellarUsesCases.GetSpecificRate(_userManager.GetUserAsync(User).Result.Id, id);

                var vm = new RateVM
                {
                    CellarId = cellarResult.Id,
                    BeverageId = cellarResult.BeverageId,
                    QuantityBeverage = cellarResult.Quantity,
                    AgeBeverage = cellarResult.AgeBeverage,
                    Date = cellarResult.Date,
                    SmallDescription = cellarResult.SmallDescription,
                    RateId = rateResult.Id,
                    Rating = rateResult.Rating,
                    Comment = rateResult.Comment
                };

                return View(vm);
            }
            catch (Exception )
            {
                var vm = new RateVM
                {
                    CellarId = cellarResult.Id,
                    BeverageId = cellarResult.BeverageId,
                    QuantityBeverage = cellarResult.Quantity,
                    AgeBeverage = cellarResult.AgeBeverage,
                    Date = cellarResult.Date,
                    SmallDescription = cellarResult.SmallDescription,
                };

                return View(vm);
            }
        }

        // GET: CellarController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CellarController/Create
        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            return Details(id);
        }

        // POST: CellarController/Edit/5
        [HttpPost]
        [Authorize]
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
    }
}
