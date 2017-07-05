﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{
    public class CompanyController : Controller
    {
        private  ApplicationDbContext __context = new ApplicationDbContext();
        //
        // GET: /Company/
        public ActionResult CompnayEntry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CompnayEntry(Compnay company)
        {
            __context.CompanyList.Add(company);
            __context.SaveChanges();
            return RedirectToAction("ShowAllCompany");
        }

        public ActionResult ShowAllCompany()
        {
            return View(__context.CompanyList.ToList());
        
        }

        public  ActionResult DeleteCompany(int id)
        {
            var companyInDb = __context.CompanyList.SingleOrDefault(c => c.Id == id);
            if (companyInDb != null)
            {
                __context.CompanyList.Remove(companyInDb);
                __context.SaveChanges();
           
            }

             return RedirectToAction("ShowAllCompany");
        }
        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            var companyInDb = __context.CompanyList.SingleOrDefault(c => c.Id == id);

            return View(companyInDb);

        }

        [HttpPost]
        public ActionResult EditCompany(Compnay company)
        {
            var companyInDb = __context.CompanyList.SingleOrDefault(c => c.Id == company.Id);
            if (companyInDb != null)
            {
                companyInDb.BakiAmount = company.BakiAmount;
                companyInDb.MobileNumber = companyInDb.MobileNumber;
                __context.SaveChanges();

            }

            return  RedirectToAction("ShowAllCompany");

        }
    }
}