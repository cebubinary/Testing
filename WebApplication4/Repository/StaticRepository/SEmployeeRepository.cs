using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Repository.StaticRepository
{
    public class SEmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee emp)
        {
            var id = StaticEmployeeDataContext.Context.GenerateId();
            emp.ID = id;
            StaticEmployeeDataContext.Context.Employees.Add(emp);
        }

        public void Detele(int id)
        {
            var selectedEmp = StaticEmployeeDataContext.Context.Employees.FirstOrDefault(emp => emp.ID == id);
            StaticEmployeeDataContext.Context.Employees.Remove(selectedEmp);

        }
        public Employee GetEmployee(int id)
        {
            var selectedEmp = StaticEmployeeDataContext.Context.Employees.FirstOrDefault(emp => emp.ID == id);
            return selectedEmp;
        }

        public List<Employee> GetEmployees()
        {
            return StaticEmployeeDataContext.Context.Employees.ToList();
        }

        public Employee Update(Employee emp)
        {
            var selectedEmp = StaticEmployeeDataContext.Context.Employees.FirstOrDefault(e => e.ID == emp.ID);
            if (selectedEmp != null)
            {
                selectedEmp.Name = emp.Name;
                selectedEmp.Address = emp.Address;
                selectedEmp.Age = emp.Age;
            }           
            return selectedEmp;
        }
    }
}