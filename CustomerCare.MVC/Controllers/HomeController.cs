using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomerCare.MVC.Models;

namespace CustomerCare.MVC.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> SaveCustomer(Customer customer)
    {
        if (!ModelState.IsValid)
            return View("Index");

        using(var httpClient = new HttpClient())
        {
            string url = "http://localhost:5005/CustomerCare.WebAPI/";            
            var response = await httpClient.PostAsJsonAsync(url, customer);            
        }

        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
