using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Exemplo3.Controllers
{
    public class FabricanteController : Controller
    {
        public Context context;
        public FabricanteController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index(int pagina = 1)
        {
            return View(context.Fabricantes.ToPagedList(pagina, 3));
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

        public IActionResult Edit(int id)
        {
            var fabricante = context.Fabricantes.Find(id);
            return View(fabricante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fabricante fabricante)
        {
            context.Entry(fabricante).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var fabricante = context.Fabricantes.FirstOrDefault(f => f.FabricanteID == id);
            return View(fabricante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Fabricante fabricante)
        {
            context.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
