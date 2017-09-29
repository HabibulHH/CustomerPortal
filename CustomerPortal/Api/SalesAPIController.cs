using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using CustomerPortal.Models;

namespace CustomerPortal.Api
{
    public class SalesAPIController:ApiController
    {

        private ApplicationDbContext __context;

        public SalesAPIController()
        {
            __context=new ApplicationDbContext();
        }

        [HttpDelete]
        public void DeleteSales(int id)
        {
            var salesIndb = __context.DailySalesList.SingleOrDefault(c => c.Id == id);
            if (salesIndb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            __context.DailySalesList.Remove(salesIndb);
            __context.SaveChanges();
        }
        



    }
}