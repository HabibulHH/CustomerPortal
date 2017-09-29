using System.Data;
using System.Data.Entity;
using System.Security.AccessControl;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomerPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPayment> Payments { get; set; }
        public DbSet<CustomerBuyingRecord> BuyingRecords { get; set; }
        public DbSet<Compnay> CompanyList { get; set; }
        public DbSet<DailySales> DailySalesList { get; set; }
        public DbSet<CompanyPayment> CompanyPayments { get; set; }
  


    }
}