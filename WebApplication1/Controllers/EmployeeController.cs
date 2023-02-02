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
                Data.Employee em = new Data.Employee();
                em.Name = model.Name;
                await employeeService.Create(em);
            }
            catch
            {

            }
        }
    }
}
