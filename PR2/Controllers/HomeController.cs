using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PR2.Data;
using PR2.Models;
using PR2Library1;

namespace PR2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MyApplicationContex _contex;

        public HomeController(ILogger<HomeController> logger, MyApplicationContex contex)
        {
            _logger = logger;
            _contex = contex;
        }

        public IActionResult Index()
        {
            var userId = GetUserId();

            var inputDatas = _contex.InputDatas.Where(x => x.UserId == userId ||x.UserId == null).ToList();


            return View(inputDatas);
        }


        [HttpPost]
        public IActionResult TestPage(PR2InputData inputData)
        {
            var lib = new PR2Lib();
            var result = lib.Calc(inputData);

            if(!string.IsNullOrEmpty(inputData.name))
            {
                _contex.InputDatas.Add(new InputData
                {
                    UserId = GetUserId(),
                    H = inputData.H,
                    T_MAT = inputData.T_MAT,
                    T_GAS = inputData.T_GAS,
                    V_GAS = inputData.V_GAS,
                    C_GAS = inputData.C_GAS,
                    Rashod = inputData.Rashod,
                    C_MAT = inputData.C_MAT,
                    koefficient = inputData.koefficient,
                    D_ap = inputData.D_ap,
                    name = inputData.name,
                    DateAdd = DateTime.Now,

                });

                _contex.SaveChanges();
            }


            var model = new TestPageModel
            {
                InputData = new InputData
                {
                    H = inputData.H,
                    T_MAT = inputData.T_MAT,
                    T_GAS = inputData.T_GAS,
                    V_GAS = inputData.V_GAS,
                    C_GAS = inputData.C_GAS,
                    Rashod = inputData.Rashod,
                    C_MAT = inputData.C_MAT,
                    koefficient = inputData.koefficient,
                    D_ap = inputData.D_ap
                },
                OutputData = result
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult TestPage(int variant)
        {
            var userId = GetUserId();
            var inputData = _contex.InputDatas.FirstOrDefault(x => x.id == variant && (x.UserId == userId || x.UserId == null));

            var model = new TestPageModel
            {
                InputData = inputData,
              
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();

            var inputData = _contex.InputDatas.FirstOrDefault(x => x.id == id && x.UserId == userId);

            if (inputData != null)
            {
                _contex.InputDatas.Remove(inputData);
                _contex.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int? GetUserId()
        {
            var userIdString = User.FindFirst("Id")?.Value;

            int? userId = userIdString != null ? Convert.ToInt32(userIdString) : null;
            return userId;
        }
    }
}