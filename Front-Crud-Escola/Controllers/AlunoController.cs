using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Crud_Escola.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAluno _IAluno;
        public AlunoController(IAluno IAluno)
        {
            _IAluno = IAluno;
        }
        // GET: AlunoController
        public ActionResult Index()
        {
            return View(_IAluno.GetAsync());
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            return View(_IAluno.GetByIdAsync(id));
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoModelView collection)
        {
            try
            {
                _IAluno.PostAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<AlunoModelView> collection)
        {
            try
            {
                _IAluno.PostListAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: AlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_IAluno.GetByIdAsync(id));
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlunoModelView collection)
        {
            try
            {
                _IAluno.PutAsync(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_IAluno.GetByIdAsync(id));
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlunoModelView collection)
        {
            try
            {
                _IAluno.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
