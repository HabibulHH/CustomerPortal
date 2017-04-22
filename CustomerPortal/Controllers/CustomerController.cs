using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{   [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext __context;

        public CustomerController()
        {
            __context = new ApplicationDbContext();
        }

        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            customer.OpenDate = DateTime.Now;
            __context.Customers.Add(customer);
            __context.SaveChanges();
            return RedirectToAction("ViewCustomers", "Customer");
        }

        public ActionResult ViewCustomers()
        {
            var customers = __context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult CustoemerPayment()
        {
            var customers = __context.Customers.ToList();
            CustomerPaymentViewModel vm = new CustomerPaymentViewModel();
            vm.Customer = customers;
            return View(vm);
        }

        [HttpPost]
        public ActionResult CustoemerPayment(CustomerPayment payment)
        {

            __context.Payments.Add(payment);

            var customers = __context.Customers.ToList();
            var customer = __context.Customers.FirstOrDefault(c => c.CustomerID == payment.PayingCustomerId);
            customer.Balance = customer.Balance + (payment.Amount);


            __context.SaveChanges();
            ViewBag.msg = "Payment Done...";
            return RedirectToAction("ViewCustomers", "Customer");
        }

        [HttpGet]
        public ActionResult ShowPaymentReport()
        {
            ShowreportViewModel vm = new ShowreportViewModel();

            var payments = __context.Payments.ToList().OrderByDescending(c => c.PaymentDate);
            vm.customerPayments = payments;
            var customers = __context.Customers.ToList();
            vm.Customers = customers;
            return View(vm);
        }

        [HttpPost]
        public ActionResult ShowPaymentReport(SearchPayment searchPayment)
        {
            ShowreportViewModel vm = new ShowreportViewModel();
            var payments = __context.Payments.
                Where(c => c.PayingCustomerId.Equals(searchPayment.PayingCustomerId) &&
                           (c.PaymentDate >= searchPayment.StartDate && c.PaymentDate <= searchPayment.EndDate)).
                OrderByDescending(c => c.PaymentDate).ToList();

            vm.customerPayments = payments;
            var customers = __context.Customers.ToList();
            vm.Customers = customers;
            double Total = payments.Sum(c => c.Amount);

            ViewBag.Total = Total.ToString();
            return View(vm);


        }

        [HttpGet]
        public ActionResult BuyingRecordEntry()
        {


            var custoemrs = __context.Customers.ToList();

            CustomerBuyingViewModel vm = new CustomerBuyingViewModel();
            vm.Customers = custoemrs;
            return View(vm);
        }

        [HttpPost]
        public ActionResult BuyingRecordEntry(CustomerBuyingRecord BuyingRecord)
        {
            __context.BuyingRecords.Add(BuyingRecord);
            if (__context.SaveChanges() > 0) ViewBag.Message = "Data Saved...!!";
            var custoemrs = __context.Customers.ToList();
            CustomerBuyingViewModel vm = new CustomerBuyingViewModel();
            vm.Customers = custoemrs;

            return View(vm);
        }
        [HttpGet]
        public ActionResult ShowBuyingReport()
        {
            BuyingReportVM vm= new BuyingReportVM();
            vm.Customers = __context.Customers.ToList();
            vm.customerBuying = __context.BuyingRecords.ToList();
            return View(vm);

        }
        [HttpPost]
        public ActionResult ShowBuyingReport(SearchPayment searchPayment)
        {
            BuyingReportVM vm = new BuyingReportVM();
            vm.Customers = __context.Customers.ToList();
             var customerBuyingRecords = __context.BuyingRecords.Where(c => c.BuyingCustomerId.Equals(searchPayment.PayingCustomerId) &&
                           (c.BuyingDate >= searchPayment.StartDate && c.BuyingDate <= searchPayment.EndDate)).
                OrderByDescending(c => c.BuyingDate).ToList();
            vm.customerBuying = customerBuyingRecords;
            double Total = customerBuyingRecords.Sum(c => c.Amount);

            ViewBag.Total = Total.ToString();
            return View(vm);

        }

    }

}
   