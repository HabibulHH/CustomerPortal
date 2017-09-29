using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationDbContext __context = new ApplicationDbContext();
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
        [HttpGet]
        public ActionResult CompanyPayment()
        {
            var companyList= __context.CompanyList.ToList();
            CompanyPaymentVM vm= new CompanyPaymentVM();
            vm.Company = companyList;
            return View(vm);
        }
        [HttpPost]
        public ActionResult CompanyPayment(CompanyPayment payment)
        {
            var company= __context.CompanyList.FirstOrDefault(c=>c.Id==payment.CompanyId);
            if (company != null)
            {
                company.BakiAmount = company.BakiAmount - payment.Amount;
                __context.SaveChanges();
                payment.CompanyName = company.CompanyName;
                __context.CompanyPayments.Add(payment);
                __context.SaveChanges();
            }

            return RedirectToAction("ShowAllCompany");
        }

        public ActionResult ShowPaymentsRecords()
        {
            var company = __context.CompanyList.ToList();
            ShowCompanyReportVM vm= new ShowCompanyReportVM();
            vm.Compnays = company;
            var payments = __context.CompanyPayments.ToList();
            vm.companysPayments = payments;
             // give necessary data
            return View(vm);
        }
        [HttpPost]
        public ActionResult ShowPaymentsRecords(ShowCompanyReportVM paymentreportVM)
        {

            var payment = paymentreportVM.searchPayment;
            int ID = Convert.ToInt32(payment.CompanyId);
            var payments = __context.CompanyPayments.
                Where(c => c.CompanyId==payment.CompanyId &&
                           (c.PaymentDate >= payment.StartDate && c.PaymentDate <= payment.EndDate)).
                OrderByDescending(c => c.PaymentDate).ToList();

            var company = __context.CompanyList.ToList();
            ShowCompanyReportVM vm = new ShowCompanyReportVM();
            vm.Compnays = company;
            vm.companysPayments = payments;
            
            return View(vm);
        }
    }
}