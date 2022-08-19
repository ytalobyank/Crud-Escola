using Front_Crud_Escola.Interfaces;
using Front_Crud_Escola.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Crud_Escola.Controllers
{
    public class EscolaController : Controller
    {
        private readonly IEscola _IEscola;
        public EscolaController(IEscola IEscola)
        {
            _IEscola = IEscola;
        }

        // GET: EscolaController
        public ActionResult Index()
        {
            return View(_IEscola.GetAsync());
        }

        // GET: EscolaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_IEscola.GetByIdAsync(id));
        }

        // GET: EscolaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscolaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EscolaModelView collection)
        {
            try
            {
                _IEscola.PostAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EscolaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_IEscola.GetByIdAsync(id));
        }

        // POST: EscolaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EscolaModelView collection)
        {
            try
            {
                _IEscola.PutAsync(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EscolaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_IEscola.GetByIdAsync(id));
        }

        // POST: EscolaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EscolaModelView collection)
        {
            try
            {
                _IEscola.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
