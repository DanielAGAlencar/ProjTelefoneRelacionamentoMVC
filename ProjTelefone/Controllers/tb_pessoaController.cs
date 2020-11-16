using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjTelefone;

namespace ProjTelefone.Controllers
{
    public class tb_pessoaController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: tb_pessoa
        public ActionResult Index()
        {
            return View(db.tb_pessoa.ToList());
        }

        // GET: tb_pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // GET: tb_pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_pessoa/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome")] tb_pessoa tb_pessoa)
        {
            if (ModelState.IsValid)
            {
                db.tb_pessoa.Add(tb_pessoa);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(tb_pessoa);
            return Json(new { Resultado = tb_pessoa.id }, JsonRequestBehavior.AllowGet);
        }

        // GET: tb_pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // POST: tb_pessoa/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome")] tb_pessoa tb_pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_pessoa);
        }

        // GET: tb_pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tb_pessoa);
        }

        // POST: tb_pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            db.tb_pessoa.Remove(tb_pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
