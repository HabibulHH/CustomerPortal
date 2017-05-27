using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext __context;
        //
        // GET: /Sales/
        public SalesController()
        {
            __context = new ApplicationDbContext();
        }

        public ActionResult DailySalesEntry()
        {
            return View();
        }

        public ActionResult Create(DailySales sales)
        {
            __context.DailySalesList.Add(sales);
            __context.SaveChanges();
           return RedirectToAction("DailySalesEntry", "Sales");
        }
        [HttpGet]
        public ActionResult SalesReport()
        {
            var sales = __context.DailySalesList.ToList();
           
            return View(sales);
        }

        [HttpPost]
        public ActionResult SalesReport(Settings settings)
        {

            if (settings.RepportType.Equals("Daily"))
            {
                var sales = __context.DailySalesList.
                    Where(c => (c.SalesDate >= settings.FromDate && c.SalesDate <= settings.ToDate)).
                    OrderByDescending(c => c.SalesDate).ToList();
                return View(sales);

            }
           
            
            else
            {
                var sales = __context.DailySalesList.ToList();
                return View(sales);    
            }
            
        }
    }
}