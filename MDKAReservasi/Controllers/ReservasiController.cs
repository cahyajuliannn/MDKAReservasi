using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDKAReservasi.Models;
using Rotativa;

namespace MDKAReservasi.Controllers
{
    public class ReservasiController : Controller
    {
        private MDKAReservasiModels db = new MDKAReservasiModels();

        // GET: tblT_Reservasi
        public ActionResult Index()
        {
            var tblT_Reservasi = db.tblT_Reservasi.Include(t => t.tblM_Ruangan);
            return View(tblT_Reservasi.ToList());
        }

        // GET: tblT_Reservasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Create
        public ActionResult Create()
        {
            ViewBag.Ruangan_FK = new SelectList(db.tblM_Ruangan, "Ruangan_PK", "NamaRuangan");
            return View();
        }

        // POST: tblT_Reservasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reservasi_PK,Ruangan_FK,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] tblT_Reservasi tblT_Reservasi)
        {
            if (ModelState.IsValid)
            {
                tblT_Reservasi.CreatedBy = "SYSTEM";
                tblT_Reservasi.CreatedDate = DateTime.Now;
                db.tblT_Reservasi.Add(tblT_Reservasi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ruangan_FK = new SelectList(db.tblM_Ruangan, "Ruangan_PK", "NamaRuangan", tblT_Reservasi.Ruangan_FK);
            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ruangan_FK = new SelectList(db.tblM_Ruangan, "Ruangan_PK", "NamaRuangan", tblT_Reservasi.Ruangan_FK);
            return View(tblT_Reservasi);
        }

        // POST: tblT_Reservasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reservasi_PK,Ruangan_FK,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] tblT_Reservasi tblT_Reservasi)
        {
            if (ModelState.IsValid)
            {
                var tbl = db.tblT_Reservasi.SingleOrDefault(x => x.Reservasi_PK == tblT_Reservasi.Reservasi_PK);
                tbl.UpdatedBy = "SYSTEM";
                tbl.UpdatedDate = DateTime.Now;
                tbl.Ruangan_FK = tblT_Reservasi.Ruangan_FK;
                db.Entry(tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ruangan_FK = new SelectList(db.tblM_Ruangan, "Ruangan_PK", "NamaRuangan", tblT_Reservasi.Ruangan_FK);
            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            return View(tblT_Reservasi);
        }

        // POST: tblT_Reservasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            db.tblT_Reservasi.Remove(tblT_Reservasi);
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
        public ActionResult PrintAllIndex()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        public ActionResult PrintDetail(int id)
        {
            var report = new ActionAsPdf("Edit", new { id = id });
            return report;
        }
    }
}
