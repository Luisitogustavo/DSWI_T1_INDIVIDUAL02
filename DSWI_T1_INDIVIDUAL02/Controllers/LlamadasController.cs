
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Controllers
{
    public class LlamadasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Llamada());
        }

        [HttpPost]
        public IActionResult Index(Llamada llamada)
        {
            if (llamada.Minutos <= 0)
            {
                ModelState.AddModelError("Minutos",
                    "Ingrese una cantidad válida de minutos.");
                return View(llamada);
            }

            llamada.Total = llamada.Minutos <= 5
                ? 10
                : 10 + (llamada.Minutos - 5) * 2;

            return View(llamada);
        }
    }
}

