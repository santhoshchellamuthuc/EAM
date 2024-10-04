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
            try
            {
                return View("List", await refer.Employees.Include(e => e.Attendance).ToListAsync());

            }
            catch (Exception )
            {
                return View("Error");
            }
        }

        // GET: EmployeesController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var employee = await refer.Employees
                .Include(e => e.Attendance) // Include the attendance record
                .FirstOrDefaultAsync(e => e.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View("Details",employee);
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
            try
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
                return View("Create", employee);
            }
            catch (Exception ex)
            {
                return View("Error",ex.Message);
            }
           
        }


        // GET: EmployeesController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await refer.Employees
                    .Include(e => e.Attendance)
                    .FirstOrDefaultAsync(e => e.ID == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View("Edit", employee);

            }
            catch (Exception ex)
            {
                return View("Error",ex.Message);
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ID,Name,Email,Department,Attendance")] Employee employee)
        {

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                   
                        refer.Update(employee);
                        await refer.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    
                }
                else
                {
                    return View("Edit", employee);
                }

            }catch(Exception ex)
            {
                return View("error",ex.Message);
            }
           
        }
        public async Task<IActionResult> Delete(long? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await refer.Employees
                    .Include(e => e.Attendance)
                    .FirstOrDefaultAsync(e => e.ID == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View("Delete", employee);
            }
            catch (Exception ex)
            {
                return View("Error",ex.Message);
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var employee = await refer.Employees
              .Include(e => e.Attendance)
              .FirstOrDefaultAsync(e => e.ID == id);

                if (employee == null)
                {
                    return NotFound();
                }

                // Delete attendance data
                if (employee.Attendance != null)
                {
                    refer.Attendances.Remove(employee.Attendance);
                }

                // Delete employee data
                refer.Employees.Remove(employee);
                await refer.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error",ex.Message);
            }
        }
    }
}
    

