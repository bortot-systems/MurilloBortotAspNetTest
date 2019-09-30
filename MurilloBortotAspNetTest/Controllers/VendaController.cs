using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MurilloBortotAspNetTest.Models;

namespace MurilloBortotAspNetTest.Controllers
{
    public class VendaController : Controller
    {
        private Context db = new Context();

        // GET: Venda
        public ActionResult Index()
        {
            var venda = db.Venda.Include(v => v.Produto);
            return View(venda.ToList());
        }

        // GET: Venda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Venda/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Nome");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,Quantidade,DataVenda")] Venda venda)
        {
            using (var context = new Context())
            {
                //validate qtt
                var query = context.Estoque
                                   .Where(s => s.ProdutoId == venda.ProdutoId)
                                   .Where(s => s.Quantidade >= venda.Quantidade)
                                   .FirstOrDefault<Estoque>();

                if (query == null)
                {
                    //show error
                }                
                                       
            }

            if (ModelState.IsValid)
            {
                db.Venda.Add(venda);
                db.SaveChanges();   
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,Quantidade,DataVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produto, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Venda.Find(id);
            db.Venda.Remove(venda);
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
