using System.Collections.Generic;
using Excelsheet.DAL.Entities;
using Excelsheet.DAL.Repositories;


namespace Excelsheet.BLL
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository repository)
        {
            _employeeRepository = repository;
        }

        public void ImportEmployeesFromExcel(string filePath)
        {
            List<Employee> employees = ExcelHelper.ReadExcel<Employee>(filePath);
            _employeeRepository.AddEmployees(employees);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
    }
}
