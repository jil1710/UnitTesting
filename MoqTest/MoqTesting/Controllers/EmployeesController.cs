using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoqTesting.Data;
using MoqTesting.Models;
using MoqTesting.Repository;

namespace MoqTesting.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManagement _context;

        public EmployeesController(IEmployeeManagement context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return _context.GetEmployeesAsync != null ? 
                          View(await _context.GetEmployeesAsync()) :
                          Problem("Entity set 'MoqContext.Employee'  is null.");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || await _context.GetEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await _context.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,AccountNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid();
                await _context.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || await _context.GetEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await _context.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Age,AccountNumber")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateEmployeeAsync(id,employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _context.GetEmployeeByIdAsync(employee.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || await _context.GetEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await _context.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (await _context.GetEmployeesAsync() == null)
            {
                return Problem("Entity set 'MoqContext.Employee'  is null.");
            }
            var employee = await _context.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
               await _context.DeleteEmployeeAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
