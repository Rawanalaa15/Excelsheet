using System.Collections.Generic;
using System.Linq;
using Excelsheet.DAL.Dbcontext;
using Excelsheet.DAL.Entities;

namespace Excelsheet.DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public void AddEmployees(List<Employee> employees)
        {
            _context.Employees.AddRange(employees);
            _context.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
