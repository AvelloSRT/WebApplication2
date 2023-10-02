using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Imie = "Mateusz";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ?  "Dzień dobry": "Dobry wieczór";
            return View();
        }
        Dane[] osoby =
        {
            new Dane {Name="Marek", Surname="Burek"},
            new Dane {Name="Jan", Surname="Kowalski"},
            new Dane {Name="Jakub", Surname="Mazur"}
        };
        public IActionResult Urodziny(Urodziny urodziny) 
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie}, masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View(); 
        }
       
        public IActionResult Kalkulator(Numbers kalkulator)
            {
            if (kalkulator.Mark == '+')
            {
                kalkulator.Result = kalkulator.Number1 + kalkulator.Number2;
                ViewBag.wynik = $"Wynik dodawania to {kalkulator.Result}";
            }
            else if (kalkulator.Mark == '-') 
            { 
                kalkulator.Result = kalkulator.Number1 - kalkulator.Number2;
                ViewBag.wynik = $"Wynik odejmowania to {kalkulator.Result}";
            }
            else if (kalkulator.Mark == '*') 
            { 
                kalkulator.Result = kalkulator.Number1 * kalkulator.Number2;
                ViewBag.wynik = $"Wynik mnożenia to {kalkulator.Result}";
            }
            else if (kalkulator.Mark == '/')
            {
                if(kalkulator.Number2 == 0)
                {
                    ViewBag.wynik = "Nie można podzielić przez 0";
                }
                else
                {
                    kalkulator.Result = (kalkulator.Number1/ kalkulator.Number2);
                    ViewBag.wynik = $"Wynik dzielenia to {kalkulator.Result}";
                }
            }
           
                return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}