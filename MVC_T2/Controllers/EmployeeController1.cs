using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_T2.Models;
using System.Linq;
namespace MVC_T2.Controllers
{
    public class EmployeeController1 : Controller
    {
        CompanyDBcontext DB;
        public EmployeeController1()
        {
            DB = new CompanyDBcontext();
        }
        public IActionResult Index()
        {
            
            List<Employee> emp = DB.Employees.ToList();

            return View("Index", emp);
        }

        public IActionResult getById(int id)
        {
            Employee? empModel = DB.Employees.Include(s => s.Supervisor).Where(e => e.SSN == id).SingleOrDefault();
            if (empModel == null)
            {
                return View("Error");
            }
            return View(empModel);

        }

        public IActionResult Add()
        {
            List<Employee> emp = DB.Employees.ToList();
            return View("Add", emp);
        }
        public IActionResult AddEmployeeDb(Employee emp)
        {
            DB.Employees.Add(emp);
            DB.SaveChanges();

            List<Employee> employees = DB.Employees.ToList();
            return View("Index", employees);
        }
        public IActionResult Edit(int id)
        {
            Employee? emp = DB.Employees.SingleOrDefault(c => c.SSN == id);
            List<Employee> employees = DB.Employees.ToList();
            ViewBag.em = employees;
            return View(emp);
        }

        public IActionResult EditEmployeeDb(Employee emp)
        {
            Employee? empData = DB.Employees.SingleOrDefault(e => e.SSN == emp.SSN);
            empData.Fname = emp.Fname;
            empData.Lname = emp.Lname;
            empData.Minit = emp.Minit;
            empData.Sex = emp.Sex;
            empData.Address = emp.Address;
            empData.Salary = emp.Salary;
            empData.BirthDate = emp.BirthDate;
            empData.Supervisor= emp.Supervisor;
      
            DB.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Employee? emp = DB.Employees.SingleOrDefault(e => e.SSN == id);
            DB.Employees.Remove(emp);
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
