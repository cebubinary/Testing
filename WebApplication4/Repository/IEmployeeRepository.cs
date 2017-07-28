using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Models.Employee emp);
        Models.Employee Update(Models.Employee emp);
        void Detele(int id);
        Models.Employee GetEmployee(int id);
        List<Models.Employee> GetEmployees();
    }
}