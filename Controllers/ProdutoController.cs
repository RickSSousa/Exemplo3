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
    public class ProdutoController : Controller
    {
        //devemos declarar um obj context, pois é nosso BD e é necessário carregar ele no método construtor
        public Context context;
        public ProdutoController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Produtos.Include(f => f.Fabricante)); //com o include, ele busca o nome dos fabricantes, carregando a associação 1 pra *
        }

        public IActionResult Create()
        {
            //viewbag serve como um obj q vai as informações q estão sendo solicitadas, nesse caso, está carregando em formato de lista o nome dos fabricantes em ordem alfabética
                                                                                          //rótulo e valor buscado no BD
            ViewBag.Fabricante = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges(); //pra salvar as alterações
            return RedirectToAction("Index"); //isso faz com q, assim q ele salvar, volta pra lista d produtos na pág Index
        }

        public IActionResult Details(int id)
        {
            var produto = context.Produtos.Include(f => f.Fabricante).FirstOrDefault(p => p.ProdutoID == id);
                                                                      //o primeiro q ele encontrar, onde estiver com o Id igual o do parametro, aí funca
            return View(produto);
        }

        public IActionResult Edit (int id)
        {
            var produto = context.Produtos.Find(id);
            ViewBag.FabricanteID = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteID", "Nome");
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;// está colocando o registro em estado d modificação
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var produto = context.Produtos.Include(f => f.Fabricante).FirstOrDefault(p => p.ProdutoID == id);
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Produto produto)
        {
            context.Remove(produto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
