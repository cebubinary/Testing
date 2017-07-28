using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Repository.StaticRepository
{
    public class StaticEmployeeDataContext
    {
        public List<Employee> Employees;
        private static StaticEmployeeDataContext _staticEmployeeRepo;
        public static StaticEmployeeDataContext Context
        {
            get {
                if (_staticEmployeeRepo == null)
                {
                    _staticEmployeeRepo = new StaticEmployeeDataContext();
                }
                return _staticEmployeeRepo;
            }
        }
        private StaticEmployeeDataContext()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee { ID = 1, Address = "Address1", Age = 1, Name = "Name" });
            Employees.Add(new Employee { ID = 2, Address = "Address2", Age = 2, Name = "Name2" });
        }
        public int GenerateId()
        {
            return Context.Employees.Any() ? Context.Employees.Select(y => y.ID).Max() + 1 : 1;           
        }
    }
}