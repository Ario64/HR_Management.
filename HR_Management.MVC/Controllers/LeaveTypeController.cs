using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _service;
        public LeaveTypeController(ILeaveTypeService service)
        {
            _service = service;
        }


        // GET: LeaveTypeController
        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _service.GetLeaveTypesAsync();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var leaveType = await _service.GetLeaveTypeDetailsAsync(id);
            return View(leaveType);
        }

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeViewModel model)
        {
            try
            {
                var response = await _service.CreateLeaveTypeAsync(model);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "something went wrong !");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // GET: LeaveTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveTypeController/Edit/5
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

        // GET: LeaveTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypeController/Delete/5
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
