using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAM.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EAMDbcontext refer;
        public EmployeesController(EAMDbcontext _refer)
        {
            refer = _refer;
        }
        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            return View("List",await refer.Employees.Include(e => e.Attendance).ToListAsync());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Department")] Employee employee, [Bind("Date,CheckInTime,CheckOutTime")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                refer.Add(employee);
                await refer.SaveChangesAsync();

                attendance.EmployeeID = employee.ID; // Link attendance to the newly created employee
                refer.Add(attendance);
                await refer.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View("Create",employee);
        }


        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
