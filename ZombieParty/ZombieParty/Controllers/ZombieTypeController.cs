using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {

        private static List<ZombieType> _maListe = new List<ZombieType>()
        {
            new ZombieType(){ TypeName = "Virus", Id = 1 },
            new ZombieType(){ TypeName = "Contact", Id = 2 }
        };

        public IActionResult Index()
        {

            this.ViewBag.MaListe = _maListe;
            return View();
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                zombieType.Id = _maListe.Max(x => x.Id) + 1;
                _maListe.Add(zombieType);
                return RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

    }
}
