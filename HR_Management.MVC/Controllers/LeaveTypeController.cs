using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _service;

        // Constructor
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
                ModelState.AddModelError(string.Empty, "Validation error !");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _service.GetLeaveTypeDetailsAsync(id);
            return View(leaveType);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeViewModel model)
        {
            if (id == 0 || id != model.Id)
            {
                ModelState.AddModelError(string.Empty, "Invalid ID !");
                return View(model);
            }

            try
            {
                var response = await _service.UpdateLeaveType(id, model);
                if (response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Validation error !");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.DeleteLeaveType(id);
                if (response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Validation error !");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest();
        }

        //// POST: LeaveTypeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ConfirmDelete(int id)
        //{
        //    try
        //    {
        //        var response = await _service.DeleteLeaveType(id);
        //        if (response.Success)
        //            return RedirectToAction(nameof(Index));

        //        ModelState.AddModelError(string.Empty, "Validation error !");
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }

        //    return BadRequest();
        //}
    }
}
