using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Models;
using StoreManager.Services;

namespace StoreManager.Controllers
{
  [Route("[controller]/[action]")]
  public class HomeController : Controller
  {
    private readonly ICatalogViewModelService _catalogViewModelService;

    public HomeController(ICatalogViewModelService catalogService)
    {
      _catalogViewModelService = catalogService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var model = new OrderManager.Views.Home.IndexModel(_catalogViewModelService);
      return View(model);
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
  }
}
