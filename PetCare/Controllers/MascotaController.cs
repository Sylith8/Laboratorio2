using Microsoft.AspNetCore.Mvc;
using PetCare.Data;
using PetCare.Models;

namespace PetCare.Controllers
{
    public class MascotaController : Controller
    {
        private readonly MascotaRepository _repo = new MascotaRepository();

        public IActionResult Index()
        {
            var lista = _repo.ObtenerMascotas();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guardar(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _repo.AgregarMascota(mascota);
                TempData["Mensaje"] = "Mascota registrada exitosamente.";
                return RedirectToAction("Index");
            }
            return View("Registrar", mascota);
        }
    }
}