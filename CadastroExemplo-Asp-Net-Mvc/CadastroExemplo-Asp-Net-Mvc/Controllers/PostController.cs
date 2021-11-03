using CadastroExemplo_Asp_Net_Mvc.Data;
using CadastroExemplo_Asp_Net_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroExemplo_Asp_Net_Mvc.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var posts = PostMemRepository.SelecionarTodos();

            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var post = new Post();

            return View(post);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
                PostMemRepository.Adicionar(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                PostMemRepository.Editar(id, post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfimed(int id)
        {
            try
            {
                PostMemRepository.Excluir(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
