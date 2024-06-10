using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenciler = ctx.Ogrenciler
                                    .Include(o => o.OgrenciDersler)
                                        .ThenInclude(od => od.Ders)
                                    .ToList();
                return View(ogrenciler);
            }
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }

        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ogr).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DersEkle(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenci = ctx.Ogrenciler.Include(o => o.OgrenciDersler).FirstOrDefault(o => o.Ogrenciid == id);
                var dersler = ctx.Dersler.ToList();
                ViewBag.OgrenciId = id;
                ViewBag.Dersler = dersler;
                return View();
            }
        }

        [HttpPost]
        public IActionResult DersEkle(int ogrenciId, int dersId)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenci = ctx.Ogrenciler
                                   .Include(o => o.OgrenciDersler)
                                   .FirstOrDefault(o => o.Ogrenciid == ogrenciId);

                if (ogrenci == null)
                {
                    return NotFound($"Öğrenci ID {ogrenciId} bulunamadı.");
                }

                var ders = ctx.Dersler.FirstOrDefault(d => d.Dersid == dersId);

                if (ders == null)
                {
                    return NotFound($"Ders ID {dersId} bulunamadı.");
                }

                var mevcutKayit = ogrenci.OgrenciDersler
                                        .FirstOrDefault(od => od.DersId == dersId);

                if (mevcutKayit != null)
                {
                    return BadRequest("Öğrenci zaten bu derse kayıtlı.");
                }

                ogrenci.OgrenciDersler.Add(new OgrenciDers { OgrenciId = ogrenciId, DersId = dersId });
                ctx.SaveChanges();

                return RedirectToAction("Index", "Student");
            }
        }

        [HttpPost]
        public IActionResult DeleteDers(int ogrenciId, int dersId)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenci = ctx.Ogrenciler
                                  .Include(o => o.OgrenciDersler)
                                  .FirstOrDefault(o => o.Ogrenciid == ogrenciId);

                if (ogrenci == null)
                {
                    return NotFound($"Öğrenci ID {ogrenciId} bulunamadı.");
                }
                var ders = ogrenci.OgrenciDersler.FirstOrDefault(od => od.DersId == dersId);
                if (ders != null)
                {
                    ogrenci.OgrenciDersler.Remove(ders);
                    ctx.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound($"Öğrenci ID {ogrenciId} için ders ID {dersId} bulunamadı.");
                }
            }
        }
    }
}
