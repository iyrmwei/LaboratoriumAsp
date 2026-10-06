using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Hello()
    {
        return Content("Hello, from ASP.NET", "text/plain; charset=utf-8");
    }
    
    public IActionResult About() 
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Age(DateTime? birth)
    {
        if (birth == null)
        {
            return BadRequest();
        }
        
        var age = DateTime.Now.Year - birth.Value.Year;
        ViewBag.Age = age;
        
        return View();
    }

    public IActionResult AgeForm()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}