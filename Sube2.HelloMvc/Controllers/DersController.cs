using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
	public class DersController : Controller
	{
		public IActionResult Index()
		{
			using (var ctx = new OkulDbContext())
			{
				var lst = ctx.Dersler.ToList();
				return View(lst);
			}
		}

		[HttpGet]
		public IActionResult DersEkle()
		{
			return View();
		}
		[HttpPost]
		public IActionResult DersEkle(Ders d)
		{
			if (d != null)
			{
				using (var ctx = new OkulDbContext())
				{
					ctx.Dersler.Add(d);
					ctx.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult DersiDuzenle(int id)
		{
			using (var ctx = new OkulDbContext())
			{
				var d = ctx.Dersler.Find(id);
				return View(d);
			}
		}

		[HttpPost]
		public IActionResult DersiDuzenle(Ders d)
		{
			if (d != null)
			{
				using (var ctx = new OkulDbContext())
				{
					ctx.Entry(d).State = EntityState.Modified;
					ctx.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}

		public IActionResult DersiSil(int id)
		{
			using (var ctx = new OkulDbContext())
			{
				ctx.Dersler.Remove(ctx.Dersler.Find(id));
				ctx.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}
