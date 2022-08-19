using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Crud_Escola.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurma _ITurma;
        public TurmaController(ITurma ITurma)
        {
            _ITurma = ITurma;
        }
        // GET: TurmaController
        public ActionResult Index()
        {
            return View(_ITurma.GetAsync());
        }

        // GET: TurmaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_ITurma.GetByIdAsync(id));
        }

        // GET: TurmaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TurmaModelView collection)
        {
            try
            {
                _ITurma.PostAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult CreateList()
        {
            return View();
        }

        // GET: TurmaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ITurma.GetByIdAsync(id));
        }

        // POST: TurmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TurmaModelView collection)
        {
            try
            {
                _ITurma.PutAsync(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurmaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ITurma.GetByIdAsync(id));
        }

        // POST: TurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TurmaModelView collection)
        {
            try
            {
                _ITurma.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
