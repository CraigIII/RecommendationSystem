using CustomerClusterWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using ProductRecommendationWebSite;
using System.Diagnostics;

namespace CustomerClusterWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PredictMovieRating()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PredictMovieRating(MLModel.ModelInput modelInput)
        {
            MLModel.ModelOutput predictionResult = MLModel.Predict(modelInput);
            return Json(predictionResult);
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
    }
}
