using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json;
using WebApplication1.BL.Employee;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        [AllowAnonymous]    
        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>(); 
            IEnumerable<Data.Employee> employees = await employeeService.GetAll();

            foreach(Data.Employee item in employees)
            {
                EmployeeViewModel emVm = new EmployeeViewModel();
                emVm.Id = item.Id;
                emVm.Name = item.Name;
                employeeViewModels.Add(emVm);
            }

            return View(employeeViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Data.Employee em = new Data.Employee();
                em.Name = model.Name;
                await employeeService.Create(em);

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Create fail");
                return View(model); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            EmployeeCreateModel model = new EmployeeCreateModel() { Id = Id };
            Data.Employee em = await employeeService.GetById(Id);
            model.Name = em.Name;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Data.Employee em = new Data.Employee()
                {
                    Id = model.Id,
                    Name = model.Name
                };
                await employeeService.Update(em);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Edit fail");
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await employeeService.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
