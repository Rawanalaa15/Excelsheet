using System.Data.Entity;
using System.Configuration;
using Excelsheet.DAL.Entities;

namespace Excelsheet.DAL.Dbcontext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            : base(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
