using System;
using Excelsheet.BLL;
using Excelsheet.DAL.Repositories;
using Excelsheet.DAL.Dbcontext;

namespace Excelsheet.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Ensure correct instantiation
            using (var dbContext = new EmployeeDbContext())
            {
                var repository = new EmployeeRepository(dbContext);
                var service = new EmployeeService(repository);

                string filePath = "C:\\path\\to\\employees.xlsx";

                // Import Excel Data
                service.ImportEmployeesFromExcel(filePath);
                Console.WriteLine("Data Imported Successfully!");

                // Retrieve Data from DB
                var employees = service.GetAllEmployees();
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
                }
            }
        }
    }
}
