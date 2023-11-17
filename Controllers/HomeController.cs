using Agedamento.Models;
using Agendamento.ModelS;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agedamento.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
           PacientesModel home = new PacientesModel();
          
            return View();
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