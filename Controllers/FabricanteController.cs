using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exemplo3.Controllers
{
    public class FabricanteController : Controller
    {
        public Context context;
        public FabricanteController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Fabricantes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fabricante fabricante)
        {
            context.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var fabricante = context.Fabricantes.FirstOrDefault(f => f.FabricanteID == id);
            return View(fabricante);
        }
    }
}
