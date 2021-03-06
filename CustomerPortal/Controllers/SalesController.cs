﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
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
            return RedirectToAction("SalesReport", "Sales");
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
            settings.RepportType = (settings.RepportType == null || settings.RepportType.Equals(""))
                ? "Daily"
                : settings.RepportType;
            if (settings.RepportType.Equals("Daily"))
            {
                var sales = __context.DailySalesList.
                    Where(c => (c.SalesDate >= settings.FromDate && c.SalesDate <= settings.ToDate)).
                    OrderByDescending(c => c.SalesDate).ToList();
                return View(sales);

            }
            if (settings.RepportType.Equals("Yearly"))
            {


                var listOFrec = __context.DailySalesList.GroupBy(a => a.SalesDate.Year).Select(g => new 
                {
                    SalesDate = g.Key, //g.Key,
                    Total = g.Sum(i => i.Total),
                    OnCashSale = g.Sum(i => i.OnCashSale),
                    OnDueSale = g.Sum(i => i.OnDueSale),
                    Collection = g.Sum(i => i.Collection)

                }).ToList();
                List<DailySales> dSales= new List<DailySales>();
                foreach (var itm in listOFrec)
                {
                    dSales.Add(new DailySales() { SalesDate = new DateTime(itm.SalesDate,1,1), Total = itm.Total, OnCashSale = itm.OnCashSale, OnDueSale = itm.OnDueSale, Collection = itm.Collection });
                }

                // IEnumerable<DailySales> records = listOFrec.ToList<DailySales>();
                return View(dSales);
            }
            
                 var    rec = __context.DailySalesList.ToList();
           
                 return View(rec);
            
        }
        

        public ActionResult YearlySalesResult()
        {


            

            var listOFrec = __context.DailySalesList.GroupBy(a => a.SalesDate.Year).Select(g => new YearlySalesvm()
            {
                Year = g.Key.ToString(),
                Total = g.Sum(i => i.Total),
                OnCash = g.Sum(i => i.OnCashSale),
                OnDue = g.Sum(i => i.OnDueSale),
                Collection = g.Sum(i => i.Collection)

            }).ToList();

            //IEnumerable<YearlySalesvm> records = listOFrec.ToList<YearlySalesvm>();
             return View(listOFrec);
        }
        
        public ActionResult EditSales(int Id)
        {
            var salesIndb = __context.DailySalesList.SingleOrDefault(c => c.Id == Id);
            return View(salesIndb);
            //return RedirectToAction("SalesReport", "Sales");
        }
        [HttpPost]
        public ActionResult EditSales(DailySales sales)
        {
            var salesIndb = __context.DailySalesList.SingleOrDefault(c => c.Id == sales.Id);
            if (salesIndb != null)
            {
                salesIndb.OnCashSale = sales.OnCashSale;
                salesIndb.Total = sales.Total;
                salesIndb.OnDueSale = sales.OnDueSale;
                salesIndb.Collection = sales.Collection;
                salesIndb.SalesDate = sales.SalesDate;

                __context.SaveChanges();
            }
            return RedirectToAction("SalesReport", "Sales");
            //return RedirectToAction("SalesReport", "Sales");
        }
    }
}