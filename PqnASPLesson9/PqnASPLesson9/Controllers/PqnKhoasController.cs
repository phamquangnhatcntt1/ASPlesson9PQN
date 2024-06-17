using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PqnASPLesson9.Models;

namespace PqnASPLesson9.Controllers
{
    public class PqnKhoasController : Controller
    {
        private Pqnk22CNTT1lesson9Entities db = new Pqnk22CNTT1lesson9Entities();

        // GET: PqnKhoas
        public ActionResult PqnIndex()
        {
            var khoas = db.pqnKhoa.ToList();
            return View(khoas);
        }

        // GET: PqnKhoas/Details/5
        public ActionResult PqnDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pqnKhoa pqnKhoa = db.pqnKhoa.Find(id);
            if (pqnKhoa == null)
            {
                return HttpNotFound("Không tìm thấy khoa với mã " + id);
            }

            return View(pqnKhoa);
        }

        // GET: PqnKhoas/Create
        public ActionResult PqnCreate()
        {
            return View();
        }

        // POST: PqnKhoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PqnCreate([Bind(Include = "PqnMaKH,PqnTenKH,PqnTrangThai")] pqnKhoa pqnKhoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.pqnKhoa.Add(pqnKhoa);
                    db.SaveChanges();
                    return RedirectToAction("PqnIndex");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError("", "Lỗi khi thêm khoa: " + ex.Message);
            }

            return View(pqnKhoa);
        }

        // GET: PqnKhoas/Edit/5
        public ActionResult PqnEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pqnKhoa pqnKhoa = db.pqnKhoa.Find(id);
            if (pqnKhoa == null)
            {
                return HttpNotFound("Không tìm thấy khoa với mã " + id);
            }

            return View(pqnKhoa);
        }

        // POST: PqnKhoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PqnEdit([Bind(Include = "PqnMaKH,PqnTenKH,PqnTrangThai")] pqnKhoa pqnKhoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pqnKhoa).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("PqnIndex");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError("", "Lỗi khi cập nhật khoa: " + ex.Message);
            }

            return View(pqnKhoa);
        }

        // GET: PqnKhoas/Delete/5
        public ActionResult PqnDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pqnKhoa pqnKhoa = db.pqnKhoa.Find(id);
            if (pqnKhoa == null)
            {
                return HttpNotFound("Không tìm thấy khoa với mã " + id);
            }

            return View(pqnKhoa);
        }

        // POST: PqnKhoas/Delete/5
        [HttpPost, ActionName("PqnDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PqnDeleteConfirmed(string id)
        {
            try
            {
                pqnKhoa pqnKhoa = db.pqnKhoa.Find(id);
                if (pqnKhoa == null)
                {
                    return HttpNotFound("Không tìm thấy khoa với mã " + id);
                }

                db.pqnKhoa.Remove(pqnKhoa);
                db.SaveChanges();
                return RedirectToAction("PqnIndex");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError("", "Lỗi khi xóa khoa: " + ex.Message);
                return View("PqnDelete", db.pqnKhoa.Find(id));
            }
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
