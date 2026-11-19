
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Controllers
{
    public class GimnasioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Gimnasio());
        }

        [HttpPost]
        public IActionResult Index(Gimnasio gimnasio)
        {
            if (gimnasio.Edad < 0 || gimnasio.Meses <= 0)
            {
                ModelState.AddModelError("",
                    "Ingrese una edad y duración válidas.");
                return View(gimnasio);
            }

            gimnasio.TarifaBase = gimnasio.Edad < 18 ? 20 :
                                  gimnasio.Edad < 60 ? 35 : 25;

            decimal porcentaje = gimnasio.Meses switch
            {
                3 => 0.05m,
                6 => 0.10m,
                12 => 0.20m,
                _ => 0m
            };

            decimal subtotal = gimnasio.TarifaBase * gimnasio.Meses;
            gimnasio.Descuento = subtotal * porcentaje;
            gimnasio.Total = subtotal - gimnasio.Descuento;

            return View(gimnasio);
        }
    }
}

