using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Context;
using WebApplication4.Repository;
using WebApplication4.Repository.DataContextRepository;
using WebApplication4.Repository.StaticRepository;
using WebApplication4.Utils;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        //static IEmployeeRepository repos = new DEmployeeRepository(new DataClasses1DataContext());
        EmployeeUtils eu = new EmployeeUtils(new DEmployeeRepository(new DataClasses1DataContext()));
        public ActionResult Index()
        {
            var employees = eu.GetAllEmployees();
            return View(employees);
        }
        public ActionResult Edit(int id =0)
        {
            var employees = eu.GetEmployee(id);
            return  (employees != null) ? View(employees):View();

        }
        [HttpPost]
        public ActionResult Edit(Models.Employee emp)
        {
            if (eu.Update(emp) == null)
            {
                if(ModelState.IsValid)
                    eu.Add(emp);
            }
         
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            eu.Delete(id);
            return RedirectToAction("Index", "Home"); 
        }
    }
}