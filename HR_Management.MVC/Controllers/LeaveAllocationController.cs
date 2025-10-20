using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _service;
        private readonly IMapper _mapper;

        public LeaveAllocationController(ILeaveAllocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var leaveAllocations = await _service.GetLeaveAllocationsAsync();
            return View(leaveAllocations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var leaveAllocation = await _service.GetLeaveAllocationDetailsAsync(id);
            return View(leaveAllocation);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLeaveAllocationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var response = await _service.CreateLeaveAllocationAsync(model);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Validation error !");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }
    }
}
