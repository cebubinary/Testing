using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Context;
using WebApplication4.Models;

namespace WebApplication4.Repository.DataContextRepository
{
    public class DEmployeeRepository : RepositoryBase,IEmployeeRepository
    {
        public DEmployeeRepository(DataClasses1DataContext _context) : base(_context)
        {
        }

        public void Add(Models.Employee emp)
        {
            Context.Employees.InsertOnSubmit(new Context.Employee { Name = emp.Name, Address= emp.Address,Age=emp.Age});
            Context.SubmitChanges();
        }

        public void Detele(int id)
        {
            var emp = Context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                Context.Employees.DeleteOnSubmit(emp);
                Context.SubmitChanges();
            }
           
        }

        public Models.Employee GetEmployee(int id)
        {
            return Context.Employees.Where(x => x.Id == id).
                Select(y => new Models.Employee { ID = y.Id, Address = y.Address, Age = y.Age ?? 0, Name = y.Name }).FirstOrDefault();
        }

        public List<Models.Employee> GetEmployees()
        {
            return Context.Employees.Select(y => new Models.Employee { ID = y.Id, Address = y.Address, Age = y.Age ?? 0, Name = y.Name }).ToList();
        }

        public Models.Employee Update(Models.Employee emp)
        {
            var e = Context.Employees.FirstOrDefault(x => x.Id == emp.ID);
            if (e != null)
            {
                e.Name = emp.Name;
                e.Age = emp.Age;
                e.Address = emp.Address;
                Context.SubmitChanges();
                emp.ID = e.Id;
                return emp;
            }            
            return null;
        }
    }
}