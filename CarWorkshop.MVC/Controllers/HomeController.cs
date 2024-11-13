using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

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

    public IActionResult Privacy()
    {

        var model = new List<Person>()
        {
               new Person()
               {
                   FirstName = "Kacper",
                   LastName = "Niciak"
               },
            new Person()
               {
                   FirstName = "Adam",
                   LastName = "Malysz"
               },

            };

        return View(model);
    }

    public IActionResult About()
    {

        var model = new List<AboutModel>()
        {
            new AboutModel()
            {
            Title = "Kaczka",
            Description ="swietna super pyszna",
            Tags = new[] {"jedzenie","swietne"},

            },

            new AboutModel()
            {
            Title = "kura",
            Description ="biega skacze klaszcze",
            Tags = new[] {"zwierzontka","super"},

            }


        };
        
        


        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
