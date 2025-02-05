using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsheet.DAL.Entities
{
    public class Employee
    {
       
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public int age { get; set; }
            public decimal Salary { get; set; }
        }
   }

