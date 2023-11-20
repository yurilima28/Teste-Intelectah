using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class ConsultaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
