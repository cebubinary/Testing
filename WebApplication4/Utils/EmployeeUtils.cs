using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Repository;

namespace WebApplication4.Utils
{
    public class EmployeeUtils
    {
        IEmployeeRepository _repos;
        public EmployeeUtils(IEmployeeRepository repos)
        {
            _repos = repos;
        }

        public List<Models.Employee> GetAllEmployees()
        {
            return _repos.GetEmployees();
        }

        
        public Models.Employee GetEmployee(int id)
        {
            return _repos.GetEmployee(id);
        }
        public Models.Employee Update(Models.Employee emp)
        {
            return _repos.Update(emp);
        }
        public void Add(Models.Employee emp)
        {
            _repos.Add(emp);
        }
        public void Delete(int id)
        {
            _repos.Detele(id);
        }

    }
}